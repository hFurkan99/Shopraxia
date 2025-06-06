import styled from "styled-components";
import { Link, useLocation } from "react-router-dom";
import {
  FaSearch,
  FaHeart,
  FaUser,
  FaShoppingCart,
  FaBars,
  FaTimes,
} from "react-icons/fa";
import { useState } from "react";
import { createPortal } from "react-dom";

// Header Wrapper
const Navbar = styled.header`
  width: 100%;
  background: #fff;
  box-shadow: 0 2px 12px rgba(99, 102, 241, 0.08);
  padding: 0 2rem;

  @media (max-width: 600px) {
    padding: 0 0.7rem;
  }
`;

// İçerik
const NavContent = styled.div`
  max-width: 1300px;
  margin: 0 auto;
  display: flex;
  align-items: center;
  justify-content: space-between;
  height: 68px;

  @media (max-width: 900px) {
    height: auto;
    align-items: stretch;
    gap: 0.7rem;
    padding: 0.7rem 0;
  }
`;

// Sol: Logo ve Breadcrumb
const Left = styled.div`
  display: flex;
  align-items: center;
  gap: 2.5rem;

  @media (max-width: 600px) {
    gap: 1.2rem;
  }
`;

const Logo = styled(Link)`
  font-size: 2.5rem;
  font-weight: 700;
  color: #4f46e5;
  letter-spacing: 1px;
  text-decoration: none;
  margin-right: 1.5rem;

  @media (max-width: 600px) {
    font-size: 2rem;
    margin-right: 0.7rem;
  }
`;

const Breadcrumb = styled.div`
  font-size: 1.3rem;
  color: #6366f1;
  background: #f3f4f6;
  border-radius: 7px;
  padding: 0.4rem 1.2rem;
  font-weight: 500;
  box-shadow: 0 1px 4px rgba(99, 102, 241, 0.07);

  @media (max-width: 600px) {
    font-size: 1.05rem;
    padding: 0.3rem 0.7rem;
  }
`;

// Sağ: Menü ve ikonlar
const Right = styled.div`
  display: flex;
  align-items: center;
  gap: 2.5rem;

  @media (max-width: 900px) {
    justify-content: space-between;
    gap: 1.2rem;
    margin-top: 0.5rem;
  }
`;

// Menü kutusu
const MenuBox = styled.nav`
  display: flex;
  align-items: center;
  gap: 2.2rem;
  background: #f3f4f6;
  border-radius: 12px;
  box-shadow: 0 2px 12px rgba(99, 102, 241, 0.13);
  padding: 0.5rem 2.2rem;

  @media (max-width: 900px) {
    gap: 1.2rem;
    padding: 0.5rem 1rem;
  }
  @media (max-width: 600px) {
    gap: 0.7rem;
    padding: 0.4rem 0.5rem;
    border-radius: 8px;
  }
`;

const MenuLink = styled(Link)<{ $active?: boolean }>`
  color: ${({ $active }) => ($active ? "#4f46e5" : "#4b5563")};
  font-size: 1.5rem;
  font-weight: 600;
  text-decoration: none;
  padding: 0.3rem 0.7rem;
  border-radius: 6px;
  background: ${({ $active }) => ($active ? "#e0e7ff" : "transparent")};
  box-shadow: ${({ $active }) =>
    $active ? "0 2px 8px rgba(99,102,241,0.08)" : "none"};
  transition: background 0.2s, color 0.2s;
  &:hover {
    background: #e0e7ff;
    color: #4f46e5;
  }

  @media (max-width: 600px) {
    font-size: 1.1rem;
    padding: 0.2rem 0.4rem;
  }
`;

// İkonlar kutusu
const Icons = styled.div`
  display: flex;
  align-items: center;
  gap: 1.7rem;
  margin-left: 1.2rem;

  @media (max-width: 600px) {
    gap: 0.7rem;
    margin-left: 0.5rem;
  }
`;

const IconButton = styled.button`
  background: #f3f4f6;
  border: none;
  border-radius: 50%;
  padding: 0.7rem;
  display: flex;
  align-items: center;
  justify-content: center;
  box-shadow: 0 2px 8px rgba(99, 102, 241, 0.1);
  font-size: 1.5rem;
  color: #6366f1;
  transition: background 0.18s, box-shadow 0.18s;
  &:hover {
    background: #e0e7ff;
    box-shadow: 0 4px 16px rgba(99, 102, 241, 0.18);
    color: #4f46e5;
  }

  @media (max-width: 600px) {
    padding: 0.45rem;
    font-size: 1.15rem;
  }
`;

const Hamburger = styled.button`
  display: none;
  background: none;
  border: none;
  font-size: 2.3rem;
  color: #4f46e5;
  margin-left: 1.2rem;
  cursor: pointer;
  @media (max-width: 1100px) {
    display: flex;
    align-items: center;
  }
`;

const MobileMenuOverlay = styled.div`
  position: fixed;
  inset: 0;
  background: rgba(60, 60, 80, 0.18);
  z-index: 1001;
`;

const MobileMenu = styled.div`
  position: fixed;
  inset: 0;
  width: 100vw;
  height: 100vh;
  background: #fff;
  z-index: 1002;
  display: flex;
  flex-direction: column;
  padding: 2.2rem 1.2rem 1.2rem 1.2rem;
  animation: slideIn 0.22s;
  @keyframes slideIn {
    from {
      transform: translateY(100%);
    }
    to {
      transform: translateY(0);
    }
  }
`;

const MobileClose = styled.button`
  background: none;
  border: none;
  font-size: 2.2rem;
  color: #6366f1;
  align-self: flex-end;
  margin-bottom: 1.2rem;
  cursor: pointer;
`;

