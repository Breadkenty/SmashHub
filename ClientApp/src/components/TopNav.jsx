import React from 'react'
import logo from '../graphics/logo/logo-on-black.png'

export function TopNav() {
  return (
    <nav>
      <div>
        <button className="bg-yellow button">Submit a combo</button>
        <img src={logo} alt="Smash combos logo" />

        <div className="nav-buttons">
          <button className="white-text">Sign up</button>
          <button className="white-text">Log in</button>
        </div>
      </div>
    </nav>
  )
}
