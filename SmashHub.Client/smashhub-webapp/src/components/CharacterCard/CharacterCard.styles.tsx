import { makeStyles, Theme } from "@material-ui/core";

const useCharacterCardStyles = makeStyles((theme: Theme) => ({
  root: {
    height: theme.spacing(12),
    display: "flex",
    alignItems: "center",
    position: "relative",
  },
  title: {
    textShadow: `2px 2px 10px black`,
    position: "absolute",
    left: "8%",
    [theme.breakpoints.up("sm")]: {
      left: "15%",
    },
    zIndex: theme.zIndex.drawer + 1,
  },
  character: {
    position: "absolute",
    right: "0",
    [theme.breakpoints.up("sm")]: {
      right: "10%",
    },
    margin: theme.spacing(0, 2),
    backgroundPosition: "center",
    backgroundSize: "100% auto",
    backgroundRepeat: "no-repeat",
    maxWidth: "280px",
    width: "50%",
    height: "100%",
  },
}));

export default useCharacterCardStyles;
