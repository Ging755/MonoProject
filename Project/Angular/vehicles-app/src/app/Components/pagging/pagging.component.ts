import { Component, OnInit, Input, Output, EventEmitter} from '@angular/core';

@Component({
  selector: 'app-pagging',
  templateUrl: './pagging.component.html',
  styleUrls: ['./pagging.component.css']
})
export class PaggingComponent implements OnInit {

  constructor() { }

  @Input() page : number;
  @Input() totalnumberofpages : number;

  @Output() pageChanged: EventEmitter<number> = new EventEmitter();
  ngOnInit() {
  }

  onNextPage(){
    if(this.page < this.totalnumberofpages){
      this.page++;
      this.pageChanged.emit(this.page);
    }
  }

  onPreviousPage(){
    if(this.page > 1){
      this.page--;
      this.pageChanged.emit(this.page);  
    }
  }
}
