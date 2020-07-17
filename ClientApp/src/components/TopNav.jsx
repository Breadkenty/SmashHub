import React from 'react'
import logo from '../graphics/logo/logo-on-black.png'

export function TopNav() {
  return (
    <nav>
      <div>
        <button className="yellow-button">Submit a combo</button>
        <img src={logo} alt="Smash combos logo" />

        <div className="nav-buttons">
          <button>Sign up</button>
          <button>Log in</button>
        </div>
      </div>
    </nav>
  )
}
