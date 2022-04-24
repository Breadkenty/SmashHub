import { makeStyles, Theme } from '@material-ui/core';

const useCharacterStyles = makeStyles((theme: Theme) => ({
  root: {
    width: '100%',
  },

  characterCard: {
    marginBottom: theme.spacing(1),
  },
}));

export default useCharacterStyles;
