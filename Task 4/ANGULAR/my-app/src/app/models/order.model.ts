import { OrderItem } from "./orderItem.model";
import { Supplier } from "./supplier.model";

export interface Order {
  id: number;
  supplier: Supplier;
  supplierId: number;
  dateCreated: Date; 
  items: OrderItem[];
  status: boolean;
}