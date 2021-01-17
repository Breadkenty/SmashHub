import React, { useState } from 'react'

export function ForgotPassword() {
  const [forgotPasswordRequest, setForgotPasswordRequest] = useState({
    email: '',
  })
  const [emailSent, setEmailSent] = useState(false)

  function handleSubmit(event) {
    event.preventDefault()

    fetch('api/Users/forgotpassword', {
      method: 'POST',
      headers: { 'content-type': 'application/json' },
      body: JSON.stringify(forgotPasswordRequest),
    })
    setEmailSent(true)
  }

  return (
    <div className="login-signup">
      <h3 className="white-text">Forgot your password?</h3>
      <p>
        Not a problem! Enter your email and we'll send you a link to reset your
        password.
      </p>
      <form onSubmit={handleSubmit}>
        <input
          className="bg-yellow"
          type="text"
          placeholder="Email"
          id="email"
          value={forgotPasswordRequest.email}
          onChange={event => {
            setForgotPasswordRequest({
              ...forgotPasswordRequest,
              email: event.target.value,
            })
          }}
        />
        {emailSent ? (
          <h5>
            If an account with this email exists, you should receive an email
            shortly.
          </h5>
        ) : (
          <button className="bg-yellow button black-text" type="submit">
            Submit
          </button>
        )}
      </form>
    </div>
  )
}
