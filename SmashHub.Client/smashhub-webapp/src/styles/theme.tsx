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
  },
});

export default theme;
