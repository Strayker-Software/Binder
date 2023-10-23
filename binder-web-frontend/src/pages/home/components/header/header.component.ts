import { Component, OnDestroy, OnInit } from "@angular/core";
import { Subject, take } from 'rxjs';
import { AppVersion, AppVersionsService } from "src/api";
import { DisplayableVersion } from "src/shared/models/displayableVersion";

@Component({
  selector: 'header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit, OnDestroy { 
  private subscribe$: Subject<void> = new Subject<void>();
  attributes: string[] = ['major', 'minor', 'patch', 'name'];
  version?: DisplayableVersion;

  constructor(private appVersionsService: AppVersionsService) {}
  
  ngOnInit(): void {
    this.appVersionsService
    .getVersionGet(1)
    .pipe(take(1))
      .subscribe({
        next: (version: AppVersion) => {
          const displayableVerion: DisplayableVersion = {
            name: version.name,
            major: version.major,
            minor: version.minor,
            patch: version.patch
          } as DisplayableVersion;

          this.version = displayableVerion;
        },
        error: (error: any) => {
          console.error(error);
        },
      });
  } 
  
  ngOnDestroy(): void {
    this.subscribe$.unsubscribe();
  }
}