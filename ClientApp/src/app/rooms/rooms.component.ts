import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Room } from './room.model';

@Component({
  selector: 'app-programmes',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public rooms: Room[];

  constructor(http: HttpClient, @Inject('API_URL') apiUrl: string) {
    http.get<Room[]>(apiUrl + 'weatherforecast').subscribe(result => {
      this.rooms = result;
    }, error => console.error(error));
  }
}
