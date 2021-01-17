import React, { useState } from 'react'
import { Link } from 'react-router-dom'

import { recordAuthentication } from '../auth'

export function SignUp() {
  const [newUser, setNewUser] = useState({
    displayName: '',
    email: '',
    password: '',
  })

  const [errorMessage, setErrorMessage] = useState()
  const [confirmPassword, setConfirmPassword] = useState('')

  function handleSubmit(event) {
    event.preventDefault()

    if (`${newUser.password}` === `${confirmPassword}`) {
      fetch('api/Users', {
        method: 'POST',
        headers: { 'content-type': 'application/json' },
        body: JSON.stringify(newUser),
      })
        .then(response => {
          if (response.status === 200) {
            fetch('api/Sessions', {
              method: 'POST',
              headers: { 'content-type': 'application/json' },
              body: JSON.stringify(newUser),
            })
              .then(response => response.json())
              .then(apiResponse => {
                recordAuthentication(apiResponse)
                window.location = '/'
              })
            return { then: function() {} }
          } else {
            return response.json()
          }
        })
        .then(apiData => {
          setErrorMessage(
            apiData.detail || Object.values(apiData.errors).join(' ')
          )
        })
    } else {
      setErrorMessage('Confirm password does not match')
    }
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
      <p>
        Be sure to read the <Link to="/rules">rules</Link> before signing up
      </p>
      <form onSubmit={handleSubmit}>
        {errorMessage && (
          <div className="error-message">
            <i className="fas fa-exclamation-triangle"></i> {errorMessage}
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
        <input
          className="bg-yellow"
          type="password"
          placeholder="Confirm Password"
          value={confirmPassword}
          onChange={event => {
            setConfirmPassword(event.target.value)
          }}
        />
        <button className="bg-yellow button black-text" type="submit">
          Sign up
        </button>
      </form>
    </div>
  )
}
