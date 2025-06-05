import type { ProductAttribute } from "./ProductAttribute";
import type { ProductImage } from "./ProductImage";

export interface ProductVariant {
  id: string;
  sku: string;
  price: number;
  stock: number;
  attributes: ProductAttribute[];
  images: ProductImage[];
}
