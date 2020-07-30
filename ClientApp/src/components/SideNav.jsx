import React from 'react'
import { Link } from 'react-router-dom'
import logo from '../graphics/logo/logo-on-black.png'
import useOnClickOutside from 'use-onclickoutside'
import { isLoggedIn, logout, getUser } from '../auth'

export function SideNav(props) {
  const ref = React.useRef(null)

  useOnClickOutside(ref, () => {
    if (props.sideNavDisplay) {
      props.handleSideBar()
    }
  })

  function handleLogout() {
    logout()
    window.location = '/'
  }

  const user = getUser()

  return (
    <div
      ref={ref}
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
      <i className="fas fa-times" onClick={props.handleSideBar}></i>
      <Link to="/">
        <img src={logo} alt="Smash combos logo" onClick={props.handleSideBar} />
      </Link>
      <ul>
        {isLoggedIn() && (
          <li>
            <Link to="/submit/new">
              <button
                className="bg-yellow button black-text"
                onClick={props.handleSideBar}
              >
                Submit a combo
              </button>
            </Link>
          </li>
        )}

        {isLoggedIn() && user.admin === true && (
          <>
            <li>
              <Link to="/add">
                <button
                  className="bg-yellow button black-text"
                  onClick={props.handleSideBar}
                >
                  Add a Character
                </button>
              </Link>
            </li>
            <li>
              <Link to="/edit">
                <button
                  className="bg-yellow button black-text"
                  onClick={props.handleSideBar}
                >
                  Edit a Character
                </button>
              </Link>
            </li>
          </>
        )}

        <li>
          <Link to="/about">
            <button
              className="white-text button-blank"
              onClick={props.handleSideBar}
            >
              About
            </button>
          </Link>
        </li>

        <li>
          <Link to="/notes">
            <button
              className="white-text button-blank"
              onClick={props.handleSideBar}
            >
              Notes
            </button>
          </Link>
        </li>

        {isLoggedIn() || (
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
        )}
        {isLoggedIn() || (
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
        )}
        {isLoggedIn() && (
          <li>
            <button className="white-text button-blank" onClick={handleLogout}>
              Log out
            </button>
          </li>
        )}
      </ul>
    </div>
  )
}
