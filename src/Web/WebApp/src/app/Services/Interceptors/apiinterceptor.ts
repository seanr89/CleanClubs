import { Injectable } from "@angular/core";
import {
  HttpInterceptor,
  HttpRequest,
  HttpResponse,
  HttpHandler,
  HttpEvent,
  HttpErrorResponse,
} from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { retry, catchError } from "rxjs/operators";
import { isNullOrUndefined } from "util";
import { MatSnackBar } from "@angular/material";

@Injectable()
export class APIInterceptor implements HttpInterceptor {
  /**
   *
   * @param notificationsService : injection of a notification layer allow for informational and error messages notified to the user
   */
  constructor(private snackBar: MatSnackBar) {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): import("rxjs").Observable<HttpEvent<any>> {
    req = req.clone({ headers: req.headers.set("Accept", "application/json") });

    //Handle all http responses that have been intercepted
    return next.handle(req).pipe(
      catchError((error: HttpErrorResponse) => {
        console.log(`APIHttpInterceptor - handleError :${error.message}`);
        let errorMessage = "";
        if (error.error instanceof ErrorEvent) {
          // client-side error
          errorMessage = `Error: ${error.error.message}`;
        } else {
          errorMessage = this.handleServerSideError(error);
        }
        this.snackBar.dismiss();
        this.snackBar.open(errorMessage, "Error", {
          duration: 5000,
          panelClass: "error-dialog",
        });
        return throwError(errorMessage);
      })
    );
  }

  /**
   * Supports the parsing and generating of custom error messages for specific server side errors
   * 0, 400, 404, 500
   * @param error[HttpErrorResponse] : the error response returned from the HTTP event
   * @returns: a formatted error message
   */
  handleServerSideError(error: HttpErrorResponse): string {
    let message: string = "";

    // server-side error
    if (isNullOrUndefined(error.status) || error.status === 0) {
      message = "Unable to Send Registration";
    } else {
      debugger;
      //BadRequest
      if (error.status === 400) {
        message = error.error;
      }
      // Internal Server Error
      else if (error.status === 500) {
        message = "An unknown error has occurred";
      } else {
        message = `Code: ${error.status} \n Message: ${error.error}`;
      }
    }
    return message;
  }
}
