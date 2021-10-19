import { Box, styled } from '@mui/material';

export const StyledCharacterCard = styled(Box)(({ theme }) => {
  return {
    border: `1px solid ${theme.palette.divider}`,
    height: theme.spacing(12),
    display: 'flex',
    alignItems: 'center',
    position: 'relative',
    overflow: 'hidden',

    h1: {
      color: theme.palette.text.primary,
      textAlign: 'center',
      zIndex: theme.zIndex.drawer,
      position: 'absolute',
      width: '40%',
      marginLeft: theme.spacing(2),
      textShadow: '3px 3px 8px rgba(0,0,0,0.5)',
    },

    '>div': {
      position: 'absolute',
      right: '0',
      [theme.breakpoints.up('sm')]: {
        right: '10%',
      },
      margin: theme.spacing(0, 2),
      backgroundPosition: 'center',
      backgroundSize: '100% auto',
      backgroundRepeat: 'no-repeat',
      maxWidth: '280px',
      width: '50%',
      height: '100%',
    },
  };
});