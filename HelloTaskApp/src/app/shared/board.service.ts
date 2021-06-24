import { Injectable } from '@angular/core';
import { Tab } from './tab.model';

@Injectable({
  providedIn: 'root'
})
export class BoardService {
  tab!: Tab;
  
  constructor() { }
}
