import { Route } from "react-router";

// Components
import About from "./pages/About/About";
import Characters from "./pages/Characters/Characters";
import Character from "./pages/Character/Character";
import Faq from "./pages/Faq/Faq";
import OurTeam from "./pages/OurTeam/OurTeam";
import PrivacyPolicy from "./pages/PrivacyPolicy/PrivacyPolicy";
import Reports from "./pages/Reports/Reports";
import Rules from "./pages/Rules/Rules";
import SignIn from "./pages/SignIn/SignIn";
import SignUp from "./pages/SignUp/SignUp";
import Trending from "./pages/Trending/Trending";
import Submit from "./pages/Submit/Submit";
import User from "./pages/User/User";
import Home from "./pages/Home/Home";
import Updates from "./pages/Updates/Updates";

function Routes() {
  return (
    <>
      <Route exact path="/" component={Home} />
      <Route exact path="/about" component={About} />
      <Route exact path="/characters" component={Characters} />
      <Route
        exact
        path="/character/:characterVariableName"
        component={Character}
      />
      <Route exact path="/faq/:oh" component={Faq} />
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
