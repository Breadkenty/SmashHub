import styled from 'styled-components';
import Button from '@mui/material/Button';

/* eslint-disable-next-line */
export interface ButtonProps {
  header: string;
}

const StyledButton = styled.div`
  color: pink;
`;

export function Button(props: ButtonProps) {
  return (
    <StyledButton>
      <Button variant="text">Text</Button>
      <Button variant="contained">Contained</Button>
      <Button variant="outlined">Outlined</Button>
    </StyledButton>
  );
}

export default Button;
