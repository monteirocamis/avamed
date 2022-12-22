import { NavigationService } from './services/navigation.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'front-avamed';

  constructor(public navigation: NavigationService) {
    this.navigation.startSaveHistory();
  }
}
