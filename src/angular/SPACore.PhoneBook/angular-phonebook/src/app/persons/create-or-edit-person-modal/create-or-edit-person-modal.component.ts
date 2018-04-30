import { PersonServiceProxy, PersonEditDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';
import { Component, OnInit, Injector, ViewChild, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';

@Component({
  selector: 'app-create-or-edit-person-modal',
  templateUrl: './create-or-edit-person-modal.component.html',
  styleUrls: ['./create-or-edit-person-modal.component.css']
})
export class CreateOrEditPersonModalComponent extends AppComponentBase   {

@ViewChild('createOrEditModal') modal: ModalDirective;
  persons: PersonEditDto = new PersonEditDto();
  // @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

  constructor(
    injector:     Injector,
    private _personService: PersonServiceProxy
  ) {
    super(injector);
  }

  show(personId?: number): void {

this._personService.getPersonForEdit(personId).subscribe(personResult => {
this.persons = personResult.person;
this.modal.show();
});

  }


}
