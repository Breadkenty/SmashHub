import React, { useState, useEffect } from 'react'
import { useForm } from 'react-hook-form'

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

export default function ErrroMessage({ error }) {
  if (error) {
    switch (error.type) {
      case 'required':
        return <p>This is required</p>
      case 'minLength':
        return <p>Your last name need minmium 2 charcaters</p>
      case 'pattern':
        return <p>Enter a valid email address</p>
      case 'min':
        return <p>Minmium age is 18</p>
      case 'validate':
        return <p>Username is already used</p>
      default:
        return null
    }
  }

  return null
}

export function SubmitCombo() {
  const { register, handleSubmit, errors } = useForm()

  const onSubmit = data => {
    console.log(data)
  }

  let [startMinutes, setStartMinutes] = useState()
  let [startSeconds, setStartSeconds] = useState()
  let [endMinutes, setEndMinutes] = useState()
  let [endSeconds, setEndSeconds] = useState()
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
        <form onSubmit={handleSubmit(onSubmit)}>
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
                ref={register({ required: true })}
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
              ref={register({ required: true, maxLength: 70 })}
            />
            {errors.title && <p>This is required</p>}
          </fieldset>

          <fieldset className="video">
            <label htmlFor="video-id">Youtube video ID</label>
            <input
              className="bg-yellow"
              id="videoId"
              type="text"
              placeholder="eg. IE1lyGZgLOs"
              onChange={handleFieldChange}
              ref={register({ required: true })}
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
                  ref={register({ required: true })}
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
                  ref={register({ required: true })}
                />
              </div>
            </fieldset>
            {/* 
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
            </fieldset> */}
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
                ref={register({ required: true })}
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
                    key={input}
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
