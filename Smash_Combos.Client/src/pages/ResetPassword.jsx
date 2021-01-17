import React, { useState } from 'react'
import { useHistory, useParams } from 'react-router'

export function ResetPassword() {
  const history = useHistory()
  const params = useParams()

  const id = params.id
  const token = params.token

  const [errorMessage, setErrorMessage] = useState()
  const [confirmPassword, setConfirmPassword] = useState('')
  const [resetPasswordRequest, setResetPasswordRequest] = useState({
    resetPassword: '',
  })

  function handleSubmit(event) {
    event.preventDefault()

    if (`${resetPasswordRequest.resetPassword}` === `${confirmPassword}`) {
      fetch(`api/Users/resetpassword/${id}/${token}`, {
        method: 'POST',
        headers: { 'content-type': 'application/json' },
        body: JSON.stringify(resetPasswordRequest.resetPassword),
      })
        .then(response => {
          if (response.ok) {
            history.push('/login')
            return { then: function() {} }
          } else {
            return response.json()
          }
        })
        .then(apiData => {
          setErrorMessage(apiData.detail)
        })
    } else {
      setErrorMessage('Confirm password does not match')
    }
  }

  return (
    <div className="login-signup">
      <h3 className="white-text">Reset your password</h3>
      {errorMessage && (
        <div className="error-message">
          <i className="fas fa-exclamation-triangle"></i> {errorMessage}
        </div>
      )}
      <p>Enter a new password:</p>
      <form onSubmit={handleSubmit}>
        <input
          className="bg-yellow"
          type="password"
          placeholder="Password"
          id="password"
          value={resetPasswordRequest.resetPassword}
          onChange={event => {
            setResetPasswordRequest({
              ...resetPasswordRequest,
              resetPassword: event.target.value,
            })
          }}
        />
        <input
          className="bg-yellow"
          type="password"
          placeholder="Confirm Password"
          id="password"
          value={confirmPassword}
          onChange={event => {
            setConfirmPassword(event.target.value)
          }}
        />
        <button className="bg-yellow button black-text" type="submit">
          Submit
        </button>
      </form>
    </div>
  )
}
