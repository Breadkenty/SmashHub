import React from 'react'
import { Link } from 'react-router-dom'
import { getUser, isLoggedIn } from '../auth'

import logo from '../graphics/logo/logo-on-black.png'

export function TopNav(props) {
  const user = getUser()

  return (
    <nav className="bg-gray">
      <button onClick={props.handleSideBar}>
        <i className="fas fa-bars"></i>
      </button>
      <Link className="logo" to="/">
        <img src={logo} alt="Smash combos logo" />
      </Link>
      {(isLoggedIn() && (
        <div className="nav-user">
          <h5>Welcome</h5>{' '}
          <Link to={`/user/${user.displayName}`}>{user.displayName}</Link>
        </div>
      )) || <div></div>}
    </nav>
  )
}
