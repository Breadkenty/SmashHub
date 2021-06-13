import useCharactersStyles from "./Characters.styles";

function Characters() {
  const classes = useCharactersStyles();

  return <div className={classes.root}>Characters</div>;
}

export default Characters;
