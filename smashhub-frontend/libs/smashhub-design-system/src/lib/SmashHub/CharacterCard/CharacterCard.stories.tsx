import { Story, Meta } from '@storybook/react';
import {
  CharacterCard as CharacterCardComponent,
  CharacterCardProps,
} from './CharacterCard';
import mock from '../../utils/mocks/characters.json';

const getCharacter = (characterName: string) =>
  mock.characters.find((character) => character.name === characterName);

export default {
  component: CharacterCardComponent,
  title: 'SmashHub/Character Card',
  argTypes: {
    character: {
      options: mock.characters.map((character) => character.name),
      control: { type: 'select' },
    },
    name: { control: false },
    variableName: { control: false },
  },
} as Meta;

export const CharacterCard: Story = (args) => {
  return (
    <div style={{ maxWidth: '1000px' }}>
      <CharacterCardComponent
        name={getCharacter(args.character)?.name || ''}
        variableName={getCharacter(args.character)?.variableName || ''}
        yPosition={
          args.yPosition === 0
            ? 0
            : args.yPosition || getCharacter(args.character)?.yPosition
        }
      />
    </div>
  );
};

CharacterCard.args = {
  character: 'Zero Suit Samus'
}
