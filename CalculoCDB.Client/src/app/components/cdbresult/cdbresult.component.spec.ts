import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CDBResultComponent } from './cdbresult.component';

describe('CDBResultComponent', () => {
  let component: CDBResultComponent;
  let fixture: ComponentFixture<CDBResultComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CDBResultComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CDBResultComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});