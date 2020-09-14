# Projeto teste

![.NET Core](https://github.com/bandozia/test_employee_register/workflows/.NET%20Core/badge.svg)

## Instruções

No projeto da API (EmployeeRegister), em appsettings.json altere a ConnectionString "Default" com as credenciais adequadas caso seja necessário. Em seguida aplique as migrações.

### Para testar em modo **Release**:
Faça um publish do projeto em modo release ('dotnet publish --configuration Release').
O csproj já está configurado para copiar os arquivos estáticos compilados do projeto angular para a pasta publish, bastando executar o projeto da API.

### Para testar em modo **Debug**:
No projeto angular ("WebApp") instale as depeendencias ('npm install') e inicie o servidor de desenvolvimento do angular cli ('ng serve'). Em seguida execute o projeto da API em modo debug. O projeto está configurado para utilizar a url padrão do angular cli como proxy em modo de desenvolvemento. **A url que deve ser acessada é a do projeto da API**. Se não foi alterada e estiver rodando direto no kestrel será a padrão: http://localhost:5000


