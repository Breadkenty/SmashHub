import React, { useState, useEffect } from 'react'
import { Link } from 'react-router-dom'

import moment from 'moment'
import YouTube from 'react-youtube'

import { useParams } from 'react-router'
import { authHeader, getUserId, getUser, isLoggedIn } from '../auth'

import { allCharacterPortrait } from '../components/allCharacterPortrait'
import { allComboInputs } from '../components/combo-inputs/allComboInputs'
import { returnDifficulty } from '../components/returnDifficulty'
import { returnTrueCombo } from '../components/returnTrueCombo'

import { SortController } from '../components/SortController'
import { sortingFunctions } from '../components/sortingFunctions'

import { Comment } from './Comment'

export function CharacterCombo() {
  const params = useParams()
  const loggedInUser = getUser()
  const characterVariableName = params.characterVariableName
  const comboId = params.comboId

  const [character, setCharacter] = useState({})

  const [combo, setCombo] = useState({
    id: 0,
    userId: 0,
    characterId: 0,
    user: {},
    datePosted: '',
    title: '',
    videoId: '',
    videoStartTime: 0,
    videoEndTime: 0,
    comboInput: '',
    trueCombo: false,
    difficulty: '',
    damage: 0,
    notes: '',
    comments: [],
    netVote: 0,
  })

  const [reportingCombo, setReportingCombo] = useState(false)
  const [comboReport, setComboReport] = useState({
    userId: 0,
    reporterId: 0,
    body: '',
  })

  const [comment, setComment] = useState({
    comboId: parseInt(comboId),
    user: {
      displayName: loggedInUser.displayName,
    },
    body: '',
  })

  let [sortType, setSortType] = useState('best')

  const [errorMessage, setErrorMessage] = useState()

  function getCharacter() {
    fetch(`/api/Characters/${characterVariableName}`)
      .then(response => response.json())
      .then(apiData => {
        setCharacter(apiData)
      })
  }

  function getCombo() {
    fetch(`/api/Combos/${comboId}`)
      .then(response => response.json())
      .then(apiData => {
        setCombo(apiData)
      })
  }

  const opts = {
    playerVars: {
      autoplay: 1,
      mute: 1,
      playsinline: 1,
      start: combo.videoStartTime,
      end: combo.videoEndTime,
    },
  }

  function onStateChange(state) {
    if (state.data === 0) {
      state.target.seekTo(combo.videoStartTime)
    }
  }

  function handleSubmit(event) {
    event.preventDefault()
    fetch('/api/Comments', {
      method: 'POST',
      headers: { 'content-type': 'application/json', ...authHeader() },
      body: JSON.stringify(comment),
    })
      .then(response => {
        if (response.status === 401) {
          return { status: 401, errors: { login: 'Log in to comment' } }
        } else {
          return response.json()
        }
      })
      .then(apiData => {
        if (apiData.status === 400 || apiData.status === 401) {
          const newMessage = Object.values(apiData.errors).join(' ')
          setErrorMessage(newMessage)
        } else {
          getCombo()
          setComment({ ...comment, body: '' })
          setSortType('newest')
          setErrorMessage(undefined)
        }
      })
  }

  function handleVote(event, voteType, id, upOrDown) {
    event.preventDefault()

    fetch(`/api/${voteType}/${id}/${upOrDown}`, {
      method: 'POST',
      headers: { 'content-type': 'application/json', ...authHeader() },
    }).then(() => {
      getCombo()
    })
  }

  function handleReportSubmit(event) {
    event.preventDefault()
    console.log('Combo Report: ')
    console.log(comboReport)
  }

  combo.comments.sort(sortingFunctions[sortType])

  useEffect(getCharacter, [])
  useEffect(getCombo, [])

  return (
    <div className="character-combo">
      {/* Character image header */}
      <header
        className="character-header"
        style={{
          backgroundImage: `url(${
            allCharacterPortrait[character.variableName]
          })`,
          backgroundPositionY: `${character.yPosition}%`,
        }}
      >
        <h1>{character.name}</h1>
      </header>

      {/* Video */}
      <YouTube
        videoId={`${combo.videoId}`}
        opts={opts}
        onStateChange={onStateChange}
      />

      <article>
        <header>
          {/* Combo Votes */}
          <div className="vote">
            <button
              className="button-blank"
              onClick={event => {
                handleVote(event, 'ComboVotes', comboId, 'upvote')
              }}
            >
              <svg
                aria-hidden="true"
                className="m0 svg-icon iconArrowUpLg"
                width="36"
                height="36"
                viewBox="0 0 36 36"
              >
                <path d="M2 26h32L18 10 2 26z"></path>
              </svg>
            </button>

            <h3 className="black-text">{combo.netVote}</h3>

            <button
              className="button-blank"
              onClick={event => {
                handleVote(event, 'ComboVotes', comboId, 'downvote')
              }}
            >
              <svg
                aria-hidden="true"
                className="m0 svg-icon iconArrowDownLg"
                width="36"
                height="36"
                viewBox="0 0 36 36"
              >
                <path d="M2 10h32L18 26 2 10z"></path>
              </svg>
            </button>
          </div>

          {/* Combo detail */}
          <div className="detail">
            <h5>
              Posted by {combo.user.displayName}{' '}
              {moment(combo.datePosted).fromNow()}
              {loggedInUser.id === combo.userId && (
                <Link
                  to={`/character/${characterVariableName}/${combo.id}/edit`}
                >
                  <h5>edit</h5>
                </Link>
              )}
              <button
                onClick={() => {
                  setReportingCombo(true)
                }}
              >
                <h5>report</h5>
              </button>
            </h5>

            <h2>{combo.title}</h2>

            <div>
              <h4>DMG: {combo.damage}%</h4>
              {returnDifficulty(combo.difficulty)}
              {returnTrueCombo(combo.trueCombo)}
            </div>
          </div>
        </header>

        <form
          className="report"
          style={reportingCombo ? { display: 'flex' } : { display: 'none' }}
          onSubmit={handleReportSubmit}
        >
          <i
            className="fas fa-times"
            onClick={() => {
              setReportingCombo(false)
            }}
          ></i>
          <h4>Report this combo</h4>
          <textarea
            placeholder="reason..."
            value={comboReport.body}
            onChange={event => {
              setComboReport({ ...comboReport, body: event.target.value })
            }}
          />
          <button className="button">Submit</button>
        </form>

        {/* Combo inputs */}
        <section className="bg-grey combo-inputs">
          {`${combo.comboInput}`.split(' ').map((input, index) => (
            <div
              key={index}
              className="combo-input"
              style={{
                backgroundImage: `url(${allComboInputs[input]})`,
              }}
            ></div>
          ))}
        </section>

        {/* Combo Notes */}
        <section className="notes">
          <h4>Notes:</h4>
          <p>{combo.notes}</p>
        </section>

        {(isLoggedIn() && (
          <form className="add-comment bg-grey" onSubmit={handleSubmit}>
            <textarea
              placeholder="Add a comment"
              value={comment.body}
              onChange={event => {
                setComment({ ...comment, body: event.target.value })
              }}
            />
            <button className="bg-yellow button black-text" type="submit">
              Submit
            </button>
          </form>
        )) || (
          <Link to="/login">
            <h5 className="prevent-commenting">Please log in to comment</h5>
          </Link>
        )}

        {errorMessage && (
          <div className="error-message">
            <i class="fas fa-exclamation-triangle"></i> {errorMessage}
          </div>
        )}
        <section className="sort">
          <SortController sortType={sortType} setSortType={setSortType} />
        </section>

        <section className="comments">
          {combo.comments.map(comment => (
            <Comment
              key={comment.id}
              loggedInUser={loggedInUser}
              handleVote={handleVote}
              comment={comment}
              getCombo={getCombo}
            />
          ))}
        </section>
      </article>
    </div>
  )
}
