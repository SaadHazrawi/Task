import { Component, OnInit } from '@angular/core';
import { IStackOverFlowPost } from '../../model/stackoverflow';
import { StackoverflowService } from '../../services/stackoverflow.service';
import { NgFor } from '@angular/common';
import { Router, RouterModule  } from '@angular/router';

@Component({
  selector: 'app-stackoverflow',
  standalone: true,
  imports: [NgFor,RouterModule],
  templateUrl: './stackoverflow.component.html',
  styleUrl: './stackoverflow.component.scss'
})
export class StackoverflowComponent implements OnInit  {
  posts:IStackOverFlowPost[]=[]
  constructor(private stackposts:StackoverflowService,private router:Router) {
    this.stackposts.getStackPosts().subscribe(request=>{
      this.posts=request;
      console.table(this.posts);
    }  );
   }
   ngOnInit(): void {
    
  }
  ShowDetilePosts(post:IStackOverFlowPost){
    const tagsParam = post.tags.join(',');

    const queryParams = {
      tags: tagsParam,
      view_count: post.view_count,
      link: post.link,
      is_answered: post.is_answered,
      score: post.score,
      image:post.owner.profile_image
    };
    this.router.navigate(['/post-details'], { queryParams });
  }
}
