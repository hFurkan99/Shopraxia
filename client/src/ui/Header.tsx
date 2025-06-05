import styled from "styled-components";
import { Link, useLocation } from "react-router-dom";

const Navbar = styled.header`
  width: 100%;
  background: linear-gradient(90deg, #4f46e5 0%, #6366f1 100%);
  color: #fff;
  box-shadow: 0 2px 8px rgba(99, 102, 241, 0.08);
  padding: 0 2rem;
`;

const NavContent = styled.div`
  max-width: 1200px;
  margin: 0 auto;
  display: flex;
  align-items: center;
  justify-content: space-between;
  height: 64px;
`;

const Logo = styled(Link)`
  font-size: 3rem;
  font-weight: 700;
  color: #fff;
  letter-spacing: 1px;
  text-decoration: none;
  transition: opacity 0.2s;
  &:hover {
    opacity: 0.8;
  }
`;

const NavLinks = styled.nav`
  display: flex;
  gap: 2.2rem;
`;

const NavLink = styled(Link)<{ $active?: boolean }>`
  color: #fff;
  font-size: 1.6rem;
  font-weight: 500;
  text-decoration: none;
  opacity: ${({ $active }) => ($active ? 1 : 0.7)};
  border-bottom: 2px solid
    ${({ $active }) => ($active ? "#fff" : "transparent")};
  padding-bottom: 2px;
  transition: opacity 0.2s, border-color 0.2s;
  &:hover {
    opacity: 1;
    border-color: #fff;
  }
`;

export default function Header() {
  const location = useLocation();
  return (
    <Navbar>
      <NavContent>
        <Logo to="/">Shopraxia</Logo>
        <NavLinks>
          <NavLink
            to="/products"
            $active={location.pathname.startsWith("/products")}
          >
            Ürünler
          </NavLink>
          <NavLink
            to="/categories"
            $active={location.pathname.startsWith("/categories")}
          >
            Kategoriler
          </NavLink>
          <NavLink
            to="/brands"
            $active={location.pathname.startsWith("/brands")}
          >
            Markalar
          </NavLink>
          {/* Diğer menüler eklenebilir */}
        </NavLinks>
      </NavContent>
    </Navbar>
  );
}
