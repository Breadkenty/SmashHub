import React, { useState, useEffect } from 'react'
import { useHistory } from 'react-router'
import { useParams } from 'react-router'
import { authHeader } from '../auth'
import YouTube from 'react-youtube'

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

export function EditCombo() {
  const history = useHistory()

  const params = useParams()
  const characterVariableName = params.characterVariableName
  const comboId = params.comboId

  const [characterSelected, setCharacterSelected] = useState({
    name: '',
    variableName: '',
    yPosition: 0,
  })

  const [comboToEdit, setComboToEdit] = useState({
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

  let [startMinutes, setStartMinutes] = useState()
  let [startSeconds, setStartSeconds] = useState()
  let [endMinutes, setEndMinutes] = useState()
  let [endSeconds, setEndSeconds] = useState()

  let [startTime, setStartTime] = useState()
  let [endTime, setEndTime] = useState()

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

  const [videoInformationById, setVideoInformationById] = useState({})
  const [videoExists, setVideoExists] = useState(true)

  const [deleteMenuDisplay, setDeleteMenuDisplay] = useState(false)
  const [deleteMenuInput, setDeleteMenuInput] = useState('')
  const [invalidDeleteInput, setInvalidDeleteInput] = useState(false)

  const [errorMessage, setErrorMessage] = useState()

  const handleFieldChange = event => {
    event.preventDefault()
    const value = event.target.value
    const id = event.target.id

    if (id === 'characterId') {
      setComboToEdit({
        ...comboToEdit,
        [id]: parseInt(value),
      })
    } else if (id === 'difficulty') {
      setSelectedDifficulty(value)
      setComboToEdit({
        ...comboToEdit,
        [id]: value,
      })
    } else if (id === 'trueCombo' && value === 'true') {
      setTrueCombo(true)
      setComboToEdit({
        ...comboToEdit,
        trueCombo: true,
      })
    } else if (id === 'trueCombo' && value === 'false') {
      setTrueCombo(false)
      setComboToEdit({
        ...comboToEdit,
        trueCombo: false,
      })
    } else if (id === 'damage') {
      setComboToEdit({
        ...comboToEdit,
        [id]: parseInt(value),
      })
    } else {
      setComboToEdit({
        ...comboToEdit,
        [id]: value,
      })
    }
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

  function getCharacter() {
    fetch(`/api/Characters/${characterVariableName}`)
      .then(response => response.json())
      .then(apiData => {
        setCharacterSelected({
          ...characterSelected,
          name: apiData.name,
          variableName: characterVariableName,
          yPosition: apiData.yPosition,
        })
      })
  }

  function getCombo() {
    fetch(`/api/Combos/${comboId}`)
      .then(response => response.json())
      .then(apiData => {
        setComboToEdit(apiData)
        setSelectedDifficulty(apiData.difficulty)
        setTrueCombo(apiData.trueCombo)
        setInputs(apiData.comboInput)
        setStartMinutes(
          (apiData.videoStartTime - (apiData.videoStartTime % 60)) / 60
        )
        setStartSeconds(apiData.videoStartTime % 60)
        setEndMinutes((apiData.videoEndTime - (apiData.videoEndTime % 60)) / 60)
        setEndSeconds(apiData.videoEndTime % 60)
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
      ...comboToEdit,
      videoStartTime:
        parseInt(startMinutes || 0) * 60 + parseInt(startSeconds || 0),
      videoEndTime: parseInt(endMinutes || 0) * 60 + parseInt(endSeconds || 0),
    }

    fetch(`/api/Combos/${comboId}`, {
      method: 'PUT',
      headers: { 'content-type': 'application/json', ...authHeader() },
      body: JSON.stringify(comboToSubmit),
    })
      .then(response => {
        if (response.status === 401) {
          return { status: 401, errors: { login: 'Not Authorized' } }
        } else if (response.status === 404) {
          // This one is for user doesn't match logged in user
          return { status: 404, errors: { login: 'Not Authorized' } }
        } else {
          return response.json()
        }
      })
      .then(apiData => {
        if (apiData.errors) {
          const newMessage = Object.values(apiData.errors).join(' ')
          setErrorMessage(newMessage)
        } else {
          history.push(`/character/${characterVariableName}/${comboId}`)
        }
      })
  }

  function handleDelete(event) {
    event.preventDefault()

    if (deleteMenuInput === comboToEdit.title) {
      fetch(`/api/Combos/${comboId}`, {
        method: 'DELETE',
        headers: { ...authHeader() },
      })
        .then(response => {
          if (response.status === 404 || response.status === 401) {
            return { status: 401, errors: { login: 'Not Authorized' } }
          } else {
            return response.json()
          }
        })
        .then(apiData => {
          if (apiData.status === 401) {
            const newMessage = Object.values(apiData.errors).join(' ')
            setErrorMessage(newMessage)
          } else {
            history.push(`/character/${characterVariableName}`)
          }
        })
    } else {
      setInvalidDeleteInput(true)
    }
  }

  function checkVideoExists(event) {
    const keyWords = ['super', 'smash', 'bros', 'ultimate', 'ssbu']

    fetch(
      `https://www.googleapis.com/youtube/v3/videos?part=snippet&id=${event.target.value}&key=${process.env.REACT_APP_YOUTUBE_KEY}`
    )
      .then(response => {
        return response.json()
      })
      .then(apiData => {
        if (apiData.items.length === 0) {
          setVideoExists(false)
        } else if (
          apiData.items[0].snippet.title
            .toLowerCase()
            .includes(characterSelected.name.toLowerCase()) ||
          apiData.items[0].snippet.description
            .toLowerCase()
            .includes(characterSelected.name.toLowerCase()) ||
          keyWords.some(keyWord =>
            apiData.items[0].snippet.title.toLowerCase().includes(keyWord)
          ) ||
          keyWords.some(keyWord =>
            apiData.items[0].snippet.description.toLowerCase().includes(keyWord)
          )
        ) {
          setVideoInformationById(apiData.items[0].snippet)
          setVideoExists(true)
        } else {
          setVideoExists(false)
        }
      })
  }

  const opts = {
    playerVars: {
      autoplay: 1,
      mute: 1,
      playsinline: 1,
      start: startTime || 0,
      end: endTime || 0,
    },
  }

  function onStateChange(state) {
    if (state.data === 0) {
      state.target.seekTo(startTime || 0)
    }
  }

  // Set inputs when the input field changes
  useEffect(() => {
    setComboToEdit({
      ...comboToEdit,
      comboInput: inputs,
    })
  }, [inputs])

  useEffect(() => {
    setStartTime(parseInt(startMinutes || 0) * 60 + parseInt(startSeconds || 0))
  }, [startMinutes, startSeconds])
  useEffect(() => {
    setEndTime(parseInt(endMinutes || 0) * 60 + parseInt(endSeconds || 0))
  }, [endMinutes, endSeconds])

  // Get all characters from API
  useEffect(getCombo, [])
  useEffect(getCharacter, [])
  return (
    <div className="submit-combo">
      <header>
        <h1>Edit combo</h1>
      </header>

      <section className="bg-grey">
        <form onSubmit={handleSubmit}>
          <div className="select-character">
            <div
              style={{
                backgroundImage: `url(${allCharacterPortrait[characterVariableName]})`,
                backgroundPositionY: `${characterSelected.yPosition}%`,
              }}
              className="character bg-black"
            >
              <h2>{characterSelected.name}</h2>
            </div>
          </div>

          <fieldset className="title">
            <label htmlFor="title">Title</label>
            <input
              name="title"
              className="bg-yellow"
              id="title"
              type="text"
              placeholder="eg. Down-throw bair"
              value={comboToEdit.title}
              onChange={handleFieldChange}
              required
            />
          </fieldset>

          <fieldset className="video">
            {videoExists && (
              <YouTube
                videoId={`${comboToEdit.videoId}`}
                opts={opts}
                onStateChange={onStateChange}
              />
            )}

            <label htmlFor="video-id">Youtube video ID</label>
            <input
              className="bg-yellow"
              id="videoId"
              type="text"
              placeholder="eg. IE1lyGZgLOs"
              value={comboToEdit.videoId}
              onChange={event => {
                handleFieldChange(event)
                checkVideoExists(event)
              }}
              required
            />
            {videoExists || (
              <p>
                Invalid video, please enter a valid ID that relates to your
                selected character
              </p>
            )}
            {videoExists && <p>Good video: {videoInformationById.title}</p>}
          </fieldset>

          <div className="duration ">
            <fieldset>
              <label htmlFor="video-start">Start time in video</label>
              <div>
                <input
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
              <div>
                <input
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
              <div
                className={`button-wrapper ${
                  selectedDifficulty === 'very easy' ? 'active-button' : ''
                }`}
              >
                <button
                  className="button bg-blue"
                  id="difficulty"
                  value="very easy"
                  onClick={handleFieldChange}
                >
                  Very Easy
                </button>
              </div>

              <div
                className={`button-wrapper ${
                  selectedDifficulty === 'easy' ? 'active-button' : ''
                }`}
              >
                <button
                  className="button bg-green"
                  id="difficulty"
                  value="easy"
                  onClick={handleFieldChange}
                >
                  Easy
                </button>
              </div>

              <div
                className={`button-wrapper ${
                  selectedDifficulty === 'medium' ? 'active-button' : ''
                }`}
              >
                <button
                  className="button bg-yellow"
                  id="difficulty"
                  value="medium"
                  onClick={handleFieldChange}
                >
                  Medium
                </button>
              </div>

              <div
                className={`button-wrapper ${
                  selectedDifficulty === 'hard' ? 'active-button' : ''
                }`}
              >
                <button
                  className="button bg-pink"
                  id="difficulty"
                  value="hard"
                  onClick={handleFieldChange}
                >
                  Hard
                </button>
              </div>

              <div
                className={`button-wrapper ${
                  selectedDifficulty === 'very hard' ? 'active-button' : ''
                }`}
              >
                <button
                  className="button bg-blue"
                  id="difficulty"
                  value="very hard"
                  onClick={handleFieldChange}
                >
                  Very Hard
                </button>
              </div>
            </div>
          </fieldset>

          <fieldset className="true-combo">
            <label>True Combo</label>
            <div>
              <div
                className={`button-wrapper ${trueCombo ? 'active-button' : ''}`}
              >
                <button
                  className="button bg-green"
                  id="trueCombo"
                  value="true"
                  onClick={handleFieldChange}
                >
                  Yes
                </button>
              </div>
              <div
                className={`button-wrapper ${
                  !trueCombo ? 'active-button' : ''
                }`}
              >
                <button
                  className="button bg-red"
                  id="trueCombo"
                  value="false"
                  onClick={handleFieldChange}
                >
                  No
                </button>
              </div>
            </div>
          </fieldset>

          <fieldset className="damage">
            <label>Damage</label>
            <div className="container">
              <input
                type="number"
                placeholder="0"
                id="damage"
                onChange={handleFieldChange}
                required
              />
              <span>%</span>
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
                value={comboToEdit.notes}
                onChange={handleFieldChange}
              />
              {errorMessage && (
                <div className="error-message">
                  <i class="fas fa-exclamation-triangle"></i> {errorMessage}
                </div>
              )}
              <div className="submit-buttons">
                <button type="submit" className="button bg-yellow black-text">
                  Submit
                </button>
                <button
                  className="button bg-red white-text"
                  onClick={event => {
                    event.preventDefault()
                    setDeleteMenuDisplay(true)
                  }}
                >
                  Delete
                </button>
              </div>
              {deleteMenuDisplay && (
                <div className="confirm-delete bg-black">
                  <i
                    className="fas fa-times"
                    onClick={() => {
                      setDeleteMenuDisplay(false)
                    }}
                  ></i>
                  <div className="error-message">
                    <i class="fas fa-exclamation-triangle"></i>{' '}
                    <h3>Danger zone</h3>
                  </div>
                  <label>
                    type in <span>{comboToEdit.title}</span> to delete
                  </label>
                  <input
                    type="text"
                    className="bg-yellow black-text"
                    placeholder={comboToEdit.title}
                    onChange={event => {
                      setDeleteMenuInput(event.target.value)
                    }}
                  />
                  {invalidDeleteInput && <h5>Invalid input</h5>}
                  <button
                    type="submit"
                    className="button bg-red white-text"
                    onClick={handleDelete}
                  >
                    Delete
                  </button>
                </div>
              )}
            </div>
          </fieldset>
        </form>
      </section>
    </div>
  )
}
