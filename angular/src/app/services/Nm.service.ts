import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BookService {


  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(
    public http: HttpClient
  ) {


  }

  GetBookingOptions(): Observable<any> {

    return this.http.get<any>(`/api/app/bookings/booking-options`, this.httpOptions)
      .pipe(
        map((res: any) => {
          return res;
        })
      );
  }

}
