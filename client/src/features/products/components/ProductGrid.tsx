import styled from "styled-components";
import { useProducts } from "../hooks/useProducts";
import type { Product } from "../types/Product";
import { useNavigate } from "react-router-dom";
import ProductCard from "./ProductCard";

const Grid = styled.div`
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(300px, 1fr));
  gap: 1rem;
  row-gap: 6rem;
`;

export default function ProductGrid() {
  const payload = {
    page: 1,
    pageSize: 30,
    sortBy: "name",
    sortOrder: "desc",
  } as const;
  const { isFetching, products } = useProducts(payload);
  const navigate = useNavigate();

  const handleCardClick = (product: Product) => {
    if (product.slug) {
      navigate(`/products/${product.slug}`);
    } else {
      navigate(`/products/id/${product.id}`);
    }
  };

  return (
    <Grid>
      {products && products.length > 0 ? (
        products.map((product: Product) => (
          <div key={product.id} style={{ height: "100%" }}>
            <div
              style={{ height: "100%", cursor: "pointer" }}
              onClick={() => handleCardClick(product)}
            >
              <ProductCard product={product} />
            </div>
          </div>
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
