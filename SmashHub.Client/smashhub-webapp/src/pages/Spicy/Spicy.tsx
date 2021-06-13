import useSpicyStyles from "./Spicy.styles";

function Spicy() {
  const classes = useSpicyStyles();

  return <div className={classes.root}>Spicy</div>;
}

export default Spicy;
