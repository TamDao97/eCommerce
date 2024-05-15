import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CommonModule, registerLocaleData } from '@angular/common';
import en from '@angular/common/locales/en';
import { provideNzI18n, en_US } from 'ng-zorro-antd/i18n';
import { BrowserModule } from '@angular/platform-browser';
import { ShareModule } from './share/share.module';
import { UserEditComponent } from './user/user-edit/user-edit.component';
import { UserComponent } from './user/user.component';
import { AccountInfoComponent } from './user/user-edit/account-info/account-info.component';
import { UserProfileComponent } from './user/user-edit/user-profile/user-profile.component';
import { LayoutModule } from './layout/layout.module';

registerLocaleData(en);

@NgModule({
  declarations: [
    AppComponent,
    AccountInfoComponent,
    UserProfileComponent,
    UserEditComponent,
    UserComponent,
  ],
  imports: [
    AppRoutingModule,
    LayoutModule,
    ShareModule,
  ],
  providers: [provideNzI18n(en_US)],
  bootstrap: [AppComponent],
})
export class AppModule {}
