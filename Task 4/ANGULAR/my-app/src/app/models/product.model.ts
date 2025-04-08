import { Supplier } from "./supplier.model";

export interface Product {
  id: number;
  productName: string;
  pricePerUnit: number;
  minQuantity: number;
  supplierId: number;
  supplier: Supplier;
  currentStock: number;
}