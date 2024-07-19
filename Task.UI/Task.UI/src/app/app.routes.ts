import { Routes } from '@angular/router';
import { StackoverflowComponent } from './stackOverFlow/posts-list/stackoverflow.component';
import { PostDetailsComponent } from './stackOverFlow/post-details/post-details.component';
import { DropDownComponent } from './DropDown/drop-down.component';

export const routes: Routes = [
    {path:'posts',component:StackoverflowComponent},
    { path: 'post-details', component: PostDetailsComponent },
    { path: 'categorey', component: DropDownComponent },
    {
        path: '',
        pathMatch: 'full',
        redirectTo: '/posts'
      },
      {
        path: '**',
        pathMatch: 'full',
        redirectTo: '/posts'
      }
    ]
