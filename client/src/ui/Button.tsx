import styled, { css } from "styled-components";
import React from "react";

type ButtonVariant = "primary" | "secondary" | "danger" | "ghost";
type ButtonSize = "sm" | "md" | "lg";

interface ButtonProps extends React.ButtonHTMLAttributes<HTMLButtonElement> {
  variant?: ButtonVariant;
  size?: ButtonSize;
  fullWidth?: boolean;
  leftIcon?: React.ReactNode;
  rightIcon?: React.ReactNode;
  loading?: boolean;
}

const variantStyles = {
  primary: css`
    background: linear-gradient(90deg, #4f46e5 0%, #6366f1 100%);
    color: #fff;
    border: none;
    &:hover {
      background: linear-gradient(90deg, #6366f1 0%, #4f46e5 100%);
      box-shadow: 0 4px 16px rgba(99, 102, 241, 0.15);
    }
  `,
  secondary: css`
    background: #fff;
    color: #4f46e5;
    border: 2px solid #4f46e5;
    &:hover {
      background: #f3f4f6;
      color: #3730a3;
      border-color: #3730a3;
    }
  `,
  danger: css`
    background: #ef4444;
    color: #fff;
    border: none;
    &:hover {
      background: #dc2626;
      box-shadow: 0 4px 16px rgba(239, 68, 68, 0.15);
    }
  `,
  ghost: css`
    background: transparent;
    color: #4b5563;
    border: 2px solid transparent;
    &:hover {
      background: #f3f4f6;
      color: #4f46e5;
      border-color: #6366f1;
    }
  `,
};

const sizeStyles = {
  sm: css`
    font-size: 1.3rem;
    padding: 0.4rem 1.2rem;
    border-radius: 5px;
  `,
  md: css`
    font-size: 1.6rem;
    padding: 0.7rem 2rem;
    border-radius: 7px;
  `,
  lg: css`
    font-size: 2rem;
    padding: 1rem 2.8rem;
    border-radius: 9px;
  `,
};

const StyledButton = styled.button<ButtonProps>`
  display: inline-flex;
  align-items: center;
  justify-content: center;
  gap: 0.7em;
  font-family: inherit;
  font-weight: 600;
  cursor: pointer;
  transition: all 0.2s;
  outline: none;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.04);
  width: ${({ fullWidth }) => (fullWidth ? "100%" : "auto")};
  ${({ variant = "primary" }) => variantStyles[variant]}
  ${({ size = "md" }) => sizeStyles[size]}
  &:disabled {
    opacity: 0.6;
    cursor: not-allowed;
    box-shadow: none;
  }
`;

export const Button: React.FC<ButtonProps> = ({
  children,
  variant = "primary",
  size = "md",
  fullWidth = false,
  leftIcon,
  rightIcon,
  loading = false,
  ...rest
}) => {
  return (
    <StyledButton
      variant={variant}
      size={size}
      fullWidth={fullWidth}
      disabled={loading || rest.disabled}
      {...rest}
    >
      <span
        style={{
          display: "inline-flex",
          alignItems: "center",
          justifyContent: "center",
          width: "100%",
        }}
      >
        {leftIcon && (
          <span
            style={{
              display: "inline-flex",
              alignItems: "center",
              marginRight: 6,
            }}
          >
            {leftIcon}
          </span>
        )}
        <span
          style={{
            flex: 1,
            textAlign: "center",
            minWidth: 0,
            whiteSpace: "nowrap",
            display: "inline-block",
          }}
        >
          {children}
        </span>
        {rightIcon && (
          <span
            style={{
              display: "inline-flex",
              alignItems: "center",
              marginLeft: 6,
            }}
          >
            {rightIcon}
          </span>
        )}
      </span>
    </StyledButton>
  );
};
