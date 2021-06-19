import { Route } from "react-router";

// Components
import About from "../About/About";
import Characters from "../Characters/Characters";
import Character from "../Character/Character";
import Faq from "../Faq/Faq";
import OurTeam from "../OurTeam/OurTeam";
import PrivacyPolicy from "../PrivacyPolicy/PrivacyPolicy";
import Reports from "../Reports/Reports";
import Rules from "../Rules/Rules";
import SignIn from "../SignIn/SignIn";
import SignUp from "../SignUp/SignUp";
import Trending from "../Trending/Trending";
import Submit from "../Submit/Submit";
import User from "../User/User";
import Home from "../Home/Home";
import Updates from "../Updates/Updates";

function Routes() {
  return (
    <>
      <Route exact path="/" component={Home} />
      <Route exact path="/about" component={About} />
      <Route exact path="/characters" component={Characters} />
      <Route exact path="/character" component={Character} />
      <Route exact path="/faq" component={Faq} />
      <Route exact path="/our-team" component={OurTeam} />
      <Route exact path="/privacy-policy" component={PrivacyPolicy} />
      <Route exact path="/reports" component={Reports} />
      <Route exact path="/rules" component={Rules} />
      <Route exact path="/sign-in" component={SignIn} />
      <Route exact path="/sign-up" component={SignUp} />
      <Route exact path="/trending" component={Trending} />
      <Route exact path="/submit" component={Submit} />
      <Route exact path="/updates" component={Updates} />
      <Route exact path="/user" component={User} />
    </>
  );
}

export default Routes;
