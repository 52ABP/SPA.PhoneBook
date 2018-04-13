import { PagedListingComponentBase, PagedRequestDto } from 'shared/paged-listing-component-base';
import { Component, OnInit, ViewChild, Injector } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PersonServiceProxy, PersonListDto, PagedResultDtoOfPersonListDto } from '@shared/service-proxies/service-proxies';

import { CreatePersonComponent } from 'app/persons/create-person/create-person.component';

import { EditPersonComponent } from 'app/persons/edit-person/edit-person.component';
import { createViewChild } from '@angular/compiler/src/core';



@Component({
  selector: 'app-persons',
  templateUrl: './persons.component.html',
  styleUrls: ['./persons.component.css'],
  animations: [appModuleAnimation()]
})
export class PersonsComponent extends PagedListingComponentBase<PersonListDto> {

  @ViewChild('createPersonModal') createPersonModal: CreatePersonComponent;

  @ViewChild('editPersonModal') editPersonMosal: EditPersonComponent;


  persons: PersonListDto[] = [];



  constructor(
    injector: Injector,
    private _personService: PersonServiceProxy) {

    super(injector);
  }





  protected list(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void {

    this._personService.
      getPagedPersons('', 'Id', request.maxResultCount, request.skipCount)
      .finally(() => { finishedCallback(); }).subscribe((result: PagedResultDtoOfPersonListDto) => {

      });



  }
  protected delete(entity: PersonListDto): void {
    throw new Error('Method not implemented.');
  }



}
