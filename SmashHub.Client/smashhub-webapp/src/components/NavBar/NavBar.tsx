// Main Imports
import React from "react";

// Material UI Imports

// Component Imports
import TopNav from "./TopNav/TopNav";
import useNavBarStyles from "./NavBar.styles";

export interface NavBarProps {
  authenticated: boolean;
  children: React.ReactNode;
  onSignIn?: () => void;
  onSignOut?: () => void;
}

function NavBar(props: NavBarProps) {
  const classes = useNavBarStyles();

  return (
    <>
      <TopNav
        authenticated={props.authenticated}
        onSignIn={props.onSignIn}
        onSignOut={props.onSignOut}
      />
      <div className={classes.content}>
        <main className={classes.main}>{props.children}</main>
      </div>
    </>
  );
}

export default NavBar;
