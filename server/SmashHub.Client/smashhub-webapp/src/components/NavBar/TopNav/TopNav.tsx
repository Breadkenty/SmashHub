// Main Imports
import React, { useState } from "react";
import { Link as RouterLink } from "react-router-dom";

// Material UI Imports
import AppBar from "@material-ui/core/AppBar";
import Toolbar from "@material-ui/core/Toolbar";
import IconButton from "@material-ui/core/IconButton";
import InputBase from "@material-ui/core/InputBase";
import MenuIcon from "@material-ui/icons/Menu";
import SearchIcon from "@material-ui/icons/Search";
import NotificationsIcon from "@material-ui/icons/Notifications";
import Avatar from "@material-ui/core/Avatar";
import {
  Link,
  Badge,
  Button,
  ButtonBase,
  Paper,
  Divider,
  Icon,
  ClickAwayListener,
} from "@material-ui/core";
import useMediaQuery from "@material-ui/core/useMediaQuery";

// Component Imports
import SubSideNav from "../SubSideNav/SubSideNav";
import MainSideNav from "../MainSideNav/MainSideNav";
import useTopNavStyles from "./TopNav.styles";

export interface TopNavProps {
  authenticated: boolean;
  onSignIn?: () => void;
  onSignOut?: () => void;
}

function TopNav(props: TopNavProps) {
  const classes = useTopNavStyles();
  const mobile = useMediaQuery("(max-width:600px)");

  const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null);
  const [mobileSearchOpen, setMobileSearchOpen] = useState(false);
  const [mobileMainSideNavOpen, setMobileMainSideNavOpen] = useState(false);

  const handleClick = (event: React.MouseEvent<HTMLButtonElement>) => {
    setAnchorEl(event.currentTarget);
  };

  const handleClose = () => {
    setAnchorEl(null);
  };

  const handleClickAway = () => {
    setMobileSearchOpen(false);
  };

  return (
    <>
      <AppBar position="fixed" className={classes.root}>
        <Toolbar variant="dense" className={classes.toolbar}>
          <div className={classes.left}>
            {mobile && (
              <IconButton
                edge="start"
                className={classes.menuButton}
                aria-label="open drawer"
                onClick={() => setMobileMainSideNavOpen(true)}
              >
                <MenuIcon />
              </IconButton>
            )}
            <Link component={RouterLink} to="/">
              <img
                className={classes.logo}
                src="https://res.cloudinary.com/dtojhch6o/image/upload/v1623539223/SmashHub/assets/logo-on-black.png"
                alt="smashhub logo"
              />
            </Link>
          </div>
          {mobile || (
            <div className={classes.search}>
              <SearchIcon className={classes.searchIcon} />
              <InputBase
                placeholder="Search…"
                classes={{
                  root: classes.inputRoot,
                  input: classes.inputInput,
                }}
              />
            </div>
          )}
          <div className={classes.right}>
            {mobile && (
              <IconButton
                className={classes.searchButton}
                onClick={() => setMobileSearchOpen(true)}
              >
                <SearchIcon className={classes.icon} />
              </IconButton>
            )}
            {props.authenticated ? (
              <>
                <IconButton edge="start" className={classes.menuButton}>
                  <Badge badgeContent={4} color="primary">
                    <NotificationsIcon className={classes.icon} />
                  </Badge>
                </IconButton>

                <ButtonBase
                  centerRipple
                  className={classes.avatarButton}
                  onClick={handleClick}
                >
                  <Avatar
                    alt="Kento avatar"
                    src="https://avatars.githubusercontent.com/u/48931537?s=400&u=2fc1a51d7abe87e06d62e0ffd281544b4ca420cd&v=4"
                  />
                </ButtonBase>
                <SubSideNav
                  anchorEl={anchorEl}
                  handleClose={handleClose}
                  onSignOut={props.onSignOut}
                />
              </>
            ) : (
              <Link component={RouterLink} to="/sign-in">
                <Button
                  variant="contained"
                  color="primary"
                  onClick={props.onSignIn}
                >
                  Sign in
                </Button>
              </Link>
            )}
          </div>
        </Toolbar>
      </AppBar>
      {mobileSearchOpen && (
        <ClickAwayListener onClickAway={handleClickAway}>
          <AppBar className={classes.mobileSearchBar}>
            <Toolbar variant="dense" disableGutters>
              <IconButton
                aria-label="menu"
                onClick={() => setMobileSearchOpen(false)}
              >
                <Icon
                  className="fas fa-chevron-left"
                  style={{ fontSize: 18 }}
                />
              </IconButton>
              <Paper component="form" className={classes.mobileSearch}>
                <InputBase
                  className={classes.input}
                  placeholder="Search"
                  inputProps={{ "aria-label": "search google maps" }}
                />
                <Divider className={classes.divider} orientation="vertical" />
                <IconButton type="submit" aria-label="search">
                  <SearchIcon fontSize="small" />
                </IconButton>
              </Paper>
            </Toolbar>
          </AppBar>
        </ClickAwayListener>
      )}
      <MainSideNav
        mobileOpen={mobileMainSideNavOpen}
        setMobileOpen={setMobileMainSideNavOpen}
        authenticated={props.authenticated}
      />
    </>
  );
}

export default TopNav;
