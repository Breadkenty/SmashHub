import { makeStyles } from "@material-ui/core/styles";
import { theme } from "../../styles/theme";

const useStyles = makeStyles({
  root: {
    backgroundColor: theme.palette.background.default,
    height: "100vh",
  },
  nav: {
    display: "flex",
  },
  navButton: {
    margin: 8,
  },
});

export default useStyles;
