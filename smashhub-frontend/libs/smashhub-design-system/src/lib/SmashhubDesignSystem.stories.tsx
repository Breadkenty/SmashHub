import { Story, Meta } from '@storybook/react';
import {
  SmashhubDesignSystem,
  SmashhubDesignSystemProps,
} from './SmashhubDesignSystem';

export default {
  component: SmashhubDesignSystem,
  title: 'SmashhubDesignSystem',
} as Meta;

export const Huh: Story<SmashhubDesignSystemProps> = (args) => (
  <SmashhubDesignSystem {...args} />
);

Huh.args = {
  huh: 'hih',
}

Huh.parameters = {
  design: {
    type: 'figma',
    url: 'https://www.figma.com/file/LKQ4FJ4bTnCSjedbRpk931/Sample-File',
  },
}