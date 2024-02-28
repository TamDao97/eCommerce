import { NgModule } from '@angular/core';
import { NavComponent } from './nav/nav.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';

@NgModule({
  declarations: [NavComponent, HeaderComponent, FooterComponent],
  imports: [],
  exports: [NavComponent, HeaderComponent, FooterComponent],
})
export class LayoutModule {}
