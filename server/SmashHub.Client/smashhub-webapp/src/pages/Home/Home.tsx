import useHomeStyles from "./Home.styles";

function Home() {
  const classes = useHomeStyles();

  return <div className={classes.root}>Home</div>;
}

export default Home;
