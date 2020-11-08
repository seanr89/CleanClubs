import { ErrorHandler, Injectable } from '@angular/core';

@Injectable()
export class GlobalErrorHandler implements ErrorHandler {
  constructor() {}

  handleError(error: Error) {
    // this.errorDialogService.openDialog(
    //   error.message || "Undefined client error"
    // );
    console.error("Error from global error handler", error);
  }
}