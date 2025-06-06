import styled from "styled-components";
import { useParams, useNavigate } from "react-router-dom";
import useProductBySlug from "../hooks/useProductBySlug";
import { FaArrowLeft, FaStar, FaRegHeart } from "react-icons/fa";
import { Button } from "../../../ui/Button";
import { useState, useMemo } from "react";

const Wrapper = styled.div`
  max-width: 1100px;
  margin: 0 auto;
  background: #fff;
  border-radius: 22px;
  box-shadow: 0 6px 36px rgba(99, 102, 241, 0.13);
  padding: 3.5rem 3rem 2.5rem 3rem;
  display: flex;
  flex-direction: column;
  gap: 2.5rem;
  margin-top: 2.5rem;
  margin-bottom: 2.5rem;
  @media (max-width: 900px) {
    padding: 1.2rem 0.5rem;
    margin-top: 1.2rem;
    margin-bottom: 1.2rem;
  }
`;

const TopBar = styled.div`
  display: flex;
  align-items: center;
  gap: 1.2rem;
`;

const BackButton = styled(Button)`
  font-size: 1.3rem;
  padding: 0.5rem 1.2rem;
`;

const Content = styled.div`
  display: flex;
  gap: 4.5rem;
  align-items: flex-start;
  @media (max-width: 1100px) {
    gap: 2.5rem;
  }
  @media (max-width: 900px) {
    flex-direction: column;
    gap: 2rem;
  }
`;

const ImageBox = styled.div`
  flex: 1 1 350px;
  display: flex;
  align-items: center;
  justify-content: center;
  background: linear-gradient(120deg, #f3f4f6 60%, #e0e7ff 100%);
  border-radius: 18px;
  min-height: 320px;
  max-height: 440px;
  overflow: hidden;
  box-shadow: 0 2px 12px rgba(99, 102, 241, 0.08);
`;

const Img = styled.img`
  width: 100%;
  max-width: 370px;
  max-height: 410px;
  object-fit: contain;
  border-radius: 14px;
  box-shadow: 0 2px 12px rgba(99, 102, 241, 0.1);
`;

const Details = styled.div`
  flex: 2 1 400px;
  display: flex;
  flex-direction: column;
  gap: 1.7rem;
  min-width: 0;
`;

const Title = styled.h2`
  font-size: 2.5rem;
  font-weight: 700;
  color: #1f2937;
  margin-bottom: 0.5rem;
  line-height: 1.2;
  @media (max-width: 600px) {
    font-size: 2rem;
  }
`;

const Brand = styled.div`
  font-size: 1.25rem;
  color: #6366f1;
  font-weight: 600;
  margin-bottom: 0.5rem;
  letter-spacing: 0.5px;
`;

const RatingBox = styled.div`
  display: flex;
  align-items: center;
  gap: 0.5rem;
  color: #fbbf24;
  font-size: 1.3rem;
`;

const SelectRow = styled.div`
  display: flex;
  gap: 2.2rem;
  flex-wrap: wrap;
  align-items: center;
  margin: 1.2rem 0 0.7rem 0;
`;

const SelectBox = styled.div`
  display: flex;
  flex-direction: column;
  gap: 0.7rem;
`;

const SelectLabel = styled.label`
  font-size: 1.1rem;
  color: #6b7280;
  font-weight: 500;
  margin-bottom: 0.2rem;
`;

const OptionList = styled.div`
  display: flex;
  gap: 0.7rem;
  flex-wrap: wrap;
`;

const ColorOption = styled.button<{ $selected?: boolean; $color?: string }>`
  width: 2.2rem;
  height: 2.2rem;
  border-radius: 50%;
  border: 2px solid ${({ $selected }) => ($selected ? "#4f46e5" : "#e5e7eb")};
  background: ${({ $color }) => $color || "#f3f4f6"};
  box-shadow: 0 1px 4px rgba(99, 102, 241, 0.08);
  cursor: pointer;
  outline: none;
  transition: border 0.18s;
  position: relative;
  &:after {
    content: "";
    display: ${({ $selected }) => ($selected ? "block" : "none")};
    position: absolute;
    top: 50%;
    left: 50%;
    width: 1.1rem;
    height: 1.1rem;
    background: rgba(79, 70, 229, 0.18);
    border-radius: 50%;
    transform: translate(-50%, -50%);
  }
`;

