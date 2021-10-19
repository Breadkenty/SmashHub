import { Story, Meta } from '@storybook/react';
import {
  CharacterButton as CharacterButtonComponent,
  CharacterButtonProps,
} from './CharacterButton';
import mock from '../../utils/mocks/characters.json';

const getCharacter = (characterName: string) =>
  mock.characters.find((character) => character.name === characterName);

export default {
  component: CharacterButtonComponent,
  title: 'SmashHub/Character Button',
  argTypes: {
    character: {
      options: mock.characters.map((character) => character.name),
      control: { type: 'select' },
    },
    variableName: { control: false },
  },
} as Meta;

export const CharacterButton: Story = (args) => {
  return (
    <CharacterButtonComponent
      variableName={getCharacter(args.character)?.variableName || ''}
    />
  );
};

CharacterButton.args = {
  character: 'Zero Suit Samus',
};
