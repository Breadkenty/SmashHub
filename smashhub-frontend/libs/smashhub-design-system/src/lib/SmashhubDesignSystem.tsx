import styled from '@emotion/styled';
import { Button, Paper, Typography } from '@mui/material';

/* eslint-disable-next-line */
export interface SmashhubDesignSystemProps {
  huh: string;
}

const StyledSmashhubDesignSystem = styled.div`
  /* color: pink; */
`;

export function SmashhubDesignSystem(props: SmashhubDesignSystemProps) {
  return (
    <StyledSmashhubDesignSystem>
      <Paper>
        <Typography variant="h1">Welcome to SmashhubDesignSystem!</Typography>
        <Button variant="contained" onClick={() => console.log('done it')}>
          {props.huh}
        </Button>
        <Button
          color="secondary"
          variant="contained"
          onClick={() => console.log('done it')}
        >
          {props.huh}
        </Button>
      </Paper>
    </StyledSmashhubDesignSystem>
  );
}

export default SmashhubDesignSystem;
