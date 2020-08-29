import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-default-comp",
  templateUrl: "./default-comp.component.html",
  styleUrls: ["./default-comp.component.scss"],
})
export class DefaultCompComponent implements OnInit {
  title = "Club Creator";

  constructor() {}

  ngOnInit() {}
}
