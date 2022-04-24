import { makeStyles, Theme } from "@material-ui/core";

const useMainSideNavStyles = makeStyles((theme: Theme) => ({
  content: {
    // border: "1px solid red",
    margin: "64px 0px 0px 0px",
    padding: theme.spacing(2),
    [theme.breakpoints.up("sm")]: {
      margin: "64px 0px 0px 59px",
    },
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
    justifyContent: "center",
  },
  main: {
    width: "100%",
    maxWidth: 1000,
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
    // border: "1px solid red",
  },
}));

export default useMainSideNavStyles;
