import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { UserService } from '../services/user.service';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { map, shareReplay } from 'rxjs/operators';
import { Router } from '@angular/router';
declare const showMenu: any;
declare const hideMenu: any;

@Component({
  selector: 'app-root-nav',
  templateUrl: './root-nav.component.html',
  styleUrls: ['./root-nav.component.css'],
  providers: [
    UserService
  ]
})
export class RootNavComponent implements OnInit {

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  constructor(private breakpointObserver: BreakpointObserver, private service: UserService, private router: Router) { }

  ngOnInit(): void {
  }

  isLog(): boolean
  {
    return this.service.isLogged();
  }

  onLogout()
  {
    this.service.logout();
    return this.router.navigate(['/user/login']);
  }


  show() {
    showMenu();
  }

  hide() {
    hideMenu();
  }
}
