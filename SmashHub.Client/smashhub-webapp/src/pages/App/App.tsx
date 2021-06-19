import { useState } from "react";
import NavBar from "../../components/NavBar/NavBar";
// import useAppStyles from "./App.styles";
import Routes from "./Routes";

function App() {
  // const classes = useAppStyles();
  const [authenticated, setAuthenticated] = useState(false);

  return (
    <NavBar
      authenticated={authenticated}
      onSignIn={() => setAuthenticated(true)}
      onSignOut={() => setAuthenticated(false)}
    >
      <Routes />
    </NavBar>
  );
}

export default App;
