import React from "react";
import ReactDOM from "react-dom";
import "./styles/index.css";
import App from "./pages/App/App";
import reportWebVitals from "./reportWebVitals";
import {
  createGenerateClassName,
  StylesProvider,
  ThemeProvider,
} from "@material-ui/core/styles";
import theme from "./styles/theme";
import { BrowserRouter } from "react-router-dom";

const generateClassName = createGenerateClassName({
  seed: "smashhub",
});

ReactDOM.render(
  <React.StrictMode>
    <ThemeProvider theme={theme}>
      <StylesProvider generateClassName={generateClassName}>
        <BrowserRouter>
          <App />
        </BrowserRouter>
      </StylesProvider>
    </ThemeProvider>
  </React.StrictMode>,
  document.getElementById("root")
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
