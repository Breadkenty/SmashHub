import CharacterEmblem from "../../components/CharacterEmblem/CharacterEmblem";
import useCharactersStyles from "./Characters.styles";
import parameters from "../../parameters.json";
import { Divider, Typography } from "@material-ui/core";

function Characters() {
  const classes = useCharactersStyles();
  const characters = parameters.characters;

  return (
    <section className={classes.root}>
      <Typography variant="h1" color="textPrimary" className={classes.h1}>
        Select a character
      </Typography>
      <Divider className={classes.divider} />
      <div className={classes.characters}>
        {characters.map((character) => (
          <CharacterEmblem character={character} />
        ))}
      </div>
    </section>
  );
}

export default Characters;
