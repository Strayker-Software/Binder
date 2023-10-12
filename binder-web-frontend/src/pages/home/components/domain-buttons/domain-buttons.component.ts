import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'domain-buttons',
  templateUrl: './domain-buttons.component.html',
  styleUrls: ['./domain-buttons.component.scss'],
})
export class DomainButtonsComponent implements OnInit {
  @Output() optionsClickedEvent: EventEmitter<HTMLParagraphElement> =
    new EventEmitter();
  @Output() aboutClickedEvent: EventEmitter<HTMLParagraphElement> =
    new EventEmitter();

  constructor() {}

  ngOnInit() {}

  optionsClicked() {
    this.optionsClickedEvent.emit();
  }

  aboutClicked() {
    this.aboutClickedEvent.emit();
  }
}
