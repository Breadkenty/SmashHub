import CharacterEmblem from "../../components/CharacterEmblem/CharacterEmblem";
import mock from "../../mock.json";
import { Divider, Typography } from "@material-ui/core";
import useCharactersStyles from "./Characters.styles";
import { Link } from "react-router-dom";

function Characters() {
  const classes = useCharactersStyles();
  const characters = mock.characters;

  return (
    <section className={classes.root}>
      <Typography variant="h1" color="textPrimary" className={classes.h1}>
        Select a character
      </Typography>
      <Divider className={classes.divider} />
      <div className={classes.characters}>
        {characters.map((character) => (
          <Link to={`/character/${character.variableName}`}>
            <CharacterEmblem key={character.name} characterVariableName={character.variableName} />
          </Link>
        ))}
      </div>
    </section>
  );
}

export default Characters;
