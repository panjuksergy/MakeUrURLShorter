import { Component, EventEmitter, Output } from '@angular/core';
import {NewUrlService} from "./services/new-url.service";
import {CreateNewUrlModel} from "./models/create-new-url.model";
import {Router} from "@angular/router";

@Component({
  selector: 'app-new-url-component',
  templateUrl: './new-url.component.html',
  styleUrls: ['./new-url.component.scss']
})
export class NewUrlComponent {
  @Output() closeOverlay = new EventEmitter<void>();
  urlTo: string ='';
  textToShown = 'Enter Ur URL';
  constructor(private newUrlService: NewUrlService, private router: Router)
  {}
  onCloseOverlay() {
    this.closeOverlay.emit();
  }

  async generateNewUrl(urlInput: string) {
    const request = new CreateNewUrlModel(urlInput)
    this.newUrlService.createNewUrl(request).subscribe((urlToNew: string) => {
      this.urlTo = urlToNew;
    });
    setTimeout(() => {
      const currentUrl = this.router.url;
      this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
        this.router.navigateByUrl(currentUrl);
      });
    },400);
  }
}
