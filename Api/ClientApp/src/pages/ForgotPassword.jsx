import React, { useState } from 'react'

export function ForgotPassword() {
  const [errorMessage, setErrorMessage] = useState()

  return (
    <div className="login-signup">
      <h3 className="white-text">Forgot your password?</h3>
      {errorMessage && (
        <div className="error-message">
          <i className="fas fa-exclamation-triangle"></i> {errorMessage}
        </div>
      )}
      <p>
        Not a problem! Enter your email and we'll send you a link to reset your
        password.
      </p>
      <form>
        <input
          className="bg-yellow"
          type="text"
          placeholder="Email"
          id="email"
        />
        <button className="bg-yellow button black-text" type="submit">
          Submit
        </button>
      </form>
    </div>
  )
}
