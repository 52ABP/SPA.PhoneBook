import { CreateOrEditPersonModalComponent } from './create-or-edit-person-modal/create-or-edit-person-modal.component';
import { PersonListDto, PersonServiceProxy, PagedResultDtoOfPersonListDto } from './../../shared/service-proxies/service-proxies';
import { PagedListingComponentBase, PagedRequestDto } from 'shared/paged-listing-component-base';
import { Component, OnInit, Injector, ViewChild } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';



@Component({
  selector: 'app-persons',
  templateUrl: './persons.component.html',
  styleUrls: ['./persons.component.css'],
  animations: [appModuleAnimation()]

})
export class PersonsComponent extends PagedListingComponentBase<PersonListDto>  {


  @ViewChild('createOrEditPersonModal') CreateOrEditPersonModal: CreateOrEditPersonModalComponent;


  filter = '';

  people: PersonListDto[] = [];




  constructor(

    injector: Injector,
    private _personService: PersonServiceProxy

  ) {
    super(injector)

  }




  protected list(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void {

    this._personService.getPagedPersons(this.filter, 'Id', request.maxResultCount, request.skipCount).finally(() => {
      finishedCallback();
    }).subscribe((result: PagedResultDtoOfPersonListDto) => {
      this.people = result.items;
      this.showPaging(result, pageNumber);
    })



  }
  protected delete(entity: PersonListDto): void {
    throw new Error('Method not implemented.');
  }



  createPerson(): void {

    this.CreateOrEditPersonModal.show();
  }



}
