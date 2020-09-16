using System;
using EmployeeRegister.DAL;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.Collections.Generic;
using EmployeeRegister.DAL.Models;
using System.Text;
using System.Net;
using Microsoft.Extensions.DependencyInjection.Extensions;
using EmployeeRegister.DAL.Repositories;
using System.Linq;

namespace EmployeeRegister.Test
{
    public class MainTest
    {
        private readonly WebApplicationFactory<Startup> factory;
        private readonly HttpClient client;

        public MainTest()
        {
            factory = new WebApplicationFactory<Startup>().WithWebHostBuilder(builder =>
            {                
                builder.ConfigureServices(services =>
                {
                    var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<CoreContext>));
                    services.Remove(descriptor);

                    services.AddDbContext<CoreContext>(options =>
                    {
                        options.UseInMemoryDatabase("InMemoryTestDb");
                    });

                    var sp = services.BuildServiceProvider();
                    using (var scope = sp.CreateScope())
                    {
                        var scopedServices = scope.ServiceProvider;
                        var db = scopedServices.GetRequiredService<CoreContext>();                        
                        db.Database.EnsureCreated();
                    }
                });
            
            });
                        
            client = factory.CreateClient();

        }

        [Fact(DisplayName = "O endpoint primario deve retornar OK")]
        public async Task MainEndpointWorks()
        {
            var response = await client.GetAsync("/api/employee");
            response.EnsureSuccessStatusCode();
        }

        [Theory(DisplayName = "Sexo e habilidades devem estar pre-carregados")]
        [InlineData("/api/employee/gender-list", 3)]
        [InlineData("/api/employee/skill-list", 5)]
        public async Task PreloadeedDataWorks(string url, int pCount)
        {
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var data = JsonConvert.DeserializeObject<List<dynamic>>(await response.Content.ReadAsStringAsync());
            Assert.Equal(pCount, data.Count); ;
        }

        [Fact(DisplayName = "Devem ter ao menos 1 habilidade")]
        public async Task SkillCountWorks()
        {
            var response = await client.PostAsync("/api/employee", CreateSampleEmployeee(1, -1));
            Assert.False(response.StatusCode == HttpStatusCode.Created);
        }

        [Fact(DisplayName = "A habilidade deve estar entre as pre-cadastradas")]
        public async Task SkillShouldExists()
        {
            var response = await client.PostAsync("/api/employee", CreateSampleEmployeee(1, 99));
            Assert.False(response.StatusCode == HttpStatusCode.Created);
        }

        [Fact(DisplayName = "O sexo deve estar pre-cadastrado")]
        public async Task GenderShouldExists()
        {
            var response = await client.PostAsync("/api/employee", CreateSampleEmployeee(99, 1));
            Assert.False(response.StatusCode == HttpStatusCode.Created);
        }

        [Fact(DisplayName = "Deve criar um cadastro valido")]
        public async Task ShouldCreateValidEntry()
        {
            var response = await client.PostAsync("/api/employee", CreateSampleEmployeee(1, 1));
            Assert.True(response.StatusCode == HttpStatusCode.Created);
        }

        private HttpContent CreateSampleEmployeee(int gendeeerId, int skillId)
        {
            var employee = new Employee
            {
                FirstName = "First",
                LastName = "Last",
                BirthDate = new DateTime(1985, 3, 20),
                Gender = new Gender { Id = gendeeerId },
                Skills = new List<Skill>()
            };

            if (skillId > 0)
                employee.Skills.Add(new Skill { Id = skillId });

            return new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
        }


    }
}

