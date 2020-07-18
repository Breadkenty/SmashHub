import React from 'react'

export function SignUp() {
  return (
    <div className="login-signup">
      <h3>Sign up</h3>
      <form>
        <input className="bg-yellow" type="text" placeholder="Display name" />
        <input className="bg-yellow" type="text" placeholder="Email" />
        <input className="bg-yellow" type="password" placeholder="Password" />
        <button className="bg-yellow button" type="submit">
          Sign up
        </button>
      </form>
    </div>
  )
}