const SizeOption = styled.button<{ $selected?: boolean }>`
  min-width: 2.7rem;
  padding: 0.3rem 1.1rem;
  border-radius: 7px;
  border: 2px solid ${({ $selected }) => ($selected ? "#4f46e5" : "#e5e7eb")};
  background: ${({ $selected }) => ($selected ? "#e0e7ff" : "#f3f4f6")};
  color: ${({ $selected }) => ($selected ? "#4f46e5" : "#1f2937")};
  font-weight: 600;
  font-size: 1.15rem;
  cursor: pointer;
  transition: all 0.18s;
`;

const Price = styled.div`
  font-size: 2.1rem;
  font-weight: 700;
  color: #4f46e5;
  margin: 1.2rem 0 0.7rem 0;
`;

const Desc = styled.p`
  font-size: 1.18rem;
  color: #374151;
  line-height: 1.7;
  background: #f9fafb;
  border-radius: 8px;
  padding: 1.2rem 1.2rem 1.2rem 1.2rem;
`;

const FavButton = styled.button`
  background: #fff;
  border: 1.5px solid #e0e7ff;
  border-radius: 50%;
  padding: 0.7rem;
  color: #6366f1;
  font-size: 1.7rem;
  box-shadow: 0 2px 8px rgba(99, 102, 241, 0.08);
  margin-left: 1.2rem;
  transition: background 0.18s, color 0.18s;
  &:hover {
    background: #e0e7ff;
    color: #4f46e5;
  }
`;

