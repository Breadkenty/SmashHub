import { Avatar, ButtonBase } from "@material-ui/core";
import useCharacterEmblemStyles from "./CharacterEmblem.styles";
import parameters from "../../parameters.json";

export interface CharacterEmblemProps {
  character: string;
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
          src={`${parameters.imagePrefix}/character-emblem/${props.character}-emblem.png`}
        />
      </ButtonBase>
    </>
  );
}

export default CharacterEmblem;
