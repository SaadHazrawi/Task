import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { IStackOverFlowPost } from '../../model/stackoverflow';
import { NgIf } from '@angular/common';

@Component({
  standalone: true,
  imports: [RouterLink,NgIf],
  templateUrl: './post-details.component.html',
  styleUrl: './post-details.component.scss'
})
export class PostDetailsComponent implements OnInit {
  postView!: {tags:string[],view_count:Int16Array,link:string,is_answered:boolean,score:number,image:string};

  constructor(private route: ActivatedRoute) { }
 
    ngOnInit() {
      this.route.queryParams.subscribe(params => {
        this.postView = {
          tags: params['tags'] ? params['tags'].split(',') : [],
          view_count: params['view_count'] || '',  
          link: params['link'] || '',
          is_answered: params['is_answered'] === 'true',  
          score: Number(params['score']) || 0  ,
          image:params['image']
        };
        
        console.log(this.postView);
      });
    }
  }