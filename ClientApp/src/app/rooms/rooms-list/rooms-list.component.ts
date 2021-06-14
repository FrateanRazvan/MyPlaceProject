import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Room } from '../room.model';
import { RoomsService } from '../rooms.service';


@Component({
  selector: 'app-list-rooms',
  templateUrl: './rooms-list.component.html',
  styleUrls: ['./rooms-list.component.css']
})
export class RoomsListComponent implements OnInit {
  public rooms: Room[];

  constructor(private roomsService: RoomsService) {

  }

  getRooms() {
    this.roomsService.getRooms().subscribe(room => this.rooms = room);
  }

  ngOnInit(): void {
    this.getRooms();
  }
}
