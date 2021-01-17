import React, { useEffect, useState } from 'react'
import { Link } from 'react-router-dom'
import { allComboInputs } from '../components/combo-inputs/allComboInputs'
import { returnDifficulty } from '../components/returnDifficulty'
import { authHeader } from '../auth'

import moment from 'moment'

export function CharacterCombo(props) {
  const [votedUp, setVotedUp] = useState(false)
  const [votedDown, setVotedDown] = useState(false)

  function handleVote(event, id, upOrDown) {
    event.preventDefault()

    fetch(`/api/Votes/combo/${id}/${upOrDown}`, {
      method: 'POST',
      headers: { 'content-type': 'application/json', ...authHeader() },
    }).then(() => {
      props.getCharacters()
      checkVote(props.combo.id)
    })
  }

  function checkVote(id) {
    fetch(`/api/Votes/combo/${id}`, {
      method: 'GET',
      headers: { 'content-type': 'application/json', ...authHeader() },
    })
      .then(response => {
        console.log(response)
        if (response.ok) {
          return response.json()
        } else {
          console.log('unvoted')
          setVotedUp(false)
          setVotedDown(false)
          return { then: function() {} }
        }
      })
      .then(apiData => {
        console.log(apiData)
        if (apiData.isUpvote) {
          setVotedUp(true)
          setVotedDown(false)
        } else {
          setVotedUp(false)
          setVotedDown(true)
        }
      })
    props.getCharacters()
  }

  useEffect(() => {
    checkVote(props.combo.id)
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
            handleVote(event, props.combo.id, 'upvote')
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
            handleVote(event, props.combo.id, 'downvote')
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

      <div className="information">
        <header>
          <Link
            to={`/character/${props.characterVariableName}/${props.combo.id}`}
          >
            <h3>{props.combo.title}</h3>
          </Link>
          {returnDifficulty(props.combo.difficulty)}
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
          ))}
        </div>

        <footer>
          <h5 className="white-text">
            Posted by{' '}
            <Link to={`/user/${props.combo.user.displayName}`}>
              {props.combo.user.displayName}
            </Link>{' '}
            {moment(props.combo.datePosted).fromNow()}
          </h5>
        </footer>
      </div>
    </div>
  )
}
