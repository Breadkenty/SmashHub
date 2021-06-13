import useSignInStyles from "./SignIn.styles";

function SignIn() {
  const classes = useSignInStyles();

  return <div className={classes.root}>SignIn</div>;
}

export default SignIn;
