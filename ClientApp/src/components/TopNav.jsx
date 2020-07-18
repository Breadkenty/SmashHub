import React from 'react'
import { Link } from 'react-router-dom'

import logo from '../graphics/logo/logo-on-black.png'

export function TopNav() {
  return (
    <nav>
      <div>
        <Link to="/submit">
          <button className="bg-yellow button">Submit a combo</button>
        </Link>
        <Link to="/characters">
          <img src={logo} alt="Smash combos logo" />
        </Link>

        <div className="nav-buttons">
          <Link to="/signup">
            <button className="white-text">Sign up</button>
          </Link>
          <Link to="/login">
            <button className="white-text">Log in</button>
          </Link>
        </div>
      </div>
    </nav>
  )
}
