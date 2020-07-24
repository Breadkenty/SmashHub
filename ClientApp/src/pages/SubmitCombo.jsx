import React, { useState, useEffect } from 'react'

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
  let [startMinutes, setStartMinutes] = useState(0)
  let [startSeconds, setStartSeconds] = useState(0)
  let [endMinutes, setEndMinutes] = useState(0)
  let [endSeconds, setEndSeconds] = useState(0)
  const [characters, setCharacters] = useState([])
  let [selectedDifficulty, setSelectedDifficulty] = useState('very easy')
  let [trueCombo, setTrueCombo] = useState('true')
  let [inputCategory, setInputCategory] = useState('Basic')

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

  let [inputs, setInputs] = useState('')

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

  const [characterSelected, setCharacterSelected] = useState({
    variableName: 'Mario',
    yPosition: 30,
  })

  const [newCombo, setNewCombo] = useState({
    characterId: 0,
    title: '',
    videoId: '',
    videoStartTime: 0,
    videoEndTime: 0,
    comboInput: '',
    trueCombo: true,
    difficulty: '',
    damage: 0,
    notes: '',
  })

  function handleVideoDuration() {
    setNewCombo({
      ...newCombo,
      videoStartTime: startMinutes * 60 + startSeconds,
      videoEndTime: endMinutes * 60 + endSeconds,
    })
  }

  const handleFieldChange = event => {
    event.preventDefault()
    const value = event.target.value
    const id = event.target.id

    if (id === 'difficulty') {
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

    console.log(characterSelected.variableName)
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
            <Basic addInput={addInput} />
          </>
        )
        break
      case 'Move':
        return (
          <>
            <Move addInput={addInput} />
          </>
        )
        break
      case 'Flick':
        return (
          <>
            <Flick addInput={addInput} />
          </>
        )
        break
      case 'Hop':
        return (
          <>
            <Hop addInput={addInput} />
          </>
        )
        break
      case 'Conditional':
        return (
          <>
            <Conditional addInput={addInput} />
          </>
        )
        break
      case 'Tilt':
        return (
          <>
            <Tilt addInput={addInput} />
          </>
        )
        break
      case 'Aerial':
        return (
          <>
            <Aerial addInput={addInput} />
          </>
        )
        break
      case 'Smash':
        return (
          <>
            <Smash addInput={addInput} />
          </>
        )
        break
      case 'Special':
        return (
          <>
            <Special addInput={addInput} />
          </>
        )
        break
      case 'Throw':
        return (
          <>
            <Throw addInput={addInput} />
          </>
        )
        break
    }
  }

  useEffect(() => {
    setNewCombo({
      ...newCombo,
      comboInput: inputs,
    })
  }, [inputs])

  useEffect(handleVideoDuration, [
    startMinutes,
    startSeconds,
    endMinutes,
    endSeconds,
  ])

  useEffect(getCharacters, [])

  return (
    <div className="submit-combo">
      <header>
        <h1>New combo</h1>
      </header>

      <section className="bg-grey">
        <form>
          <fieldset className="select-character">
            <label for="select-character">Choose a character</label>
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
              >
                {characters.map(character => (
                  <option value={character.id}>{character.name}</option>
                ))}
              </select>
            </div>
          </fieldset>

          <fieldset className="title">
            <label for="title">Title</label>
            <input
              className="bg-yellow"
              id="title"
              type="text"
              placeholder="eg. Down-throw bair"
              onChange={handleFieldChange}
            />
          </fieldset>

          <fieldset className="video">
            <label for="video-id">Youtube video ID</label>
            <input
              className="bg-yellow"
              id="videoId"
              type="text"
              placeholder="eg. IE1lyGZgLOs"
              onChange={handleFieldChange}
            />
          </fieldset>

          {/* <div className="duration ">
            <fieldset>
              <label for="video-start">Start time in video</label>
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
                    if (event.target.value > 60) {
                      setStartMinutes(60)
                    }
                    // else if (!event.target.value) {
                    //   setStartMinutes(0)
                    // }
                    else {
                      setStartMinutes(parseInt(event.target.value))
                    }
                  }}
                />
                <span>:</span>
                <input
                  className="bg-yellow"
                  type="number"
                  s
                  max="60"
                  min="0"
                  id="startSeconds"
                  placeholder="00"
                  value={startSeconds}
                  onChange={event => {
                    if (event.target.value > 60) {
                      setStartSeconds(60)
                    }
                    // else if (!event.target.value) {
                    //   setStartSeconds(0)
                    // }
                    else {
                      event.target.value.substr(1)
                      setStartSeconds(parseInt(event.target.value))
                    }
                  }}
                />
              </div>
            </fieldset>

            <fieldset>
              <label for="video-end">End time in video</label>
              <div className="bg-yellow">
                <input
                  className="bg-yellow"
                  type="number"
                  max="60"
                  min="0"
                  id="video-end"
                  placeholder="00"
                />
                <span>:</span>
                <input
                  className="bg-yellow"
                  type="number"
                  max="60"
                  min="0"
                  id="video-end"
                  placeholder="00"
                />
              </div>
            </fieldset>
          </div> */}

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
                {inputs.split(' ').map(input => (
                  <div
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
            <label for="notes">Notes</label>
            <div>
              <textarea
                placeholder="Additional notes"
                id="notes"
                onChange={handleFieldChange}
              />
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
