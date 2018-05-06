import { CreateOrEditPersonModalComponent } from './create-or-edit-person-modal/create-or-edit-person-modal.component';
import { PagedResultDtoOfPersonListDto, EnumServiceProxy, PhoneNumberEditDtoType } from './../../shared/service-proxies/service-proxies';
import { PersonListDto, PersonServiceProxy, PhoneNumberEditDto, PhoneNumberListDto } from './../../shared/service-proxies/service-proxies';

import { PagedListingComponentBase, PagedRequestDto } from 'shared/paged-listing-component-base';
import { Component, OnInit, Injector, ViewChild } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import * as _ from 'lodash';



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

  /**
   *
   *
   * @type {PersonListDto}
   * @memberof PersonsComponent
   */
  editingPerson: PersonListDto = null;

  newPhoneNumber: PhoneNumberEditDto = null;

  phonenumberTypeList: any = null;





  constructor(

    injector: Injector,
    private _personService: PersonServiceProxy,
    private _enumService: EnumServiceProxy,
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

  /**
   * 删除电话号码
   *
   * @param {PhoneNumberListDto} phoneNumber
   * @param {PersonListDto} person
   * @memberof PersonsComponent
   */
  deletePhoneNumer(phoneNumber: PhoneNumberListDto, person: PersonListDto): void {
    abp.message.confirm('是否确定删除电话号码' + phoneNumber.number, (isConfirmed) => {

      if (isConfirmed) {

        this._personService.deletePhoneNumberAsync(phoneNumber.id).subscribe(

          () => {
            this.notify.success(this.l('SuccessfullyDeleted'));
            // 无刷新处理
            _.remove(person.phoneNumbers, phoneNumber);

          }
        );
      }

    });


  }
  /**
   * 修改某个联系人的电话号码
   *
   * @param {PersonListDto} person
   * @memberof PersonsComponent
   */
  editPhoneNumbersByPerson(person: PersonListDto): void {
    // 显示枚举信息
    this._enumService.getPhoneNumberTypeList().subscribe(result => {
      this.phonenumberTypeList = result;


      if (person === this.editingPerson) {
        this.editingPerson = null;
      } else {
        this.editingPerson = person;
        this.newPhoneNumber = new PhoneNumberEditDto();

        this.newPhoneNumber.personId = person.id;
        this.newPhoneNumber.type = PhoneNumberEditDtoType._1;


      }



    })

  }

  /**
   * 添加电话号码信息
   *
   * @memberof PersonsComponent
   */
  savePhoneNumber(): void {



    if (!this.newPhoneNumber.number) {
      this.message.warn('电话号码不能为空!');
      return;
    } else {
      this._personService.addPhoneNumberAsync(this.newPhoneNumber).subscribe(
        result => {
          this.editingPerson.phoneNumbers.push(result);
          this.newPhoneNumber.number = '';
          abp.notify.success('信息保存成功');
        }
      );
    }




  }





}
