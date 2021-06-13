import usePrivacyPolicyStyles from "./PrivacyPolicy.styles";

function PrivacyPolicy() {
  const classes = usePrivacyPolicyStyles();

  return <div className={classes.root}>PrivacyPolicy</div>;
}

export default PrivacyPolicy;
