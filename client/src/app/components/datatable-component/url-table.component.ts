import { Component, OnInit } from '@angular/core';
import { UrlService } from './services/url.service';
import {GetAllRequestModel} from "./models/get-all-request.model";
import { faTrash} from "@fortawesome/free-solid-svg-icons/faTrash"
import { faInfo} from "@fortawesome/free-solid-svg-icons/faInfo";
import { faPlus} from "@fortawesome/free-solid-svg-icons/faPlus";
import {AuthService} from "../identity-component/services/auth.service";
import {DomSanitizer} from "@angular/platform-browser";
import {Router} from "@angular/router";
import {delay} from "rxjs";

@Component({
  selector: 'app-url-table',
  templateUrl: './url-table.component.html',
  styleUrls: ['./url-table.component.scss'],
})
export class UrlTableComponent implements OnInit {
  urls: any[] = [];
  detailsToShow = '';
  getUrlsReq: GetAllRequestModel = {};
  isLoggedIn: boolean = false;
  isOverlayVisible = false;
  isDetailsVisible =  false;
  constructor(private urlService: UrlService, private authService: AuthService, private sanitizer: DomSanitizer, private router : Router) {}

  async ngOnInit(): Promise<void> {
    this.isLoggedIn = this.authService.isLoggedIn();
    this.fetchUrls();
  }
  getSafeUrl(url: string) {
    return this.sanitizer.bypassSecurityTrustUrl(url);
  }
  fetchUrls(): void {
    this.urlService.getAllUrls(this.getUrlsReq).subscribe((data) => {
      this.urls = data.urls;
    });
  }
  deleteUrl(urlId: string): void{
    this.urlService.deleteUrl(urlId).subscribe((data) => {
      console.log("deleted");
    });
    setTimeout(() => {
      const currentUrl = this.router.url;
      this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
        this.router.navigateByUrl(currentUrl);
      });
    },400);
  }

  showUrlDetails(ulrId: string): void{
    this.urlService.getUrlDetails(ulrId).subscribe((data) => {
      this.detailsToShow = `Url Id = ${data.urlId}<br/>Url From = ${data.urlFrom}<br/>Url to = ${data.urlTo}<br/>
                            Created ${data.creationDate}<br/> Created by ${data.userId}`;
    });
    this.isDetailsVisible = true;
  }
  openOverlay() {
    this.isOverlayVisible = true;
  }
  handleOverlayClose() {
    this.isOverlayVisible = false;
  }
  handleDetailsClose() {
    this.isDetailsVisible = false;5
  }

  protected readonly faTrash = faTrash;
  protected readonly faInfo = faInfo;
  protected readonly faPlus = faPlus;
}
