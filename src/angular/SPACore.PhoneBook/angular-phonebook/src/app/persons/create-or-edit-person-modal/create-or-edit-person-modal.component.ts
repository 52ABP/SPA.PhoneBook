import {
  PersonServiceProxy,
  PersonEditDto,
  CreateOrUpdatePersonInput
} from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';
import {
  Component,
  OnInit,
  Injector,
  ViewChild,
  EventEmitter,
  ElementRef,
  Output
} from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';

@Component({
  selector: 'app-create-or-edit-person-modal',
  templateUrl: './create-or-edit-person-modal.component.html',
  styleUrls: ['./create-or-edit-person-modal.component.css']
})
export class CreateOrEditPersonModalComponent extends AppComponentBase {
  @ViewChild('modalContent') modalContent: ElementRef;

  @ViewChild('createOrEditModal') modal: ModalDirective;
  person: PersonEditDto = new PersonEditDto();
   @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
  active = false;
  saving = false;

  constructor(injector: Injector, private _personService: PersonServiceProxy) {
    super(injector);
  }
  onShown(): void {
    $.AdminBSB.input.activate($(this.modalContent.nativeElement));
  }
  show(personId?: number): void {
    this.active = true;
    this._personService.getPersonForEdit(personId).subscribe(personResult => {
      this.person = personResult.person;
      this.modal.show();
    });
  }

  save(): void {
const input = new  CreateOrUpdatePersonInput();

input.person = this.person;

    this.saving = true;

this._personService.createOrUpdatePerson(input).finally(() => this.saving = false).subscribe(() => {
  this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
});
  }
/**
 *关闭模态框
 *
 * @memberof CreateOrEditPersonModalComponent
 */
close(): void {
    this.active = false;
    this.modal.hide();
  }
}