const MobileMenuBox = styled(MenuBox)`
  flex-direction: column;
  gap: 1.2rem;
  box-shadow: none;
  background: transparent;
  padding: 0;
  align-items: flex-start;
`;

const MobileIconList = styled.div`
  margin-top: 2.5rem;
  width: 100%;
  display: flex;
  flex-direction: column;
  gap: 1.2rem;
`;

const MobileIconItem = styled.button`
  width: 100%;
  background: #f3f4f6;
  border: none;
  border-radius: 10px;
  padding: 1.1rem 1.2rem;
  display: flex;
  align-items: center;
  gap: 1.1rem;
  font-size: 1.25rem;
  color: #4f46e5;
  font-weight: 600;
  box-shadow: 0 2px 12px rgba(99, 102, 241, 0.1);
  transition: background 0.18s, box-shadow 0.18s, color 0.18s;
  cursor: pointer;

  &:hover {
    background: #e0e7ff;
    color: #3730a3;
    box-shadow: 0 4px 16px rgba(99, 102, 241, 0.18);
  }

  svg {
    font-size: 1.6rem;
    color: #6366f1;
    flex-shrink: 0;
    transition: color 0.18s;
  }
`;

const MobileSearchWrapper = styled.div`
  width: 100%;
  margin-bottom: 2rem;
  display: flex;
  align-items: center;
  background: #f3f4f6;
  border-radius: 8px;
  padding: 0.7rem 1rem;
`;

const MobileSearchInput = styled.input`
  border: none;
  background: transparent;
  font-size: 1.2rem;
  flex: 1;
  outline: none;
  color: #374151;
`;

const MobileSearchIcon = styled(FaSearch)`
  color: #6366f1;
  font-size: 1.5rem;
  margin-right: 0.7rem;
`;

function getBreadcrumb(pathname: string) {
  const parts = pathname
    .split("/")
    .filter(Boolean)
    .map((p) => p.charAt(0).toUpperCase() + p.slice(1));
  return parts.length ? parts.join(" / ") : "Home";
}

export default function Header() {
  const location = useLocation();
  const [mobileOpen, setMobileOpen] = useState(false);

  // Kapanınca scroll'u aç
  if (typeof window !== "undefined") {
    document.body.style.overflow = mobileOpen ? "hidden" : "";
  }

  return (
    <>
      <Navbar>
        <NavContent>
          <Left>
            <Logo to="/">Shopraxia</Logo>
            <Breadcrumb>{getBreadcrumb(location.pathname)}</Breadcrumb>
          </Left>
          <Right>
            <MenuBox className="desktop-menu">
              <MenuLink
                to="/men"
                $active={location.pathname.startsWith("/men")}
              >
                Men
              </MenuLink>
              <MenuLink
                to="/women"
                $active={location.pathname.startsWith("/women")}
              >
                Women
              </MenuLink>
              <MenuLink
                to="/kids"
                $active={location.pathname.startsWith("/kids")}
              >
                Kids
              </MenuLink>
              <MenuLink
                to="/support"
                $active={location.pathname.startsWith("/support")}
              >
                Support
              </MenuLink>
            </MenuBox>
            <Icons className="desktop-icons">
              <IconButton aria-label="Ara">
                <FaSearch />
              </IconButton>
              <IconButton aria-label="İstek Listesi">
                <FaHeart />
              </IconButton>
              <IconButton aria-label="Profilim">
                <FaUser />
              </IconButton>
              <IconButton aria-label="Sepetim">
                <FaShoppingCart />
              </IconButton>
            </Icons>
            <Hamburger
              aria-label="Menüyü Aç"
              onClick={() => setMobileOpen(true)}
            >
              <FaBars />
            </Hamburger>
          </Right>
        </NavContent>
      </Navbar>
      {/* Mobil Menü */}
      {mobileOpen &&
        createPortal(
          <>
            <MobileMenuOverlay onClick={() => setMobileOpen(false)} />
            <MobileMenu>
              <MobileClose onClick={() => setMobileOpen(false)}>
                <FaTimes />
              </MobileClose>
              <MobileSearchWrapper>
                <MobileSearchIcon />
                <MobileSearchInput placeholder="Ara..." />
              </MobileSearchWrapper>
              <MobileMenuBox>
                <MenuLink
                  to="/men"
                  $active={location.pathname.startsWith("/men")}
                  onClick={() => setMobileOpen(false)}
                >
                  Men
                </MenuLink>
                <MenuLink
                  to="/women"
                  $active={location.pathname.startsWith("/women")}
                  onClick={() => setMobileOpen(false)}
                >
                  Women
                </MenuLink>
                <MenuLink
                  to="/kids"
                  $active={location.pathname.startsWith("/kids")}
                  onClick={() => setMobileOpen(false)}
                >
                  Kids
                </MenuLink>
                <MenuLink
                  to="/support"
                  $active={location.pathname.startsWith("/support")}
                  onClick={() => setMobileOpen(false)}
                >
                  Support
                </MenuLink>
              </MobileMenuBox>
              <MobileIconList>
                <MobileIconItem>
                  <FaHeart />
                  İstek Listesi
                </MobileIconItem>
                <MobileIconItem>
                  <FaUser />
                  Profilim
                </MobileIconItem>
                <MobileIconItem>
                  <FaShoppingCart />
                  Sepetim
                </MobileIconItem>
              </MobileIconList>
            </MobileMenu>
          </>,
          document.body
        )}
      <style>
        {`
        @media (max-width: 1100px) {
          .desktop-menu, .desktop-icons { display: none !important; }
        }
        @media (min-width: 1101px) {
          .desktop-menu, .desktop-icons { display: flex !important; }
          button[aria-label="Menüyü Aç"] { display: none !important; }
        }
        `}
      </style>
    </>
  );
}
