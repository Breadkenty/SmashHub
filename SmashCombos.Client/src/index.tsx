import React from "react";
import ReactDOM from "react-dom";
import "./index.css";
import App from "./App";

import { ThemeProvider, createMuiTheme } from "@material-ui/core/styles";
import CssBaseline from "@material-ui/core/CssBaseline";
import yellow from "@material-ui/core/colors/yellow";
import grey from "@material-ui/core/colors/grey";

const theme = createMuiTheme({
  palette: {
    type: "dark",
    primary: yellow,
    secondary: grey,
  },
});

ReactDOM.render(
  <React.StrictMode>
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <App />
    </ThemeProvider>
  </React.StrictMode>,
  document.getElementById("root")
);
