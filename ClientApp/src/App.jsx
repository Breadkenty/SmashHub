import React from 'react'
import './custom.scss'
import './typeface.css'
import logo from './graphics/logo/logo-on-black.png'

export function App() {
  return (
    <>
      <nav>
        <div>
          <img src={logo} alt="Smash combos logo" />

          <div className="nav-buttons">
            <button>Sign up</button>
            <button>Log in</button>
          </div>
        </div>
      </nav>
    </>
  )
}
