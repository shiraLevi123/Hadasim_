import { Product } from './product.model'

export interface Supplier {
  id: number;
  companyName: string;
  phone: string;
  agentName: string;
  products: Product[];
  password: string;
}
// interface SupplierRegistrationDto {
//   companyName: string;
//   phone: string;
//   agentName: string;
//   password: string;
//   products: {
//     productName: string;
//     pricePerUnit: number;
//     minQuantity: number;
//     currentStock: number;
//   }[];
// }