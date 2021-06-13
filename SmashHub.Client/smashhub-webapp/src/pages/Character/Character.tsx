import useCharacterStyles from "./Character.styles";

function Character() {
  const classes = useCharacterStyles();

  return <div className={classes.root}>Character</div>;
}

export default Character;
