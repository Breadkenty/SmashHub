import React, { useState, useEffect } from 'react'
import { Link } from 'react-router-dom'

import moment from 'moment'
import YouTube from 'react-youtube'

import { useParams } from 'react-router'
import { authHeader, getUserId } from '../auth'

import { allCharacterPortrait } from '../components/allCharacterPortrait'
import { allComboInputs } from '../components/combo-inputs/allComboInputs'
import { returnDifficulty } from '../components/returnDifficulty'
import { returnTrueCombo } from '../components/returnTrueCombo'

import { SortController } from '../components/SortController'
import { sortingFunctions } from '../components/sortingFunctions'

import { Comment } from './Comment'

export function CharacterCombo() {
  const params = useParams()
  const characterVariableName = params.characterVariableName
  const comboId = params.comboId

  const [character, setCharacter] = useState({})

  const [combo, setCombo] = useState({})
  const [comboAuthor, setComboAuthor] = useState('')

  const [comments, setComments] = useState([])
  const [comment, setComment] = useState({
    comboId: parseInt(comboId),
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
        setComments(apiData.comments)
        setComboAuthor(apiData.user.displayName)
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

  const loggedInUser = getUserId()

  const sortedComments = comments.sort(sortingFunctions[sortType])

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
              Posted by {comboAuthor} {moment(combo.datePosted).fromNow()}
              {loggedInUser === combo.userId && (
                <Link
                  to={`/character/${characterVariableName}/${combo.id}/edit`}
                >
                  <h5>edit</h5>
                </Link>
              )}
            </h5>

            <h2>{combo.title}</h2>

            <div>
              <h4>DMG: {combo.damage}%</h4>
              {returnDifficulty(combo.difficulty)}
              {returnTrueCombo(combo.trueCombo)}
            </div>
          </div>
        </header>

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

        {errorMessage && (
          <div className="alert alert-danger" role="alert">
            {errorMessage}
          </div>
        )}
        <section className="sort">
          <SortController sortType={sortType} setSortType={setSortType} />
        </section>

        <section className="comments">
          {comments.map(comment => (
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
