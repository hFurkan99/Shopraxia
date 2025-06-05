import axiosClient from "./axiosClient";
import type { Product } from "../features/products/types/Product";
import type { GetProductsPayload } from "../features/products/types/GetProductsPayload";
import type { PaginatedResult } from "../types/PaginatedResult";

const productsApi = {
  getProducts: async (
    payload: GetProductsPayload
  ): Promise<PaginatedResult<Product>> => {
    const response = await axiosClient.get("/products", { params: payload });
    return response.data.products;
  },
};

export default productsApi;
