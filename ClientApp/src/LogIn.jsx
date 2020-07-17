import React from 'react'
export function LogIn() {
  return (
    <div className="login-signup">
      <h3>Log in</h3>
      <form>
        <input className="bg-yellow" type="text" placeholder="Email" />
        <input className="bg-yellow" type="password" placeholder="Password" />
      </form>
    </div>
  )
}
