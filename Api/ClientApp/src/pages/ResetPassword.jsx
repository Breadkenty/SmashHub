import React, { useState } from 'react'

export function ResetPassword() {
  const [errorMessage, setErrorMessage] = useState()

  return (
    <div className="login-signup">
      <h3 className="white-text">Reset your password</h3>
      {errorMessage && (
        <div className="error-message">
          <i className="fas fa-exclamation-triangle"></i> {errorMessage}
        </div>
      )}
      <p>Enter a new password:</p>
      <form>
        <input
          className="bg-yellow"
          type="password"
          placeholder="Password"
          id="password"
        />
        <input
          className="bg-yellow"
          type="password"
          placeholder="Confirm Password"
          id="password"
        />
        <button className="bg-yellow button black-text" type="submit">
          Submit
        </button>
      </form>
    </div>
  )
}
