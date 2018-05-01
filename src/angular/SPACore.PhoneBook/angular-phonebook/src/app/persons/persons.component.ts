import { PhoneNumberListDto } from './../../shared/service-proxies/service-proxies';
import { PhoneNumberEditDto, PhoneNumberEditDtoType, EnumServiceProxy } from '@shared/service-proxies/service-proxies';
import { PhoneBookTemplatePage } from './../../../e2e/app.po';
import { PagedListingComponentBase, PagedRequestDto } from 'shared/paged-listing-component-base';
import { Component, OnInit, ViewChild, Injector } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PersonServiceProxy, PersonListDto, PagedResultDtoOfPersonListDto } from '@shared/service-proxies/service-proxies';



import { createViewChild } from '@angular/compiler/src/core';
import { CreateOrEditPersonModalComponent } from '@app/persons/create-or-edit-person-modal/create-or-edit-person-modal.component';
import * as _ from 'lodash';



@Component({
  selector: 'app-persons',
  templateUrl: './persons.component.html',
  styleUrls: ['./persons.component.css'],
  animations: [appModuleAnimation()]
})
export class PersonsComponent extends PagedListingComponentBase<PersonListDto> implements OnInit {

  @ViewChild('createOrEditPersonModal') createOrEditPersonModal: CreateOrEditPersonModalComponent;


  filter = '';
  persons: PersonListDto[] = [];


  editingPerson: PersonListDto = null;

  newPhonNumber: PhoneNumberEditDto = null;

  phoneNumberTypeList: any = null;



  constructor(
    injector: Injector,
    private _personService: PersonServiceProxy,

    private _enumsServices: EnumServiceProxy


  ) {

    super(injector);
  }


  // ngOnInit(): void {
  //   this._enumsServices.getPhoneNumberTypeList().subscribe(result => {
  //     this.phoneNumberTypeList = result;
  //   });
  // }


  /**
   * 分页查询person表中的信息
   *
   * @protected
   * @param {PagedRequestDto} request
   * @param {number} pageNumber
   * @param {Function} finishedCallback
   * @memberof PersonsComponent
   */
  protected list(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void {



    this._personService.
      getPagedPersons(this.filter, 'Id', request.maxResultCount, request.skipCount)
      .finally(() => { finishedCallback(); }).subscribe((result: PagedResultDtoOfPersonListDto) => {
        this.persons = result.items;
        this.showPaging(result, pageNumber);

      });



  }
  /**
   * 删除人的功能
   *
   * @protected
   * @param {PersonListDto} entity
   * @memberof PersonsComponent
   */
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





  /**
   * 创建联系人
   *
   * @memberof PersonsComponent
   */
  createPerson(): void {

    this.createOrEditPersonModal.show();
  }
  /**
   * 编辑联系人基本信息
   *
   * @param {PersonListDto} entity
   * @memberof PersonsComponent
   */
  editPerson(entity: PersonListDto): void {
    this.createOrEditPersonModal.show(entity.id);
  }


  /**
   * 删除电话号码
   *
   * @param {any} phoneNumber
   * @param {any} person
   * @memberof PersonsComponent
   */
  deletePhone(phoneNumber: PhoneNumberListDto, person: PersonListDto): void {


    abp.message.confirm(
      '是否确定删除电话号码为' + phoneNumber.number + '的信息',
      (isconfirmed) => {
        if (isconfirmed) {
          this._personService.deletePhoneAsync(phoneNumber.id).subscribe(() => {
            this.notify.success(this.l('SuccessfullyDeleted'));
            _.remove(person.phoneNumbers, phoneNumber);
          });
        }
      }
    );




  }

  /**
   *
   *
   * @param {PersonListDto} person
   * @memberof PersonsComponent
   */
  editPhoneNumbers(person: PersonListDto): void {

    this._enumsServices.getPhoneNumberTypeList().subscribe(result => {
      this.phoneNumberTypeList = result;
    });



    if (person === this.editingPerson) {
      this.editingPerson = null;
    } else {



      this.editingPerson = person;
      this.newPhonNumber = new PhoneNumberEditDto();
      this.newPhonNumber.personId = person.id;
      this.newPhonNumber.type = PhoneNumberEditDtoType._1;

    }
  }

  /**
   * 添加新电话号码到联系人中
   *
   * @memberof PersonsComponent
   */
  savePhone(): void {

    if (!this.newPhonNumber.number) {
      this.message.warn('电话号码不能为空!');
      return;
    }

    this._personService.addPhone(this.newPhonNumber).subscribe(result => {
      this.editingPerson.phoneNumbers.push(result);
      this.newPhonNumber.number = '';
      this.notify.success(this.l('SavedSuccessfully'));

    });


  }













}
