import { createMuiTheme } from "@material-ui/core";
import { yellow } from "@material-ui/core/colors";

export const theme = createMuiTheme({
  palette: {
    type: "dark",
    primary: yellow,
    background: {
      default: "#181818",
      paper: "#212121",
    },
    text: {
      primary: "#FFF",
      secondary: "#FFF",
      disabled: "#FFF",
      hint: "#FFF",
    },
  },
  typography: {
    h1: {
      fontWeight: 800,
      fontSize: "1.5rem",
      lineHeight: 1.235,
      letterSpacing: 0.24,
    },
    button: {
      textTransform: "none",
    },
  },
});

export default theme;
