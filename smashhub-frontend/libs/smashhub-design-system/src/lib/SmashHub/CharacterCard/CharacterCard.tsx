import { Typography } from '@mui/material';
import constants from '../../utils/constants.json';
import { StyledCharacterCard } from './CharacterCard.styles';

/* eslint-disable-next-line */
export interface CharacterCardProps {
  name: string;
  variableName: string;
  yPosition: number;
}

export function CharacterCard(props: CharacterCardProps) {
  return (
    <StyledCharacterCard component="div">
      <Typography variant="h1">{props.name}</Typography>
      <div
        data-testid="character-image"
        style={{
          backgroundImage: `url(${constants.imageBaseUrl}/character-portrait/${props.variableName}-portrait.png)`,
          backgroundPositionY: `${props.yPosition}%`,
        }}
      ></div>
    </StyledCharacterCard>
  );
}

export default CharacterCard;
