import React, { useState, useEffect } from 'react'
import { useHistory } from 'react-router'
import { authHeader } from '../auth'

import { allCharacterPortrait } from '../components/allCharacterPortrait'
import { allComboInputs } from '../components/combo-inputs/allComboInputs'

import { Basic } from '../components/combo-inputs/Basic'
import { Move } from '../components/combo-inputs/Move'
import { Flick } from '../components/combo-inputs/Flick'
import { Hop } from '../components/combo-inputs/Hop'
import { Conditional } from '../components/combo-inputs/Conditional'
import { Tilt } from '../components/combo-inputs/Tilt'
import { Aerial } from '../components/combo-inputs/Aerial'
import { Smash } from '../components/combo-inputs/Smash'
import { Special } from '../components/combo-inputs/Special'
import { Throw } from '../components/combo-inputs/Throw'

export function SubmitCombo() {
  const history = useHistory()

  const [characters, setCharacters] = useState([])

  const [characterSelected, setCharacterSelected] = useState({
    variableName: 'Mario',
    yPosition: 30,
  })

  let [startMinutes, setStartMinutes] = useState()
  let [startSeconds, setStartSeconds] = useState()
  let [endMinutes, setEndMinutes] = useState()
  let [endSeconds, setEndSeconds] = useState()

  let [selectedDifficulty, setSelectedDifficulty] = useState('very easy')

  let [trueCombo, setTrueCombo] = useState('true')

  const inputCategories = [
    'Basic',
    'Move',
    'Flick',
    'Hop',
    'Conditional',
    'Tilt',
    'Aerial',
    'Smash',
    'Special',
    'Throw',
  ]
  let [inputCategory, setInputCategory] = useState('Basic')
  let [inputs, setInputs] = useState('')

  const [newCombo, setNewCombo] = useState({
    characterId: 1,
    title: '',
    videoId: '',
    videoStartTime: 0,
    videoEndTime: 0,
    comboInput: '',
    trueCombo: true,
    difficulty: 'very easy',
    damage: 0,
    notes: '',
  })

  const [errorMessage, setErrorMessage] = useState()

  const handleFieldChange = event => {
    event.preventDefault()
    const value = event.target.value
    const id = event.target.id

    if (id === 'characterId') {
      setNewCombo({
        ...newCombo,
        [id]: parseInt(value),
      })
    } else if (id === 'difficulty') {
      setSelectedDifficulty(value)
      setNewCombo({
        ...newCombo,
        [id]: value,
      })
    } else if (id === 'trueCombo' && value === 'true') {
      setTrueCombo(true)
      setNewCombo({
        ...newCombo,
        trueCombo: true,
      })
    } else if (id === 'trueCombo' && value === 'false') {
      setTrueCombo(false)
      setNewCombo({
        ...newCombo,
        trueCombo: false,
      })
    } else if (id === 'damage') {
      setNewCombo({
        ...newCombo,
        [id]: parseInt(value),
      })
    } else {
      setNewCombo({
        ...newCombo,
        [id]: value,
      })
    }
  }

  const changeCharacterPortrait = event => {
    const foundCharacterById = characters.find(
      character => character.id === parseInt(event.target.value)
    )

    setCharacterSelected({
      ...characterSelected,
      variableName: foundCharacterById.variableName,
      yPosition: foundCharacterById.yPosition,
    })
  }

  function addInput(event) {
    event.preventDefault()
    if (inputs.length === 0) {
      setInputs(inputs + event.target.value)
    } else {
      setInputs(inputs + ' ' + event.target.value)
    }
  }

  function removeInput() {
    const lastIndex = inputs.lastIndexOf(' ')
    setInputs(inputs.substring(0, lastIndex))
  }

  function getCharacters() {
    fetch('/api/Characters')
      .then(response => response.json())
      .then(apiData => {
        setCharacters(apiData)
      })
  }

  function renderInputCategoryComponents() {
    switch (inputCategory) {
      case 'Basic':
        return (
          <>
            <Basic key={inputCategories['Basic']} addInput={addInput} />
          </>
        )
      case 'Move':
        return (
          <>
            <Move key={inputCategories['Move']} addInput={addInput} />
          </>
        )
      case 'Flick':
        return (
          <>
            <Flick key={inputCategories['Flick']} addInput={addInput} />
          </>
        )

      case 'Hop':
        return (
          <>
            <Hop key={inputCategories['Hop']} addInput={addInput} />
          </>
        )

      case 'Conditional':
        return (
          <>
            <Conditional
              key={inputCategories['Conditional']}
              addInput={addInput}
            />
          </>
        )

      case 'Tilt':
        return (
          <>
            <Tilt key={inputCategories['Tilt']} addInput={addInput} />
          </>
        )

      case 'Aerial':
        return (
          <>
            <Aerial key={inputCategories['Aerial']} addInput={addInput} />
          </>
        )

      case 'Smash':
        return (
          <>
            <Smash key={inputCategories['Smash']} addInput={addInput} />
          </>
        )

      case 'Special':
        return (
          <>
            <Special key={inputCategories['Special']} addInput={addInput} />
          </>
        )

      case 'Throw':
        return (
          <>
            <Throw key={inputCategories['Throw']} addInput={addInput} />
          </>
        )
    }
  }

  function handleSubmit(event) {
    event.preventDefault()

    const comboToSubmit = {
      ...newCombo,
      videoStartTime:
        parseInt(startMinutes || 0) * 60 + parseInt(startSeconds || 0),
      videoEndTime: parseInt(endMinutes || 0) * 60 + parseInt(endSeconds || 0),
    }

    console.log('Submit:')
    console.log(JSON.stringify(comboToSubmit))
    fetch('/api/Combos', {
      method: 'POST',
      headers: { 'content-type': 'application/json', ...authHeader() },
      body: JSON.stringify(comboToSubmit),
    })
      .then(response => {
        if (response.status === 401) {
          return { status: 401, errors: { login: 'Not Authorized' } }
        } else {
          return response.json()
        }
      })
      .then(apiData => {
        if (apiData.status === 400 || apiData.status === 401) {
          console.log(Object.values(apiData.errors).join(' '))
          const newMessage = Object.values(apiData.errors).join(' ')
          setErrorMessage(newMessage)
        } else {
          history.push('/')
        }
      })
  }

  // Set inputs when the input field changes
  useEffect(() => {
    setNewCombo({
      ...newCombo,
      comboInput: inputs,
    })
  }, [inputs])

  // Get all characters from API
  useEffect(getCharacters, [])

  console.log(newCombo)
  return (
    <div className="submit-combo">
      <header>
        <h1>New combo</h1>
      </header>

      <section className="bg-grey">
        <form onSubmit={handleSubmit}>
          <fieldset className="select-character">
            <label htmlFor="select-character">Choose a character</label>
            <div
              style={{
                backgroundImage: `url(${
                  allCharacterPortrait[characterSelected.variableName]
                })`,
                backgroundPositionY: `${characterSelected.yPosition}%`,
              }}
              className="character bg-black"
            >
              <select
                name="select-character"
                id="characterId"
                onChange={event => {
                  handleFieldChange(event)
                  changeCharacterPortrait(event)
                }}
                required
              >
                {characters.map(character => (
                  <option key={character.id} value={character.id}>
                    {character.name}
                  </option>
                ))}
              </select>
            </div>
          </fieldset>

          <fieldset className="title">
            <label htmlFor="title">Title</label>
            <input
              name="title"
              className="bg-yellow"
              id="title"
              type="text"
              placeholder="eg. Down-throw bair"
              onChange={handleFieldChange}
              required
            />
          </fieldset>

          <fieldset className="video">
            <label htmlFor="video-id">Youtube video ID</label>
            <input
              className="bg-yellow"
              id="videoId"
              type="text"
              placeholder="eg. IE1lyGZgLOs"
              onChange={handleFieldChange}
              required
            />
          </fieldset>

          <div className="duration ">
            <fieldset>
              <label htmlFor="video-start">Start time in video</label>
              <div className="bg-yellow">
                <input
                  className="bg-yellow"
                  type="number"
                  max="60"
                  min="0"
                  id="startMinutes"
                  placeholder="00"
                  value={startMinutes}
                  onChange={event => {
                    if (event.target.value > 59) {
                      setStartMinutes(59)
                    } else {
                      setStartMinutes(parseInt(event.target.value))
                    }
                  }}
                />
                <span>:</span>
                <input
                  className="bg-yellow"
                  type="number"
                  max="60"
                  min="0"
                  id="startSeconds"
                  placeholder="00"
                  value={startSeconds}
                  onChange={event => {
                    if (event.target.value > 59) {
                      setStartSeconds(59)
                    } else {
                      setStartSeconds(parseInt(event.target.value))
                    }
                  }}
                />
              </div>
            </fieldset>

            <fieldset>
              <label htmlFor="video-end">End time in video</label>
              <div className="bg-yellow">
                <input
                  className="bg-yellow"
                  type="number"
                  max="60"
                  min="0"
                  id="video-end"
                  placeholder="00"
                  value={endMinutes}
                  onChange={event => {
                    if (event.target.value > 59) {
                      setEndMinutes(59)
                    } else {
                      setEndMinutes(parseInt(event.target.value))
                    }
                  }}
                />
                <span>:</span>
                <input
                  className="bg-yellow"
                  type="number"
                  max="60"
                  min="0"
                  id="video-end"
                  placeholder="00"
                  value={endSeconds}
                  onChange={event => {
                    if (event.target.value > 59) {
                      setEndSeconds(59)
                    } else {
                      setEndSeconds(parseInt(event.target.value))
                    }
                  }}
                />
              </div>
            </fieldset>
          </div>

          <fieldset className="difficulty">
            <label>Difficulty</label>
            <div>
              <button
                className={`button bg-blue ${
                  selectedDifficulty === 'very easy' ? 'active-button' : ''
                }`}
                id="difficulty"
                value="very easy"
                onClick={handleFieldChange}
              >
                Very Easy
              </button>
              <button
                className={`button bg-green ${
                  selectedDifficulty === 'easy' ? 'active-button' : ''
                }`}
                id="difficulty"
                value="easy"
                onClick={handleFieldChange}
              >
                Easy
              </button>
              <button
                className={`button bg-yellow ${
                  selectedDifficulty === 'medium' ? 'active-button' : ''
                }`}
                id="difficulty"
                value="medium"
                onClick={handleFieldChange}
              >
                Medium
              </button>
              <button
                className={`button bg-pink ${
                  selectedDifficulty === 'hard' ? 'active-button' : ''
                }`}
                id="difficulty"
                value="hard"
                onClick={handleFieldChange}
              >
                Hard
              </button>
              <button
                className={`button bg-red ${
                  selectedDifficulty === 'very hard' ? 'active-button' : ''
                }`}
                id="difficulty"
                value="very hard"
                onClick={handleFieldChange}
              >
                Very Hard
              </button>
            </div>
          </fieldset>

          <fieldset className="true-combo">
            <label>True Combo</label>
            <div>
              <button
                className={`button bg-green ${
                  trueCombo ? 'active-button' : ''
                }`}
                id="trueCombo"
                value="true"
                onClick={handleFieldChange}
              >
                Yes
              </button>
              <button
                className={`button bg-red ${!trueCombo ? 'active-button' : ''}`}
                id="trueCombo"
                value="false"
                onClick={handleFieldChange}
              >
                No
              </button>
            </div>
          </fieldset>

          <fieldset className="damage">
            <label>Damage</label>
            <div className="container bg-yellow">
              <input
                className="bg-yellow"
                type="number"
                placeholder="0"
                id="damage"
                onChange={handleFieldChange}
                required
              />
              <span className="bg-yellow">%</span>
            </div>
          </fieldset>

          <fieldset className="combo-input">
            <label>Combo input</label>

            <div
              className="combo-input-container bg-black"
              onClick={removeInput}
            >
              <div className="combo-inputs">
                {inputs.split(' ').map((input, index) => (
                  <div
                    key={index}
                    className="combo-input"
                    style={{
                      backgroundImage: `url(${allComboInputs[input]})`,
                    }}
                  />
                ))}
              </div>
              <p>*Click this area to go back one input*</p>
            </div>
            <div className="input-categories">
              {inputCategories.map(inputCategory => (
                <button
                  key={inputCategory}
                  onClick={event => {
                    event.preventDefault()
                    setInputCategory(inputCategory)
                  }}
                >
                  {inputCategory}
                </button>
              ))}
            </div>

            <div className="input-controller bg-black">
              {renderInputCategoryComponents()}
            </div>
          </fieldset>

          <fieldset className="notes">
            <label htmlFor="notes">Notes</label>
            <div>
              <textarea
                placeholder="Additional notes"
                id="notes"
                onChange={handleFieldChange}
              />
              {errorMessage && (
                <div className="alert alert-danger" role="alert">
                  {errorMessage}
                </div>
              )}
              <button type="submit" className="button bg-yellow black-text">
                Submit
              </button>
            </div>
          </fieldset>
        </form>
      </section>
    </div>
  )
}
