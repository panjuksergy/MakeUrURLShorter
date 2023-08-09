import {Component, EventEmitter, Input, Output} from '@angular/core';
import {NewUrlService} from "../new-url-component/services/new-url.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-pop-up-component',
  templateUrl: './pop-up.component.html',
  styleUrls: ['./pop-up.component.scss']
})
export class PopUpComponent {
  @Input() withInput: boolean = false;
  @Input() shownText = '';
  @Output() closeOverlay = new EventEmitter<void>();
  @Output() onOkeyInput = new EventEmitter<string>();
  inputData: string = ''; // Initialize the property to an empty string
  constructor(private router: Router)
  {}
  onCloseOverlay() {
    this.closeOverlay.emit();
  }
  onOk(value: string){
    this.onOkeyInput.emit(value);
  }
}
