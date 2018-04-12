import { Component, OnInit, ViewChild } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PersonServiceProxy, PersonListDto, PagedResultDtoOfPersonListDto } from '@shared/service-proxies/service-proxies';

import { CreatePersonComponent } from 'app/persons/create-person/create-person.component';

import { EditPersonComponent } from 'app/persons/edit-person/edit-person.component';

@Component({
  selector: 'app-persons',
  templateUrl: './persons.component.html',
  styleUrls: ['./persons.component.css'],
  animations: [appModuleAnimation()]
})
export class PersonsComponent implements OnInit {
 


  constructor() { }

  ngOnInit() {
  }

}
