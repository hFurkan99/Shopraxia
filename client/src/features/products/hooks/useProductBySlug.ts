import { useQuery } from "@tanstack/react-query";
import productsApi from "../../../services/productsApi";

export default function useProductBySlug(slug: string) {
  const {
    isFetching,
    data: product,
    error,
    refetch: refetchProduct,
  } = useQuery({
    queryKey: ["product", slug],
    queryFn: () => productsApi.getProductBySlug(slug!),
  });
  return {
    isFetching,
    product,
    error,
    refetchProduct,
  };
}
