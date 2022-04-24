import useUserStyles from "./User.styles";

function User() {
  const classes = useUserStyles();

  return <div className={classes.root}>User</div>;
}

export default User;
