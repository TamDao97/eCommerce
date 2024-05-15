import { NgModule } from '@angular/core';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { NavComponent } from './nav/nav.component';
import { AdminLayoutComponent } from './admin-layout/admin-layout.component';
import { RouterModule } from '@angular/router';
@NgModule({
  declarations: [
    HeaderComponent,
    FooterComponent,
    NavComponent,
    AdminLayoutComponent,
  ],
  imports: [RouterModule],
  exports: [
    HeaderComponent,
    FooterComponent,
    NavComponent,
    AdminLayoutComponent,
  ],
})
export class LayoutModule {}
