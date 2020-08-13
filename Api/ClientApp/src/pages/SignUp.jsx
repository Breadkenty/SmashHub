import React, { useState } from 'react'
import { useHistory } from 'react-router'
import { recordAuthentication } from '../auth'

export function SignUp() {
  const history = useHistory()

  const [newUser, setNewUser] = useState({
    displayName: '',
    email: '',
    password: '',
  })

  const [errorMessage, setErrorMessage] = useState()

  function handleSubmit(event) {
    event.preventDefault()

    fetch('api/Users', {
      method: 'POST',
      headers: { 'content-type': 'application/json' },
      body: JSON.stringify(newUser),
    })
      .then(response => response.json())
      .then(apiResponse => {
        if (apiResponse.status === 400) {
          setErrorMessage(Object.values(apiResponse.errors).join(' '))
        } else {
          fetch('api/Sessions', {
            method: 'POST',
            headers: { 'content-type': 'application/json' },
            body: JSON.stringify(newUser),
          })
            .then(response => response.json())
            .then(apiResponse => {
              if (apiResponse.status === 400) {
                setErrorMessage(Object.values(apiResponse.errors).join(' '))
              } else {
                recordAuthentication(apiResponse)
                window.location = '/'
              }
            })
        }
      })
  }

  function handleFieldChange(event) {
    setNewUser({
      ...newUser,
      [event.target.id]: event.target.value,
    })
  }

  return (
    <div className="login-signup">
      <h3 className="text-white">Sign up</h3>
      <form onSubmit={handleSubmit}>
        {errorMessage && (
          <div className="error-message">
            <i class="fas fa-exclamation-triangle"></i> {errorMessage}
          </div>
        )}
        <input
          className="bg-yellow"
          type="text"
          placeholder="Display name"
          id="displayName"
          value={newUser.displayName}
          onChange={handleFieldChange}
        />
        <input
          className="bg-yellow"
          type="text"
          placeholder="Email"
          id="email"
          value={newUser.email}
          onChange={handleFieldChange}
        />
        <input
          className="bg-yellow"
          type="password"
          placeholder="Password"
          id="password"
          value={newUser.password}
          onChange={handleFieldChange}
        />
        <button className="bg-yellow button black-text" type="submit">
          Sign up
        </button>
      </form>
    </div>
  )
}
