import { Injectable } from "@angular/core";
import {
  HttpRequest,
  HttpResponse,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HTTP_INTERCEPTORS,
} from "@angular/common/http";
import { Observable, of, throwError } from "rxjs";
import { delay, mergeMap, materialize, dematerialize } from "rxjs/operators";

const TOKEN_HEADER_KEY = 'Authorization';

@Injectable()
export class FakeBackendInterceptor implements HttpInterceptor {
  constructor() {}

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {

    // const testUser = {
    //   id: 1,
    //   username: "eencisorios510@gmail.com",
    //   password: "1234Abcc@_",
    //   firstName: "Juan",
    //   lastName: "Lopez",
    // };

    // wrap in delayed observable to simulate server api call
    return (
      of(null)
        .pipe(
          mergeMap(() => {

            let authReq = request;
            const currentUser = JSON.parse(localStorage.getItem('currentUser'));
            console.log(2)
            console.log(currentUser)
            const token = currentUser.token
            if (token != null) {
              console.log(token)
                authReq = request.clone({ headers: request.headers.set(TOKEN_HEADER_KEY, token) });
            }
            return next.handle(authReq);
            
            // authenticate
            // if (
            //   request.url.endsWith("/api/Authentication/login") &&
            //   request.method === "POST"
            // ) {
            //   if (
            //     request.body.userName === testUser.username &&
            //     request.body.password === testUser.password
            //   ) {
            //     // if login details are valid return 200 OK with a fake jwt token
            //     return of(
            //       new HttpResponse({
            //         status: 200,
            //         body: { token: "fake-jwt-token" },
            //       })
            //     );
            //   } else {
            //     // else return 400 bad request
            //     return throwError({
            //       error: { message: "Username or password is incorrect" },
            //     });
            //   }
            // }

            // get users
            // if (
            //   request.url.endsWith("/api/Users") &&
            //   request.method === "GET"
            // ) {
            //   // check for fake auth token in header and return users if valid,
            //   // this security is implemented server side in a real application
            //   if (
            //     request.headers.get("Authorization") === "Bearer fake-jwt-token"
            //   ) {
            //     return of(new HttpResponse({ status: 200, body: [testUser] }));
            //   } else {
            //     // return 401 not authorised if token is null or invalid
            //     return throwError({
            //       error: { status: 401, message: "Unauthorised" },
            //     });
            //   }
            // }

            // pass through any requests not handled above
            // return next.handle(request);
          })
        )

        // call materialize and dematerialize to ensure delay even if
        // an error is thrown (https://github.com/Reactive-Extensions/RxJS/issues/648)
        .pipe(materialize())
        .pipe(delay(500))
        .pipe(dematerialize())
    );
  }
}

export let fakeBackendProvider = {
  // use fake backend in place of Http service for backend-less development
  provide: HTTP_INTERCEPTORS,
  useClass: FakeBackendInterceptor,
  multi: true,
};
