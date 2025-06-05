import styled from "styled-components";
import type { Product } from "../types/Product";

const Card = styled.div`
  background: #fff;
  border-radius: 12px;
  box-shadow: 0 2px 8px rgba(99, 102, 241, 0.08);
  padding: 1.2rem 1.2rem 1.5rem 1.2rem;
  display: flex;
  flex-direction: column;
  align-items: center;
  gap: 0.7rem;
  transition: box-shadow 0.2s;
  &:hover {
    box-shadow: 0 4px 16px rgba(99, 102, 241, 0.15);
    transform: translateY(-2px) scale(1.02);
  }
`;

const Img = styled.img`
  width: 120px;
  height: 120px;
  object-fit: cover;
  border-radius: 8px;
  background: #f3f4f6;
  margin-bottom: 0.7rem;
`;

const Title = styled.h3`
  font-size: 2.1rem;
  font-weight: 700;
  color: #3730a3;
  margin: 0;
  text-align: center;
`;

const Desc = styled.p`
  color: #4b5563;
  font-size: 1.6rem;
  margin: 0;
  text-align: center;
`;

const Info = styled.div`
  display: flex;
  gap: 1.2rem;
  font-size: 1.4rem;
  color: #6366f1;
  justify-content: center;
  margin-top: 0.5rem;
`;

type ProductCardProps = {
  product: Product;
};

export default function ProductCard({ product }: ProductCardProps) {
  return (
    <Card>
      <Img src={`https://picsum.photos/200/300`} alt={product.name} />
      <Title>{product.name}</Title>
      <Desc>{product.description}</Desc>
      <Info>
        <span>Kategori: {product.categoryId ?? "-"}</span>
        <span>Marka: {product.brandId ?? "-"}</span>
        <span>Fiyat: {product.variants[0]?.price ?? "-"}₺</span>
      </Info>
    </Card>
  );
}
