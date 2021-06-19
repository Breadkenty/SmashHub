import { makeStyles } from "@material-ui/core/styles";
import theme from "../../styles/theme";

const useCharactersStyles = makeStyles(() => ({
  root: {
    borderRadius: theme.shape.borderRadius,
    backgroundColor: theme.palette.background.paper,
    display: "inline-flex",
    flexDirection: "column",
    alignItems: "center",
    width: "fit-content",
  },
  h1: {
    margin: theme.spacing(2),
  },
  divider: {
    width: "100%",
  },
  characters: {
    padding: theme.spacing(2),
    width: "fit-content",
    display: "flex",
    flexWrap: "wrap",
    justifyContent: "center",
  },
}));

export default useCharactersStyles;
