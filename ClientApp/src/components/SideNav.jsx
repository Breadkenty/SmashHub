import React from 'react'
import { Link } from 'react-router-dom'
import logo from '../graphics/logo/logo-on-black.png'

export function SideNav(props) {
  return (
    <div
      className="side-nav"
      style={
        props.sideNavDisplay
          ? {
              transform: `translate(0%)`,
            }
          : {
              transform: `translate(-100%)`,
            }
      }
    >
      <i class="fas fa-times" onClick={props.handleSideBar}></i>
      <img src={logo} alt="Smash combos logo" />
      <ul>
        <li>
          <Link to="/submit">
            <button
              className="bg-yellow button black-text"
              onClick={props.handleSideBar}
            >
              Submit a combo
            </button>
          </Link>
        </li>
        <li>
          <Link to="/signup">
            <button
              className="white-text button-blank"
              onClick={props.handleSideBar}
            >
              Sign up
            </button>
          </Link>
        </li>
        <li>
          <Link to="/login">
            <button
              className="white-text button-blank"
              onClick={props.handleSideBar}
            >
              Log in
            </button>
          </Link>
        </li>
      </ul>
    </div>
  )
}
