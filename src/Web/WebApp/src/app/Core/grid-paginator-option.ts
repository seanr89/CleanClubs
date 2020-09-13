import { Component, Injectable } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';

/**
 * @title Configurable paginator
 */
@Injectable({
    providedIn: 'root',
})
export class GridPaginatorOption {
    // MatPaginator Inputs
    length = 100;
    pageSize = 10;
    pageSizeOptions: number[] = [5, 10, 25, 100];

    // MatPaginator Output
    pageEvent: PageEvent;

    setPageSizeOptions(setPageSizeOptionsInput: string) {
        this.pageSizeOptions = setPageSizeOptionsInput
            .split(',')
            .map((str) => +str);
    }
}
