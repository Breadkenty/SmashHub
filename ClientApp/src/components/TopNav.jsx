import React from 'react'
import { Link } from 'react-router-dom'

import logo from '../graphics/logo/logo-on-black.png'

export function TopNav(props) {
  return (
    <nav className="bg-gray">
      <button onClick={props.handleSideBar}>
        <i className="fas fa-bars"></i>
      </button>
      <Link to="/">
        <img src={logo} alt="Smash combos logo" />
      </Link>
      <div></div>
    </nav>
  )
}
