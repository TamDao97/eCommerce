import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LayoutModule } from './layout/layout.module';
import { ShareModule } from './share/share.module';
import { UserComponent } from './user/user.component';
import { NzGridModule } from 'ng-zorro-antd/grid';

@NgModule({
  declarations: [AppComponent, UserComponent],
  imports: [BrowserModule, AppRoutingModule, LayoutModule, ShareModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
