import { Avatar, ButtonBase } from "@material-ui/core";
import constants from "../../constants.json";
import useCharacterEmblemStyles from "./CharacterEmblem.styles";

export interface CharacterEmblemProps {
  characterVariableName: string;
}

function CharacterEmblem(props: CharacterEmblemProps) {
  const classes = useCharacterEmblemStyles();

  return (
    <>
      <ButtonBase
        className={classes.buttonBase}
        // onClick={handleClick}
      >
        <Avatar
          className={classes.emblem}
          classes={{
            img: classes.img,
          }}
          src={`${constants.imagePrefix}/character-emblem/${props.characterVariableName}-emblem.png`}
        />
      </ButtonBase>
    </>
  );
}

export default CharacterEmblem;
