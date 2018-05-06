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



  /**
   * 查询联系人信息
   *
   * @protected
   * @param {PagedRequestDto} request
   * @param {number} pageNumber
   * @param {Function} finishedCallback
   * @memberof PersonsComponent
   */
  protected list(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void {

    this._personService.getPagedPersons(this.filter, 'Id', request.maxResultCount, request.skipCount).finally(() => {
      finishedCallback();
    }).subscribe((result: PagedResultDtoOfPersonListDto) => {
      this.people = result.items;
      this.showPaging(result, pageNumber);
    })



  }

  /**
   * 删除联系人
   *
   * @protected
   * @param {PersonListDto} entity
   * @memberof PersonsComponent
   */
  protected delete(entity: PersonListDto): void {
    abp.message.confirm('是否确定删除' + entity.name + '的信息', (isConfirmed) => {

      if (isConfirmed) {

        this._personService.deletePerson(entity.id).subscribe(

          () => {
            abp.notify.info(entity.name + '已被删除');
            this.refresh();
          }
        );
      }

    });




  }


  /**
   * 编辑联系人信息
   *
   * @memberof PersonsComponent
   */
  editPerson(entity: PersonListDto): void {

    this.CreateOrEditPersonModal.show(entity.id);

  }

  /**
   * 添加联系人
   *
   * @memberof PersonsComponent
   */
  createPerson(): void {

    this.CreateOrEditPersonModal.show();
  }



}
