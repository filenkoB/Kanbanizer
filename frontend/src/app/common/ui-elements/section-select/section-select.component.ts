import { AfterViewChecked, Component, ElementRef, Input, ViewChild } from '@angular/core';
import { map } from 'rxjs';
import { HttpClientService } from 'src/app/services/httpClient.service';

type Option = {
  id : string,
  name : string
};

@Component({
  selector: 'app-section-select',
  templateUrl: './section-select.component.html',
  styleUrls: ['./section-select.component.scss']
})
export class SectionSelectComponent implements AfterViewChecked {
  @Input() public selectOptionsUrl? : string;
  @Input() public sectionName? : string;
  @Input() public color : string = "#fff";
  @Input() public optionLinkUrl? : string;

  @ViewChild("marker") public markerEl? : ElementRef<HTMLElement>;
  @ViewChild("sectionSelectWrap") public sectionSelectWrapEl? : ElementRef<HTMLElement>;
  @ViewChild("options") public optionsEl? : ElementRef<HTMLElement>;
  
  public isSelect : boolean = false;
  public cachedOptions : Option[] = [];

  constructor(
    private readonly http : HttpClientService
  ) {}

  private _setIsSelectWithAnimation(isSelect : boolean) : void {
    this.isSelect = isSelect;
    this.playMarkerAnimation();
  }

  private _importOptionsData() : void {
    if(!this.selectOptionsUrl) {
      console.error("No selectOptionsUrl specified in SectionSelectComponent");
      return;
    }
    if (this.cachedOptions.length != 0) {
      this._setIsSelectWithAnimation(true);
      return;
    }
    this.http.getAll<any>(this.selectOptionsUrl)
      .pipe(
        map((options : any[]) => {
          options.map((option : any) => { option.id, option.name });
          if (!options.some((option : Option) => !option.id || !option.name)) {
            return options as Option[];
          }
          throw "SectionSelectComponent: Requested type doesn't contain the column with the name 'id' or 'name'";
        })
      )
      .subscribe((options : Option[]) => {
        this.cachedOptions = options;
        this._setIsSelectWithAnimation(true);
      }, (error) => (console.error(error)));
  }

  private playMarkerAnimation() : void {
    this.markerEl?.nativeElement?.classList.toggle("marker-click-animation");
    this.sectionSelectWrapEl?.nativeElement?.classList.toggle("section-select-selected");
  }

  private _playOpenListAnimation() : void {
    this.optionsEl?.nativeElement.animate([
      { maxHeight: '0' },
      { maxHeight: '300px' }
    ], { duration: 300,  fill: "forwards", direction: "normal" });
  }

  public ngAfterViewChecked(): void {
    // Play the animation when list is opening
    if (this.isSelect) {
      this._playOpenListAnimation();
    }
  }

  public toggleSelect() : void {
    if (this.isSelect) {
      this._setIsSelectWithAnimation(false);
      return;
    }
    this._importOptionsData();
  }
}
