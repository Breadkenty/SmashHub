import React from 'react'
import { Link } from 'react-router-dom'

export function LandingPage() {
  return (
    <>
      <div className="landing-page">
        <div className="logo-background" />
        <div className="logo-container">
          <div className="logo" />
          <h3 className="black-text">Combos</h3>
        </div>

        <Link to="/characters">
          <button className="button bg-red white-text">
            Click here to start
          </button>
        </Link>
      </div>
    </>
  )
}
