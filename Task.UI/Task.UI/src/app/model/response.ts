
  
  export interface IPaginationResponse<T> {
    totalItemsCount: number;
    pageSize: number;
    totalPagesCount: number;
    pageIndex: number;
    next: boolean;
    previous: boolean;
    items: T[];
  }