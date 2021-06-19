import { makeStyles } from "@material-ui/core/styles";
import { theme } from "../../../styles/theme";

const drawerWidth = 275;

const useMainSideNavStyles = makeStyles({
  root: {
    position: "fixed",
    top: 0,
    height: "calc(100% - 66px)",
    flexShrink: 0,
    whiteSpace: "nowrap",
    display: "flex",
    flexDirection: "column",
    justifyContent: "space-between",
    zIndex: theme.zIndex.drawer + 2,
    border: "none",
    marginTop: 64,
  },
  drawerOpen: {
    width: drawerWidth,
    transition: theme.transitions.create("width", {
      easing: theme.transitions.easing.sharp,
      duration: theme.transitions.duration.enteringScreen,
    }),
  },
  drawerClose: {
    transition: theme.transitions.create("width", {
      easing: theme.transitions.easing.sharp,
      duration: theme.transitions.duration.leavingScreen,
    }),
    overflowX: "hidden",
    width: theme.spacing(7) + 1,
  },
  content: {
    marginLeft: 57,
  },
  listItemText: {
    overflowX: "hidden",
  },
  logoButton: {
    padding: theme.spacing(2),
    width: "100%",
  },
  logo: {
    width: 100,
    userDrag: "none",
  },
  list: {
    padding: 0,
  },
});

export default useMainSideNavStyles;
