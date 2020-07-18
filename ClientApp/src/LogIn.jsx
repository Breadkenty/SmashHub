import React from 'react'
import { Link } from 'react-router-dom'

export function LogIn() {
  return (
    <div className="login-signup">
      <h3>Log in</h3>
      <form>
        <input className="bg-yellow" type="text" placeholder="Email" />
        <input className="bg-yellow" type="password" placeholder="Password" />
        <button className="bg-yellow button" type="submit">
          Log in
        </button>
      </form>
    </div>
  )
}
