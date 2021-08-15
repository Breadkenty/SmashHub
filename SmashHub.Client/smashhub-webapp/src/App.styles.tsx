import { makeStyles, Theme } from "@material-ui/core";

const useStyles = makeStyles((theme: Theme) => ({
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
}));

export default useStyles;
