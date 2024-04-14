import { NgModule } from '@angular/core';
import { SystemComponent } from './system.component';
import { DashboardComponent } from '../dashboard/dashboard.component';
import { ProfileComponent } from '../profile/profile.component';
import { AccountInfoComponent } from '../user/user-edit/account-info/account-info.component';
import { UserEditComponent } from '../user/user-edit/user-edit.component';
import { UserProfileComponent } from '../user/user-edit/user-profile/user-profile.component';
import { UserComponent } from '../user/user.component';
import { LayoutModule } from '../layout/layout.module';
import { ShareModule } from '../share/share.module';
import { RouterModule } from '@angular/router';
import { SystemRoutingModule } from './system-routing.module';

@NgModule({
  imports: [RouterModule, LayoutModule, ShareModule, SystemRoutingModule],
  declarations: [
    DashboardComponent,
    ProfileComponent,
    AccountInfoComponent,
    UserProfileComponent,
    UserComponent,
    UserEditComponent,
    SystemComponent,
  ],
})
export class SystemModule {}
