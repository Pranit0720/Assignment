import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideClientHydration } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS, provideHttpClient, withInterceptorsFromDi  } from '@angular/common/http';
import { CustomintercepterService } from './customintercepter.service';

export const appConfig: ApplicationConfig = {
  providers: [provideZoneChangeDetection({ eventCoalescing: true }), provideRouter(routes), provideHttpClient(),provideClientHydration(),provideHttpClient(),provideHttpClient(withInterceptorsFromDi ()),{provide:HTTP_INTERCEPTORS,useClass: CustomintercepterService,multi:true},]
};
