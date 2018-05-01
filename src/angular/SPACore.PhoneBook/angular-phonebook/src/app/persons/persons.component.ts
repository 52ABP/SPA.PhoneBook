import { PhoneBookTemplatePage } from './../../../e2e/app.po';
import { PagedListingComponentBase, PagedRequestDto } from 'shared/paged-listing-component-base';
import { Component, OnInit, ViewChild, Injector } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PersonServiceProxy, PersonListDto, PagedResultDtoOfPersonListDto } from '@shared/service-proxies/service-proxies';


import { createViewChild } from '@angular/compiler/src/core';
import { CreateOrEditPersonModalComponent } from '@app/persons/create-or-edit-person-modal/create-or-edit-person-modal.component';



@Component({
  selector: 'app-persons',
  templateUrl: './persons.component.html',
  styleUrls: ['./persons.component.css'],
  animations: [appModuleAnimation()]
})
export class PersonsComponent extends PagedListingComponentBase<PersonListDto>   {

@ViewChild('createOrEditPersonModal') createOrEditPersonModal: CreateOrEditPersonModalComponent;


filter = '';
  persons: PersonListDto[] = [];







  constructor (
    injector: Injector,
    private _personService: PersonServiceProxy) {

    super(injector);
  }





  protected list(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void {

    this._personService.
      getPagedPersons(this.filter, 'Id', request.maxResultCount, request.skipCount)
      .finally(() => { finishedCallback(); }).subscribe((result: PagedResultDtoOfPersonListDto) => {
        this.persons = result.items;
        this.showPaging(result, pageNumber);

      });



  }
  // 删除功能
  protected delete(entity: PersonListDto): void {
abp.message.confirm(
  '是否确定删除' + entity.name + '的信息',
  (isconfirmed) => {
if (isconfirmed) {
  this._personService.deletePerson(entity.id).subscribe(() => {
    abp.notify.info(entity.name + '的信息已被删除');
   this.refresh();
  });
}
  }
);
  }



  // createPerson

  createPerson(): void {

    this.createOrEditPersonModal.show();
  }

  editPerson(entity: PersonListDto): void {
    this.createOrEditPersonModal.show(entity.id);
  }

}
