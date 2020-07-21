import React from 'react'
import { Link } from 'react-router-dom'

import logo from '../graphics/logo/logo-on-black.png'

export function TopNav(props) {
  return (
    <nav className="bg-gray">
      <i class="fas fa-bars" onClick={props.handleSideBar}></i>
      <Link to="/">
        <img src={logo} alt="Smash combos logo" />
      </Link>
      <div></div>
    </nav>
  )
}
