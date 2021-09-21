import { Story, Meta } from '@storybook/react';
import { Button as ButtonComponent, ButtonProps } from './Button';

export default {
  component: ButtonComponent,
  title: 'SmashHub Mui/Button',
} as Meta;

export const Button: Story<ButtonProps> = (args) => (
  <ButtonComponent {...args}>{args.children}</ButtonComponent>
);

Button.args = {
  children: 'Submit',
  variant: 'outlined',
};
