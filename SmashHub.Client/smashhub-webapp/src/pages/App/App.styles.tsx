import { makeStyles } from "@material-ui/core/styles";

const useAppStyles = makeStyles(() => ({
  root: {
    flexGrow: 1,
  },
  nav: {
    display: "flex",
  },
  navButton: {
    margin: 8,
  },
}));

export default useAppStyles;
