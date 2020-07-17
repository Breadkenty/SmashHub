import React from 'react'
export function SignUp() {
  return (
    <div className="login-signup">
      <h3>Sign up</h3>
      <form>
        <input type="text" placeholder="Display name" />
        <input type="text" placeholder="Email" />
        <input type="password" placeholder="Password" />
      </form>
    </div>
  )
}
