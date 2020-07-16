import React from 'react'
import './custom.scss'
import logo from '. /graphics/logo/logo-on-black.png'

export function App() {
  return (
    <>
      <nav>
        <div>
          <img src={logo} />
          <div>
            <button>Sign up</button>
            <button>Log in</button>
          </div>
        </div>
      </nav>
    </>
  )
}
