import { addDecorator } from '@storybook/react';
import { withConsole } from '@storybook/addon-console';
import { ThemeProvider } from '@mui/material/styles';
import theme from '../src/styles/theme';

export const parameters = {
  darkMode: {
    current: 'dark',
  },
};

addDecorator((storyFn, context) => (
  <ThemeProvider theme={theme}>{withConsole()(storyFn)(context)}</ThemeProvider>
));
