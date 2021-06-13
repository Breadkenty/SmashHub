import { Link } from "react-router-dom";

import useAppStyles from "./App.styles";
import Routes from "./Routes";

function App() {
  const classes = useAppStyles();

  return (
    <div className={classes.root}>
      <div className={classes.nav}>
        <Link to="/">
          <button className={classes.navButton}>Home</button>
        </Link>
        <Link to="/about">
          <button className={classes.navButton}>About</button>
        </Link>
        <Link to="/characters">
          <button className={classes.navButton}>Characters</button>
        </Link>
        <Link to="/character">
          <button className={classes.navButton}>Character</button>
        </Link>
        <Link to="/faq">
          <button className={classes.navButton}>Faq</button>
        </Link>
        <Link to="/our-team">
          <button className={classes.navButton}>Our Team</button>
        </Link>
        <Link to="/privacy-policy">
          <button className={classes.navButton}>Privacy Policy</button>
        </Link>
        <Link to="/reports">
          <button className={classes.navButton}>Reports</button>
        </Link>
        <Link to="/rules">
          <button className={classes.navButton}>Rules</button>
        </Link>
        <Link to="/sign-in">
          <button className={classes.navButton}>Sign In</button>
        </Link>
        <Link to="/sign-up">
          <button className={classes.navButton}>Sign Up</button>
        </Link>
        <Link to="/spicy">
          <button className={classes.navButton}>Spicy</button>
        </Link>
        <Link to="/submit">
          <button className={classes.navButton}>Submit</button>
        </Link>
        <Link to="/user">
          <button className={classes.navButton}>User</button>
        </Link>
      </div>
      <Routes />
    </div>
  );
}

export default App;
