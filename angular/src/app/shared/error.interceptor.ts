import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';


@Injectable()
export class ErrorInterceptor implements HttpInterceptor {


  constructor() { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(catchError(err => {


      const error = err.error?.error;

      const res = { status: 'error' } as any;
      // Unknown Error
      if (err.status === 0) { res.message = 'Something went wrong. Please try again shortly.'; }
      // Bad Request
      if (err.status === 400) { res.message = 'Something went wrong. Please try again'; }
      // Bad Request
      if (err.status === 401) { res.message = 'Unauthorised'; }
      // Forbidden / Friendly exception
      if (err.status === 403) { res.title = error.code || 'Ooppps! There is a problem!', res.message = error.message; }
      // Not Found
      if (err.status === 404) { res.title = error.code || 'Ooppps! There is a problem!', res.message = 'Item not found'; }
      // Request Timeout
      if (err.status === 408) { res.message = 'Request timed out. Please try again.'; }
      // Server Errors
      if (err.status >= 500) { res.message = 'Something went wrong. Please try again'; }

      // console.log(err?.code);
      if (res.message) {
        alert(res.message);
      }
      return throwError(err);

    }));
  }
}
