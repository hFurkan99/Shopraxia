import type { ProductVariant } from "./ProductVariant";

export interface Product {
  id: string;
  name: string;
  slug: string;
  description: string;
  rating: number;
  categoryId: string;
  brandId: string;
  variants: ProductVariant[];
}
