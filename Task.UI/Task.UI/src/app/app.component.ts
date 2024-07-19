import { Component, OnInit } from '@angular/core';
import { RouterLink, RouterModule, RouterOutlet } from '@angular/router';
import { StackoverflowService } from './services/stackoverflow.service';
import { IStackOverFlowPost } from './model/stackoverflow';
import { StackoverflowComponent } from "./stackOverFlow/posts-list/stackoverflow.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, StackoverflowComponent,RouterModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit  {
  
  constructor(private stackposts:StackoverflowService) { }
  posts:IStackOverFlowPost[]=[]
  ngOnInit(): void {
    this.stackposts.getStackPosts().subscribe(request=>{
      this.posts=request;
      console.table(this.posts);
    }  );
  }
}
