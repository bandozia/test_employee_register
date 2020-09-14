import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
	selector: 'app-pagination',
	templateUrl: './pagination.component.html',
	styleUrls: ['./pagination.component.css']
})
export class PaginationComponent implements OnInit {

	@Input() collength: number;
	@Input() size: number;

	@Output() pageChaged: EventEmitter<number> = new EventEmitter();

	pages: number[] = [];
	currentPage:number = 0;

	constructor() { }
	
	ngOnInit(): void {
		let p = Math.ceil(this.collength / this.size)
		for (let i = 0; i < p; i++) {
			this.pages.push(i);
		}
	}

	changePage(p: number): void {
		this.currentPage = p;
		this.pageChaged.emit(p);
	}

}
