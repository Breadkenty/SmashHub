import React, { useEffect, useState } from 'react'
import { Link } from 'react-router-dom'
import { allComboInputs } from '../components/combo-inputs/allComboInputs'
import { allCharacterCloseUp } from '../components/allCharacterCloseUp'
import { returnDifficulty } from '../components/returnDifficulty'

import { authHeader, isLoggedIn, getUser } from '../auth'
import moment from 'moment'

export function UserCombo(props) {
  const [votedUp, setVotedUp] = useState(false)
  const [votedDown, setVotedDown] = useState(false)

  function handleVote(event, upOrDown) {
    event.preventDefault()

    fetch(`/api/Votes/combo/${props.combo.id}/${upOrDown}`, {
      method: 'POST',
      headers: { 'content-type': 'application/json', ...authHeader() },
    }).then(response => {
      if (response.status === 204) {
        props.getUserData()
        checkVote(props.combo.id)
      } else {
        props.setErrorMessage('login to vote')
      }
    })
  }

  function checkVote(id) {
    fetch(`/api/Votes/combo/${id}`, {
      method: 'GET',
      headers: { 'content-type': 'application/json', ...authHeader() },
    })
      .then(response => {
        if (response.ok) {
          return response.json()
        } else {
          setVotedUp(false)
          setVotedDown(false)
          return { then: function() {} }
        }
      })
      .then(apiData => {
        if (apiData.isUpvote) {
          setVotedUp(true)
          setVotedDown(false)
        } else {
          setVotedUp(false)
          setVotedDown(true)
        }
      })
    props.getUserData()
  }

  useEffect(() => {
    props.getUserData()
    checkVote()
  }, [])

  useEffect(() => {
    checkVote(props.combo.id)
  }, [votedUp, votedDown])
  return (
    <div key={props.combo.id} className="combo">
      <div className="vote">
        <button
          className="button-blank"
          onClick={event => {
            handleVote(event, 'upvote')
          }}
        >
          <svg viewBox="0 0 81 45" className={votedUp ? 'voted' : ''}>
            <path d="M40.55 3.003L3.015 41.985l19.406.044h.007l18.119-18.818 18.127 18.818h19.357L40.55 3.003z"></path>
          </svg>
        </button>
        <h3 className="black-text">{props.combo.netVote}</h3>
        <button
          className="button-blank"
          onClick={event => {
            handleVote(event, 'downvote')
          }}
        >
          <svg
            className={votedDown ? 'down-vote voted' : 'down-vote'}
            viewBox="0 0 81 45"
          >
            <path d="M40.55 3.003L3.015 41.985l19.406.044h.007l18.119-18.818 18.127 18.818h19.357L40.55 3.003z"></path>
          </svg>
        </button>
      </div>
      <div className="detail">
        <header>
          <div>
            <Link to={`/character/${props.combo.character.variableName}`}>
              <img
                src={
                  allCharacterCloseUp[`${props.combo.character.variableName}`]
                }
                alt={`${props.combo.character.name}'s portrait`}
              />
            </Link>
            <Link
              to={`/character/${props.combo.character.variableName}/${props.combo.id}`}
            >
              <h3>{props.combo.title}</h3>
            </Link>
          </div>
          {returnDifficulty(`${props.combo.difficulty}`)}
        </header>

        <div className="combo-inputs">
          {props.combo.comboInput.split(' ').map((input, index) => (
            <div
              key={index}
              className="combo-input"
              style={{
                backgroundImage: `url(${allComboInputs[input]})`,
              }}
            ></div>
          )) || <></>}
        </div>

        <footer>
          <h5 className="white-text">
            Posted {moment(props.combo.datePosted).fromNow()}
          </h5>
        </footer>
      </div>
    </div>
  )
}
