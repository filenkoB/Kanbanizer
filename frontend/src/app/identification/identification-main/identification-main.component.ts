import { AfterViewChecked, ChangeDetectorRef, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { map, Observable, of, Subscription, timeout } from 'rxjs';

@Component({
  selector: 'app-identification-main',
  templateUrl: './identification-main.component.html',
  styleUrls: ['./identification-main.component.scss']
})
export class IdentificationMainComponent {
  public showTitle = true;

  @ViewChild('centerContainer') public centerContainer? : ElementRef<HTMLElement>;

  constructor(private readonly router : Router, private readonly route : ActivatedRoute) {
    this.route.url.subscribe((url) => {
      const identificationPath = url[0];
      if (identificationPath && url.length === 1) {
        this.toggleCenterContainerContent(true);
      }
    });
  }

  openLoginForm() : void {
    this.router.navigate(['login'], {
      relativeTo: this.route
    });
    this.toggleCenterContainerContent(false);
  }

  toggleCenterContainerContent(showTitle : boolean) : void {
    this.centerContainer!.nativeElement!.style.opacity = "0";
    setTimeout(() => {
      this.showTitle = showTitle;
      this.centerContainer!.nativeElement!.style.opacity = "1";
    }, 300);
  }
}
