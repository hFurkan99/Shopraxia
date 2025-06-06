import { useQuery } from "@tanstack/react-query";
import productsApi from "../../../services/productsApi";

export default function useProductById(id: string) {
  const {
    isFetching,
    data: product,
    error,
    refetch: refetchProduct,
  } = useQuery({
    queryKey: ["product", id],
    queryFn: () => productsApi.getProductById(id),
  });
  return {
    isFetching,
    product,
    error,
    refetchProduct,
  };
}
