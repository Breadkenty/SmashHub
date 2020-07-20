import React from 'react'

export function SignUp() {
  return (
    <div className="login-signup">
      <h3 className="text-white">Sign up</h3>
      <form>
        <input className="bg-yellow" type="text" placeholder="Display name" />
        <input className="bg-yellow" type="text" placeholder="Email" />
        <input className="bg-yellow" type="password" placeholder="Password" />
        <button className="bg-yellow button black-text" type="submit">
          Sign up
        </button>
      </form>
    </div>
  )
}