export default function ProductDetails() {
  const { slug } = useParams();
  const navigate = useNavigate();
  const { product, isFetching, error } = useProductBySlug(slug!);

  // Variant attribute'larından renk ve bedenleri çıkar
  const colorOptions = useMemo(() => {
    const set = new Set<string>();
    product?.variants?.forEach((v) => {
      v.attributes?.forEach((attr) => {
        if (
          attr.name.toLowerCase() === "renk" ||
          attr.name.toLowerCase() === "color"
        )
          set.add(attr.value);
      });
    });
    return Array.from(set);
  }, [product]);

  const sizeOptions = useMemo(() => {
    const set = new Set<string>();
    product?.variants?.forEach((v) => {
      v.attributes?.forEach((attr) => {
        if (
          attr.name.toLowerCase() === "beden" ||
          attr.name.toLowerCase() === "size"
        )
          set.add(attr.value);
      });
    });
    return Array.from(set);
  }, [product]);

  const [selectedColor, setSelectedColor] = useState<string | null>(null);
  const [selectedSize, setSelectedSize] = useState<string | null>(null);
  const [addCartLoading, setAddCartLoading] = useState(false);

  // Seçilen renk ve beden ile uygun variantı bul
  const selectedVariant = useMemo(() => {
    if (!selectedColor || !selectedSize) return undefined;
    return product?.variants?.find((v) => {
      let hasColor = false,
        hasSize = false;
      v.attributes?.forEach((attr) => {
        if (
          (attr.name.toLowerCase() === "renk" ||
            attr.name.toLowerCase() === "color") &&
          attr.value === selectedColor
        )
          hasColor = true;
        if (
          (attr.name.toLowerCase() === "beden" ||
            attr.name.toLowerCase() === "size") &&
          attr.value === selectedSize
        )
          hasSize = true;
      });
      return hasColor && hasSize;
    });
  }, [product, selectedColor, selectedSize]);

  if (isFetching) return <Wrapper>Yükleniyor...</Wrapper>;
  if (error || !product) return <Wrapper>Ürün bulunamadı.</Wrapper>;

  // Seçili variantın görseli veya fallback
  const imageUrl =
    selectedVariant?.images?.[0]?.url ||
    product.variants?.[0]?.images?.[0]?.url ||
    `https://picsum.photos/400/300`;

  // Sepete ekle butonu aktiflik kontrolü
  const canAddToCart = !!(
    product.brand?.name &&
    selectedColor &&
    selectedSize &&
    selectedVariant
  );

  // Renk için basit renk eşlemesi (örnek)
  const colorMap: Record<string, string> = {
    siyah: "#222",
    beyaz: "#fff",
    kırmızı: "#ef4444",
    mavi: "#3b82f6",
    yeşil: "#22c55e",
    gri: "#6b7280",
    mor: "#a78bfa",
    pembe: "#f472b6",
    sarı: "#fde047",
    turuncu: "#fb923c",
    // ...
  };

  // Sepete ekle simülasyonu
  const handleAddToCart = () => {
    if (!canAddToCart) return;
    setAddCartLoading(true);
    setTimeout(() => {
      setAddCartLoading(false);
      alert(
        `Sepete eklendi: ${product.name} - ${selectedColor} - ${selectedSize}`
      );
    }, 900);
  };

  return (
    <Wrapper>
      <TopBar>
        <BackButton
          leftIcon={<FaArrowLeft />}
          variant="secondary"
          onClick={() => navigate(-1)}
        >
          Geri
        </BackButton>
      </TopBar>
      <Content>
        <ImageBox>
          <Img src={imageUrl} alt={product.name} />
        </ImageBox>
        <Details>
          <Title>{product.name}</Title>
          <Brand>{product.brand?.name ?? "Marka Bilgisi Yok"}</Brand>
          <RatingBox>
            <FaStar />
            <span>{product.rating ?? "4.7"}</span>
            <span
              style={{ color: "#6b7280", fontSize: "1.1rem", marginLeft: 6 }}
            >
              ({123})
            </span>
            <FavButton aria-label="Favorilere ekle">
              <FaRegHeart />
            </FavButton>
          </RatingBox>

          <SelectRow>
            <SelectBox>
              <SelectLabel>Renk</SelectLabel>
              <OptionList>
                {colorOptions.length === 0 && (
                  <span style={{ color: "#aaa" }}>Yok</span>
                )}
                {colorOptions.map((color) => (
                  <ColorOption
                    key={color}
                    $selected={selectedColor === color}
                    $color={colorMap[color.toLowerCase()] || "#f3f4f6"}
                    onClick={() => setSelectedColor(color)}
                    aria-label={color}
                  />
                ))}
              </OptionList>
            </SelectBox>
            <SelectBox>
              <SelectLabel>Beden</SelectLabel>
              <OptionList>
                {sizeOptions.length === 0 && (
                  <span style={{ color: "#aaa" }}>Yok</span>
                )}
                {sizeOptions.map((size) => (
                  <SizeOption
                    key={size}
                    $selected={selectedSize === size}
                    onClick={() => setSelectedSize(size)}
                  >
                    {size}
                  </SizeOption>
                ))}
              </OptionList>
            </SelectBox>
          </SelectRow>

          <Price>
            {selectedVariant?.price ?? product.variants?.[0]?.price ?? "-"}₺
          </Price>

          <Button
            variant="primary"
            size="lg"
            fullWidth
            style={{
              margin: "1.2rem 0 0.7rem 0",
              fontSize: "1.25rem",
              letterSpacing: 0.5,
            }}
            disabled={!canAddToCart || addCartLoading}
            onClick={handleAddToCart}
          >
            {addCartLoading ? "Sepete Ekleniyor..." : "Sepete Ekle"}
          </Button>

          <Desc>{product.description ?? "Açıklama bulunamadı."}</Desc>
        </Details>
      </Content>
    </Wrapper>
  );
}
