import { PersonListDto, PersonServiceProxy, PagedResultDtoOfPersonListDto } from './../../shared/service-proxies/service-proxies';
import { PagedListingComponentBase, PagedRequestDto } from 'shared/paged-listing-component-base';
import { Component, OnInit, Injector } from '@angular/core';
 
@Component({
  selector: 'app-persons',
  templateUrl: './persons.component.html',
  styleUrls: ['./persons.component.css']
})
export class PersonsComponent  extends  PagedListingComponentBase<PersonListDto>  {


filter='';

people:PersonListDto[]=[];




  constructor(

    injector:Injector,
    private _personService:PersonServiceProxy

  ) { 
super(injector)

  }
 



  protected list(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void {
  
    this._personService.getPagedPersons(this.filter,'Id',request.maxResultCount,request.skipCount).finally(()=>{
      finishedCallback();
    }).subscribe((result:PagedResultDtoOfPersonListDto)=>{
      this.people=result.items;
      this.showPaging(result,pageNumber);
    })
    


  }
  protected delete(entity: PersonListDto): void {
    throw new Error("Method not implemented.");
  }

}
