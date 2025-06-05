import { useQuery } from "@tanstack/react-query";
import productsApi from "../../../services/productsApi";
import type { GetProductsPayload } from "../types/GetProductsPayload";

export function useProducts(payload: GetProductsPayload) {
  const {
    isFetching,
    data: paginatedResult,
    error,
    refetch: refetchProducts,
  } = useQuery({
    queryKey: ["products", payload],
    queryFn: () => productsApi.getProducts(payload),
  });
  return {
    isFetching,
    products: paginatedResult?.data,
    error,
    pageIndex: paginatedResult?.pageIndex,
    pageSize: paginatedResult?.pageSize,
    count: paginatedResult?.count,
    refetchProducts,
  };
}
