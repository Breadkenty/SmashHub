// Main Imports
import { Link as RouterLink } from "react-router-dom";

// Material UI Imports
import {
  Link,
  ListItem,
  ListItemIcon,
  ListItemText,
  Menu,
  Typography,
} from "@material-ui/core";
import PersonIcon from "@material-ui/icons/Person";
import SettingsIcon from "@material-ui/icons/Settings";
import ExitToAppIcon from "@material-ui/icons/ExitToApp";

// Component Imports

export interface SubSideNavProps {
  anchorEl: null | HTMLElement;
  handleClose: () => void;
  onSignOut?: () => void;
}

function SubSideNav(props: SubSideNavProps) {
  return (
    <Menu
      id="simple-menu"
      anchorEl={props.anchorEl}
      keepMounted
      open={Boolean(props.anchorEl)}
      onClose={props.handleClose}
    >
      <Link
        component={RouterLink}
        to="/user"
        underline="none"
        color="inherit"
        variant="button"
      >
        <ListItem button>
          <ListItemIcon>
            <PersonIcon />
          </ListItemIcon>
          <ListItemText
            primary={<Typography variant="button">Profile</Typography>}
          />
        </ListItem>
      </Link>
      <Link
        component={RouterLink}
        to="/"
        underline="none"
        color="inherit"
        variant="button"
      >
        <ListItem button>
          <ListItemIcon>
            <SettingsIcon />
          </ListItemIcon>
          <ListItemText
            primary={<Typography variant="button">Settings</Typography>}
          />
        </ListItem>
      </Link>
      <Link
        component={RouterLink}
        to="/"
        underline="none"
        color="inherit"
        variant="button"
      >
        <ListItem button onClick={props.onSignOut}>
          <ListItemIcon>
            <ExitToAppIcon />
          </ListItemIcon>
          <ListItemText
            primary={<Typography variant="button">Sign out</Typography>}
          />
        </ListItem>
      </Link>
    </Menu>
  );
}

export default SubSideNav;
