import { fade, makeStyles } from "@material-ui/core/styles";
import theme from "../../styles/theme";

const useCharacterEmblemStyles = makeStyles({
  buttonBase: {
    color: theme.palette.common.white,
    borderRadius: 50,
    margin: theme.spacing(0.85),
  },
  emblem: {
    width: theme.spacing(9),
    height: theme.spacing(9),
    border: "4px solid white",

    backgroundColor: fade(theme.palette.common.white, 0.15),

    "&:hover": {
      transition: theme.transitions.create(["transform", "background-color"], {
        easing: theme.transitions.easing.easeOut,
        duration: theme.transitions.duration.enteringScreen,
      }),
      backgroundColor: theme.palette.primary.main,
      transform: "scale(1.1)",
    },
  },
  img: {
    userDrag: "none",
  },
});

export default useCharacterEmblemStyles;
