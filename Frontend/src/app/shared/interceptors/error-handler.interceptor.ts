import { Injectable } from '@angular/core';
import {
	HttpRequest,
	HttpHandler,
	HttpEvent,
	HttpInterceptor,
	HttpErrorResponse
} from '@angular/common/http';
import { Router } from '@angular/router';
import { MatDialog, MatDialogRef, MatSnackBar } from '@angular/material';

import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

import { AuthService } from '../services/auth.service';
import { ErrorDialogComponent } from '../error-dialog/error-dialog.component';

/**
 * Displays a generic error message whenever something regarding a HTTP request goes wrong
 */
@Injectable({ providedIn: 'root' })
export class ErrorHandlerInterceptor implements HttpInterceptor {
	private currentlyOpenedDialog?: MatDialogRef<ErrorDialogComponent>;

	constructor(private auth: AuthService, private router: Router, private dialog: MatDialog, private snackBar: MatSnackBar) {}

	public intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
		return next.handle(request).pipe((
			tap(() => undefined, (event) => {
				if (event instanceof HttpErrorResponse) {
					console.warn(event);
					if (event.status === 0) {
						// Display a toast when the server couldn't be reached
						this.snackBar.open('Mutterschiff konnte nicht erreicht werden', 'Ok');
						return;
					}

					if (event.status === 400) {
						// Display a toast with the error message
						// E.g. Email is already taken
						if (event.error) {
							this.snackBar.open(event.error, 'Ok');
						} else {
							this.snackBar.open('Unbekannter Validierungsfehler', 'Ok');
						}

						return;
					}

					if (event.status === 401) {
						// Unauthorized request (except on login) cause a redirect to the login
						if (!request.url.endsWith('StartSession')) {
							this.auth.clearLocalSession();
							this.router.navigate(['Login']);
						}
						return;
					}

					if (this.currentlyOpenedDialog !== undefined) {
						// Prevent dialog spam
						this.currentlyOpenedDialog.close();
					}

					this.currentlyOpenedDialog = this.dialog.open(ErrorDialogComponent);
				}
		})));
	}
}
