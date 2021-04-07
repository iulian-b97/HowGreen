import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';

import { UserService } from 'src/app/shared/user.service';
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'app-root-nav',
  templateUrl: './root-nav.component.html',
  styleUrls: ['./root-nav.component.css'],
  providers: [
    UserService
  ]
})
export class RootNavComponent {

  //public isLoggedIn$: BehaviorSubject<boolean>;


  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  constructor(private breakpointObserver: BreakpointObserver, private service: UserService) {}

  isLog(): boolean
  {
    return this.service.isLogged();
  }
}
