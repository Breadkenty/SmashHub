import Icon from "@material-ui/core/Icon";
import AddIcon from "@material-ui/icons/Add";
import TrendingUpIcon from "@material-ui/icons/TrendingUp";
import AppsIcon from "@material-ui/icons/Apps";
import { Option } from "./MainSideNav";

export const mainOptions: Option[] = [
  {
    text: "Submit a combo",
    url: "/submit",
    icon: <AddIcon />,
  },
  {
    text: "Trending",
    url: "/trending",
    icon: <TrendingUpIcon fontSize="small" />,
  },
  {
    text: "Search by character",
    url: "/characters",
    icon: <AppsIcon fontSize="small" />,
  },
];

export const subOptions: Option[] = [
  {
    text: "About",
    url: "/about",
  },
  {
    text: "Our team",
    url: "/our-team",
  },
  {
    text: "Updates",
    url: "/updates",
  },
  {
    text: "FAQ",
    url: "/faq",
  },
  {
    text: "Rules",
    url: "/rules",
  },
  {
    text: "Privacy Policy",
    url: "/privacy-policy",
  },
];

export const footerOptions: Option[] = [
  {
    text: "Support this project",
    url: "https://www.patreon.com/smash_combos",
    icon: <Icon className="fab fa-patreon" style={{ fontSize: 18 }} />,
  },
  {
    text: "Discord server",
    url: "https://discord.com/invite/VbnAwUg",
    icon: <Icon className="fab fa-discord" style={{ fontSize: 18 }} />,
  },
  {
    text: "Source code",
    url: "https://github.com/Breadkenty/SmashHub",
    icon: <Icon className="fab fa-github" style={{ fontSize: 18 }} />,
  },
  {
    text: "Twitter",
    url: "https://twitter.com/KentoKawakami",
    icon: <Icon className="fab fa-twitter" style={{ fontSize: 18 }} />,
  },
];
