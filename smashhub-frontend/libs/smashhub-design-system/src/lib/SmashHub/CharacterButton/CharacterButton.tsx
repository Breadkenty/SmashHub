import constants from '../../utils/constants.json';
import { StyledCharacterButton } from './CharacterButton.styles';

/* eslint-disable-next-line */
export interface CharacterButtonProps {
  variableName: string;
}

export function CharacterButton(props: CharacterButtonProps) {
  return (
    <StyledCharacterButton
      style={{
        backgroundImage: `url(${constants.imageBaseUrl}/character-emblem/${props.variableName}-emblem.png)`,
      }}
    ></StyledCharacterButton>
  );
}

export default CharacterButton;
