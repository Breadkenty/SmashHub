import React, { useState, useEffect } from 'react'
import { authHeader } from '../auth'

import { allCharacterCloseUp } from '../components/allCharacterCloseUp'
import { useHistory } from 'react-router'

export function EditCharacter() {
  const history = useHistory()
  const [characters, setCharacters] = useState([])
  const [errorMessage, setErrorMessage] = useState()
  const [selectedCharacter, setSelectedCharacter] = useState({
    id: '',
    name: '',
    variableName: '',
    yPosition: 0,
  })
  const [
    selectedCharacterVariableName,
    setSelectedCharacterVariableName,
  ] = useState('')

  function handleTextChange(event) {
    setSelectedCharacter({
      ...selectedCharacter,
      [event.target.id]: event.target.value,
    })
  }

  function handleNumberChange(event) {
    setSelectedCharacter({
      ...selectedCharacter,
      [event.target.id]: parseInt(event.target.value) || 0,
    })
  }

  function handleSubmit(event) {
    event.preventDefault()

    fetch(`/api/Characters/${selectedCharacterVariableName}`, {
      method: 'PUT',
      headers: { 'content-type': 'application/json', ...authHeader() },
      body: JSON.stringify(selectedCharacter),
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

  function handleDelete(event) {
    event.preventDefault()

    fetch(`/api/Characters/${selectedCharacterVariableName}`, {
      method: 'DELETE',
      headers: { 'content-type': 'application/json', ...authHeader() },
      body: JSON.stringify(setSelectedCharacter),
    })
      .then(response => {
        if (response.status === 400 || response.status === 401) {
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

  function getCharacters() {
    fetch('/api/Characters')
      .then(response => response.json())
      .then(apiData => {
        setCharacters(apiData)
      })
  }

  useEffect(getCharacters, [])

  return (
    <form className="edit-character" onSubmit={handleSubmit}>
      <div className="characters">
        {characters.map(character => (
          <img
            key={character.id}
            className="character"
            style={{
              backgroundImage: `url(${
                allCharacterCloseUp[character.variableName]
              })`,
            }}
            onClick={() => {
              setSelectedCharacter({
                ...selectedCharacter,
                id: character.id,
                name: character.name,
                variableName: character.variableName,
                yPosition: character.yPosition,
              })
              setSelectedCharacterVariableName(character.variableName)
            }}
          />
        ))}
      </div>
      <div className="update-field">
        <fieldset>
          <label htmlFor="name">Name</label>
          <input
            className="bg-yellow"
            id="name"
            type="text"
            placeholder="Mario"
            value={selectedCharacter.name}
            onChange={handleTextChange}
            required
          />
        </fieldset>

        <fieldset>
          <label htmlFor="variable-name">VariableName</label>
          <input
            className="bg-yellow"
            id="variableName"
            type="text"
            placeholder="ZeroSuitSamus"
            value={selectedCharacter.variableName}
            onChange={handleTextChange}
            required
          />
        </fieldset>

        <fieldset>
          <label htmlFor="y-position">Y Position</label>
          <input
            className="bg-yellow"
            id="yPosition"
            type="text"
            placeholder="20"
            value={selectedCharacter.yPosition}
            onChange={handleNumberChange}
            required
          />
        </fieldset>
        {errorMessage && (
          <div className="error-message">
            <i class="fas fa-exclamation-triangle"></i> {errorMessage}
          </div>
        )}
        <button className="button bg-yellow black-text" type="submit">
          Submit
        </button>
        <button className="button bg-red white-text" onClick={handleDelete}>
          Delete
        </button>
      </div>
    </form>
  )
}
