import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TablesListComponent } from './tables-list.component';

describe('TablesListComponent', () => {
  let component: TablesListComponent;
  let fixture: ComponentFixture<TablesListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TablesListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TablesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
