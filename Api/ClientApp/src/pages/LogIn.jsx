import React, { useState } from 'react'
import { recordAuthentication } from '../auth'

export function LogIn() {
  const [errorMessage, setErrorMessage] = useState()

  const [user, setUser] = useState({
    email: '',
    password: '',
  })

  function handleFieldChange(event) {
    setUser({
      ...user,
      [event.target.id]: event.target.value,
    })
  }

  function handleSubmit(event) {
    event.preventDefault()

    fetch('api/Sessions', {
      method: 'POST',
      headers: { 'content-type': 'application/json' },
      body: JSON.stringify(user),
    })
      .then(response => response.json())
      .then(apiResponse => {
        if (apiResponse.status >= 400) {
          setErrorMessage(apiResponse.detail)
        } else {
          recordAuthentication(apiResponse)
          window.location = '/'
        }
      })
  }

  return (
    <div className="login-signup">
      <h3 className="white-text">Log in</h3>
      {errorMessage && (
        <div className="error-message">
          <i className="fas fa-exclamation-triangle"></i> {errorMessage}
        </div>
      )}
      <form onSubmit={handleSubmit}>
        <input
          className="bg-yellow"
          type="text"
          placeholder="Email"
          id="email"
          value={user.email}
          onChange={handleFieldChange}
        />
        <input
          className="bg-yellow"
          type="password"
          placeholder="Password"
          id="password"
          value={user.password}
          onChange={handleFieldChange}
        />
        <button className="bg-yellow button black-text" type="submit">
          Log in
        </button>
      </form>
    </div>
  )
}
