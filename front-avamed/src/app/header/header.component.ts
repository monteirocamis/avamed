import { Component } from '@angular/core';
import {
  style,
  animate,
  keyframes
} from '@angular/animations';
import { Router, RouterModule } from '@angular/router';
import { NavigationService } from 'src/app/service/navigation.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {

  // voltar(){
  //   this.router.navigate(['seletor']);
  // }
  constructor(public navigation: NavigationService) { }

}
