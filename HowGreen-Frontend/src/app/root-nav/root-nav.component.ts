import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { UserService } from '../services/user.service';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { map, shareReplay } from 'rxjs/operators';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
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

  constructor(private breakpointObserver: BreakpointObserver, private service: UserService, 
              private router: Router, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  isLog(): boolean
  {
    return this.service.isLogged();
  }

  onLogout()
  {
    this.toastr.success('V-ati deconectat cu succes.','Deconectare');
    this.service.logout();
    return this.router.navigate(['/user/login']);
  }

  onAuth()
  {
    this.toastr.info('Trebuie sa va conectati pentru a accesa aceasta pagina.','Permisiune');
  }


  show() {
    showMenu();
  }

  hide() {
    hideMenu();
  }
}
