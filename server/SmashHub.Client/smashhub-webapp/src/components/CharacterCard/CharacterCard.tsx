import { Typography, Box } from "@material-ui/core";
import useCharacterCardStyles from "./CharacterCard.styles";
import parameters from "../../constants.json";
import { ICharacter } from "../../models/Characters.types";
import clsx from "clsx";

export interface CharacterCardProps extends React.DetailedHTMLProps<React.HTMLAttributes<HTMLDivElement>, HTMLDivElement>{
  character: ICharacter;
}

function CharacterCard(props: CharacterCardProps) {
  const classes = useCharacterCardStyles();
  const character = props.character;

  return (
    <Box className={clsx(classes.root, props.className)} border={1} borderColor="divider">
      <Typography variant="h1" color="textPrimary" className={classes.title}>
        {character.name}
      </Typography>
      <div
        className={classes.character}
        style={{
          backgroundImage: `url(${parameters.imagePrefix}/character-portrait/${character.variableName}-portrait.png)`,
          backgroundPositionY: `${character.yPosition}%`,
        }}
      />
    </Box>
  );
}

export default CharacterCard;
