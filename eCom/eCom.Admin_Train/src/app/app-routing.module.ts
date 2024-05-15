import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminLayoutComponent } from './layout/admin-layout/admin-layout.component';
import { ProfileComponent } from './profile/profile.component';
import { UserComponent } from './user/user.component';

const routes: Routes = [
  {
    path: '',
    component: AdminLayoutComponent,
    children: [
      {
        path: 'profile',
        component: ProfileComponent,
      },
      {
        path: '',
        component: UserComponent,
      },
    ],
  },

  // {
  //   path: '',
  //   loadChildren: () =>
  //     import('../app/system/system.module').then((m) => m.SystemModule),
  // },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
