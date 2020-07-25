import React, { useState } from 'react'
import { useHistory } from 'react-router'

export function AddCharacter() {
  const history = useHistory()

  const [newCharacter, setNewCharacter] = useState({
    name: '',
    variableName: '',
    yPosition: 0,
  })

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
      headers: { 'content-type': 'application/json' },
      body: JSON.stringify(newCharacter),
    })
      .then(response => response.json())
      .then(history.push('/'))
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

      <button type="submit" className="button bg-yellow black-text">
        Submit
      </button>
    </form>
  )
}
