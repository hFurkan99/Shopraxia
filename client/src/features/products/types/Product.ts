import type { Brand } from "./Brand";
import type { Category } from "./Category";
import type { ProductVariant } from "./ProductVariant";

export interface Product {
  id: string;
  name: string;
  slug: string;
  description: string;
  rating: number;
  category: Category;
  brand: Brand;
  variants: ProductVariant[];
}
