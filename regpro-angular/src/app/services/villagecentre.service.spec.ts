import { TestBed } from '@angular/core/testing';

import { VillagecentreService } from './villagecentre.service';

describe('VillagecentreService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: VillagecentreService = TestBed.get(VillagecentreService);
    expect(service).toBeTruthy();
  });
});
