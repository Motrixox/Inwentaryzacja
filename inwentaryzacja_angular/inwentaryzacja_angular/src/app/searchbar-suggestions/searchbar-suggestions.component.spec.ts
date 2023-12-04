import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchbarSuggestionsComponent } from './searchbar-suggestions.component';

describe('SearchbarSuggestionsComponent', () => {
  let component: SearchbarSuggestionsComponent;
  let fixture: ComponentFixture<SearchbarSuggestionsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SearchbarSuggestionsComponent]
    });
    fixture = TestBed.createComponent(SearchbarSuggestionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
