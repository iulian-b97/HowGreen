import { Component, OnInit } from '@angular/core';
declare const showMenu: any;
declare const hideMenu: any;

@Component({
  selector: 'app-root-nav',
  templateUrl: './root-nav.component.html',
  styleUrls: ['./root-nav.component.css']
})
export class RootNavComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  show() {
    showMenu();
  }

  hide() {
    hideMenu();
  }
}
