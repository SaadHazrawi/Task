import { Component, OnInit } from '@angular/core';
import { ICategory } from '../model/category';
import { ISubCategorey } from '../model/subCategorey';
import { CategoreyService } from '../services/categorey.service';
import { SubCategoreyService } from '../services/sub-categorey.service';
import { NgFor } from '@angular/common';

@Component({
  selector: 'app-drop-down',
  standalone: true,
  imports: [NgFor],
  templateUrl: './drop-down.component.html',
  styleUrl: './drop-down.component.scss'
})
export class DropDownComponent implements OnInit {
  categories: ICategory[] = [];
  subCategories: ISubCategorey[] = [];
  constructor(private categorySerivers: CategoreyService, private subCategoreyService: SubCategoreyService) { }
  ngOnInit(): void {
    this.categorySerivers.getCategories().subscribe(response => {
      this.categories = response.items;
    })
  }
  onCategoryChange(event: Event): void {
    const selectElement = event.target as HTMLSelectElement;
    const selectedId = Number(selectElement.value);
    this.getSubCatgoiresByCategoryId(selectedId);
    console.log('Selected category ID:', selectedId);

  }
  getSubCatgoiresByCategoryId(selectedId: number) {
  this.subCategoreyService.getSubCategories(selectedId).subscribe(response => {
      this.subCategories = response;
      console.log('Subcategories:', this.subCategories);
    })
  }
}
 

