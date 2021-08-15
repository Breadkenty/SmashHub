import { makeStyles, Theme } from "@material-ui/core";

const useSortBarStyles = makeStyles((theme: Theme) => ({
  root: {
    backgroundColor: theme.palette.background.paper,
    flexDirection: "row",
    alignItems: "center",
    padding: theme.spacing(0, 2),
    borderRadius: theme.shape.borderRadius,
  },
  label: {
    color: theme.palette.text.primary,
    ...theme.typography.body1,
    marginRight: theme.spacing(2),
    fontWeight: theme.typography.fontWeightBold,
    fontSize: 12
  },
  tab: {
    minWidth: "auto",
  }
}));

export default useSortBarStyles;
