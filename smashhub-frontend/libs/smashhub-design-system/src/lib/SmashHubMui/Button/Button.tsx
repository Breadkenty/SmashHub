import styled from '@emotion/styled';
import {
  Button as MuiButton,
  ButtonProps as MuiButtonProps,
} from '@mui/material';

/* eslint-disable-next-line */
export interface ButtonProps extends MuiButtonProps {
  className?: string;
}

const StyledButton = styled.div``;

export function Button(props: ButtonProps) {
  return (
    <StyledButton className={props.className}>
      <MuiButton {...props}>{props.children}</MuiButton>
    </StyledButton>
  );
}

export default Button;
