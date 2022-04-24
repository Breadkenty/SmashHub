import { useParams } from "react-router";
import CharacterCard from "../../components/CharacterCard/CharacterCard";
import mock from "../../mock.json";
import useCharacterStyles from "./Character.styles";
import { ICharacter } from "../../models/Characters.types";
import SortBar from "../../components/SortBar/SortBar";

interface Params {
  characterVariableName: string;
}

function Character() {
  const classes = useCharacterStyles();
  const { characterVariableName } = useParams<Params>();
  const character: ICharacter = mock.characters.find((character: ICharacter) => character.variableName === characterVariableName)!;

  return (
    <div className={classes.root}>
      <CharacterCard character={character} className={classes.characterCard}/>
      <SortBar />
    </div>
  );
}

export default Character;
