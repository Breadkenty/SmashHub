import { Box, styled } from '@mui/material';

export const StyledCharacterButton = styled(Box)(({ theme }) => {
  return {
    width: '100px',
    height: '100px',
    borderRadius: 50,
    border: '.25rem solid white',
    backgroundPosition: 'center',
    backgroundSize: 100,
    backgroundRepeat: 'no-repeat',
    transition: `${theme.transitions.create('all', {
      duration: theme.transitions.duration.short,
      easing: theme.transitions.easing.easeInOut,
    })}`,

    ':hover': {
      transform: 'scale(1.1)',
      backgroundColor: theme.palette.primary.main,
    },
  };
});
