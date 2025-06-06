import { Outlet } from "react-router-dom";
import styled from "styled-components";
import Header from "./Header";

const LayoutWrapper = styled.div`
  min-height: 100vh;
  display: flex;
  flex-direction: column;
  background: var(--color-grey-50, #f9fafb);
`;

const Main = styled.main`
  flex: 1;
  width: 100%;
  max-width: 1300px;
  margin: 0 auto;
  padding: 2.5rem 1.5rem 3rem 1.5rem;
  display: flex;
  flex-direction: column;
  align-items: stretch;
`;

const Footer = styled.footer`
  background: #fff;
  color: #6366f1;
  text-align: center;
  padding: 1.2rem 0 1.5rem 0;
  font-size: 1.3rem;
  border-top: 1px solid #e5e7eb;
  letter-spacing: 0.5px;
`;

export default function AppLayout() {
  return (
    <LayoutWrapper>
      <Header />
      <Main>
        <Outlet />
      </Main>
      <Footer>
        &copy; {new Date().getFullYear()} Shopraxia. All rights reserved.
      </Footer>
    </LayoutWrapper>
  );
}
