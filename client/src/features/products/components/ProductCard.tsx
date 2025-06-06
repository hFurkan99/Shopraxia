import styled from "styled-components";
import type { Product } from "../types/Product";
import { FaRegHeart, FaStar } from "react-icons/fa";

const Container = styled.div`
  display: flex;
  flex-direction: column;
  margin-bottom: 2rem;
`;

const Card = styled.div`
  background: #f5f4f1;
  box-shadow: 0 2px 4px rgba(99, 102, 241, 0.08);
  padding: 9.2rem 2.2rem 3.5rem 2.2rem;
  display: flex;
  flex-direction: column;
  align-items: center;
  position: relative;
  transition: box-shadow 0.2s;
  box-sizing: border-box;
  justify-content: flex-start;
  overflow: hidden;
  margin-bottom: 1.2rem;

  &:hover {
    box-shadow: 0 4px 16px rgba(99, 102, 241, 0.15);
    transform: translateY(-2px) scale(1.02);
    cursor: pointer;
  }
`;

const FavButton = styled.button`
  position: absolute;
  top: 1.1rem;
  right: 1.1rem;
  z-index: 2;
  border: none;
  padding: 0.6rem;
  color: #6366f1;
  background: transparent;
  font-size: 1.6rem;
`;

const Img = styled.img`
  width: 300px;
  height: 300px;
  box-shadow: 0 1px 4px rgba(99, 102, 241, 0.06);
  z-index: 1;
  pointer-events: none;
  padding-top: 1.8rem;
  margin-bottom: 1.6rem;
`;

const Info = styled.div`
  display: flex;
  align-items: center;
  justify-content: space-between;
  font-size: 1.4rem;
  padding: 0 1.2rem;
  width: 100%;
  gap: 4rem;
`;

const BrandName = styled.h3`
  font-size: 1.4rem;
  font-weight: 500;
  color: #1f2937;
  display: -webkit-box;
  -webkit-line-clamp: 1;
  -webkit-box-orient: vertical;
  overflow: hidden;
  text-overflow: ellipsis;
  word-break: break-word;
`;

const RatingBox = styled.div`
  display: flex;
  align-items: center;
  gap: 0.4rem;
  color: #fbbf24;
  font-size: 1.2rem;
`;

const ReviewCount = styled.span`
  color: #6b7280;
  font-size: 1.2rem;
  margin-left: 0.5rem;
`;

const Title = styled.h3`
  font-size: 1.4rem;
  font-weight: 500;
  color: #1f2937;
  display: -webkit-box;
  -webkit-line-clamp: 1;
  -webkit-box-orient: vertical;
  overflow: hidden;
  text-overflow: ellipsis;
  word-break: break-word;
`;

const Price = styled.span`
  font-size: 1.4rem;
  font-weight: 500;
  color: #1f2937;
`;

type ProductCardProps = {
  product: Product;
};

export default function ProductCard({ product }: ProductCardProps) {
  return (
    <Container>
      <Card>
        <FavButton aria-label="Favorilere ekle">
          <FaRegHeart />
        </FavButton>
        <Img src={`https://picsum.photos/300/200`} alt={product.name} />
        <Info>
          <BrandName>{product.brand?.name ?? "Marka Bilgisi Yok"}</BrandName>
          <RatingBox>
            <FaStar />
            <span>{product.rating ?? "4.7"}</span>
            <ReviewCount>(1223)</ReviewCount>
          </RatingBox>
        </Info>
      </Card>
      <Info>
        <Title>{product.name}</Title>
        <Price>{product.variants?.[0]?.price ?? "-"}₺</Price>
      </Info>
    </Container>
  );
}
