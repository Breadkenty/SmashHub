import React, { useState } from 'react'
import { useHistory } from 'react-router'
import { authHeader } from '../auth'

export function AddCharacter() {
  const history = useHistory()

  const [newCharacter, setNewCharacter] = useState({
    name: '',
    variableName: '',
    yPosition: 0,
  })
  const [errorMessage, setErrorMessage] = useState()

  function handleTextChange(event) {
    setNewCharacter({
      ...newCharacter,
      [event.target.id]: event.target.value,
    })
  }

  function handleNumberChange(event) {
    setNewCharacter({
      ...newCharacter,
      [event.target.id]: parseInt(event.target.value),
    })
  }

  function handleSubmit(event) {
    event.preventDefault()
    fetch('/api/Characters', {
      method: 'POST',
      headers: { 'content-type': 'application/json', ...authHeader() },
      body: JSON.stringify(newCharacter),
    })
      .then(response => {
        if (response.status === 400) {
          return { status: 400, errors: { login: 'Not Authorized' } }
        } else {
          return response.json()
        }
      })
      .then(apiData => {
        if (apiData.status === 400 || apiData.status === 401) {
          const newMessage = Object.values(apiData.errors).join(' ')
          setErrorMessage(newMessage)
        } else {
          history.push('/')
        }
      })
  }

  return (
    <form className="add-character" onSubmit={handleSubmit}>
      <fieldset>
        <label htmlFor="name">Name</label>
        <input
          className="bg-yellow"
          name="name"
          id="name"
          type="text"
          placeholder="Mario"
          value={newCharacter.name}
          onChange={handleTextChange}
          required
        />
      </fieldset>

      <fieldset>
        <label htmlFor="variableName">VariableName</label>
        <input
          className="bg-yellow"
          name="variableName"
          id="variableName"
          type="text"
          placeholder="ZeroSuitSamus"
          value={newCharacter.variableName}
          onChange={handleTextChange}
          required
        />
      </fieldset>

      <fieldset>
        <label htmlFor="yPosition">Y Position</label>
        <input
          className="bg-yellow"
          name="yPosition"
          id="yPosition"
          type="number"
          placeholder="20"
          value={newCharacter.yPosition}
          onChange={handleNumberChange}
          required
        />
      </fieldset>

      {errorMessage && (
        <div className="error-message">
          <i className="fas fa-exclamation-triangle"></i> {errorMessage}
        </div>
      )}

      <button type="submit" className="button bg-yellow black-text">
        Submit
      </button>
    </form>
  )
}
