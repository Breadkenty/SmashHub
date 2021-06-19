import { fade, makeStyles } from "@material-ui/core/styles";
import { theme } from "../../../styles/theme";

const useTopNavStyles = makeStyles({
  root: {
    backgroundColor: theme.palette.background.paper,
    zIndex: theme.zIndex.drawer + 2,
  },
  toolbar: {
    display: "flex",
    justifyContent: "space-between",
    padding: theme.spacing(1, 2),
  },
  menuButton: {
    marginRight: theme.spacing(2),
  },
  icon: {
    fontSize: 24,
  },
  logo: {
    width: 100,
    userDrag: "none",
  },
  search: {
    display: "flex",
    alignItems: "center",
    borderRadius: theme.shape.borderRadius,
    backgroundColor: fade(theme.palette.common.white, 0.15),
    "&:hover": {
      backgroundColor: fade(theme.palette.common.white, 0.25),
    },
    width: "100%",
    maxWidth: 600,
    margin: theme.spacing(0, 2),
  },
  searchIcon: {
    marginLeft: theme.spacing(2),
    color: theme.palette.text.primary,
  },
  searchButton: {
    marginRight: theme.spacing(2),
  },
  inputRoot: {
    color: theme.palette.text.primary,
    width: "100%",
  },
  inputInput: {
    padding: theme.spacing(1, 2),
    width: "100%",
  },
  left: {
    display: "flex",
    alignItems: "center",
  },
  right: {
    display: "flex",
    alignItems: "center",
  },
  avatarButton: {
    color: theme.palette.common.white,
  },
  mobileSearchBar: {
    display: "flex",
    backgroundColor: theme.palette.background.paper,
    zIndex: theme.zIndex.drawer + 3,
    padding: theme.spacing(1, 2, 1, 1),
    width: "100%",
  },
  mobileSearch: {
    backgroundColor: fade(theme.palette.common.white, 0.15),
    "&:hover": {
      backgroundColor: fade(theme.palette.common.white, 0.25),
    },
    display: "flex",
    alignItems: "center",
    marginLeft: theme.spacing(2),
    width: "100%",
  },
  input: {
    marginLeft: theme.spacing(1),
    paddingLeft: theme.spacing(2),
    flex: 1,
  },
  divider: {
    height: 24,
    margin: 4,
  },
});

export default useTopNavStyles;
