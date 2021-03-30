import { Iitems } from "./item";

export interface IPagination {
    pageIndex: number;
    pageSize: number;
    count: number;
    data: Iitems[];
  }
  