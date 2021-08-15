// Main Imports
import { Dispatch, SetStateAction, useState } from "react";
import clsx from "clsx";
import { Link as RouterLink } from "react-router-dom";

// Material UI Imports
import {
  Divider,
  Link,
  List,
  ListItem,
  ListItemIcon,
  ListItemText,
  Paper,
  Drawer,
  Typography,
  useMediaQuery,
  DrawerProps,
  PaperProps,
  ButtonBase,
} from "@material-ui/core";

// Component Imports
import { mainOptions, subOptions, footerOptions } from "./options";
import useMainSideNavStyles from "./MainSideNav.styles";

export interface MainSideNavProps {
  mobileOpen: boolean;
  setMobileOpen: Dispatch<SetStateAction<boolean>>;
  authenticated: boolean;
}

export interface Option {
  text: string;
  url: string;
  icon?: React.ReactNode;
}

function MainSideNav(props: MainSideNavProps) {
  const classes = useMainSideNavStyles();
  const mobile = useMediaQuery("(max-width:600px)");

  const [open, setOpen] = useState(false);

  function handleDrawerOpen() {
    setOpen(true);
  }
  function handleDrawerClose() {
    setOpen(false);
  }

  const menuItem = (option: Option, useRouter: boolean) => {
    const propToUse = useRouter
      ? {
          component: RouterLink,
          to: option.url,
        }
      : {
          href: option.url,
        };

    return (
      <Link {...propToUse} key={option.text} underline="none" color="inherit" variant="button" onClick={() => setOpen(false)}>
        <ListItem button>
          <ListItemIcon>{option.icon}</ListItemIcon>
          <ListItemText primary={<Typography variant="button">{option.text}</Typography>} className={classes.listItemText} />
        </ListItem>
      </Link>
    );
  };

  const menuItems = () => (
    <>
      <List className={classes.list}>
        {mobile && (
          <Link href="/">
            <ButtonBase className={classes.logoButton}>
              <img
                className={classes.logo}
                src="https://res.cloudinary.com/dtojhch6o/image/upload/v1623539223/SmashHub/assets/logo-on-black.png"
                alt="smashhub logo"
              />
            </ButtonBase>
            <Divider />
          </Link>
        )}
        {props.authenticated && menuItem(mainOptions[0], true)}
        {mainOptions.filter((option) => option.text !== "Submit a combo").map((option: Option) => menuItem(option, true))}
        <Divider />
        {subOptions.map((option: Option) => menuItem(option, true))}
      </List>
      <List className={classes.list}>
        <Divider />
        {footerOptions.map((option: Option) => menuItem(option, false))}
      </List>
    </>
  );

  const drawerProps: DrawerProps = {
    anchor: "left",
    open: props.mobileOpen,
    onClose: () => props.setMobileOpen(false),
  };

  const paperProps: PaperProps = {
    variant: "outlined",
    square: true,
    className: clsx(classes.root, {
      [classes.drawerOpen]: open,
      [classes.drawerClose]: !open,
    }),
    onMouseEnter: handleDrawerOpen,
    onMouseLeave: handleDrawerClose,
  };

  return <>{mobile ? <Drawer {...drawerProps}>{menuItems()}</Drawer> : <Paper {...paperProps}>{menuItems()}</Paper>}</>;
}

export default MainSideNav;
