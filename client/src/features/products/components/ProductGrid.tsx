import styled from "styled-components";
import { useProducts } from "../hooks/useProducts";
import type { Product } from "../types/Product";
import ProductCard from "./ProductCard";

const Grid = styled.div`
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(260px, 1fr));
  gap: 2rem;
  margin-top: 2rem;
`;

export default function ProductGrid() {
  const payload = {
    page: 1,
    pageSize: 30,
    sortBy: "name",
    sortOrder: "desc",
  } as const;
  const { isFetching, products } = useProducts(payload);

  return (
    <Grid>
      {products && products.length > 0 ? (
        products.map((product: Product) => (
          <ProductCard key={product.id} product={product} />
        ))
      ) : (
        <div
          style={{
            gridColumn: "1/-1",
            textAlign: "center",
            color: "#6366f1",
          }}
        >
          {isFetching ? "Yükleniyor..." : "Kayıt bulunamadı."}
        </div>
      )}
    </Grid>
  );
}
