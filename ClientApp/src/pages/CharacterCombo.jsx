import React, { useState, useEffect } from 'react'
import moment from 'moment'
import YouTube from 'react-youtube'

import { useParams } from 'react-router'

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
  const [comments, setComments] = useState([])
  let [sortType, setSortType] = useState('best')

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
      })
  }

  useEffect(getCharacter, [])
  useEffect(getCombo, [])

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

  const sortedComments = comments.sort(sortingFunctions[sortType])

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
            <svg
              aria-hidden="true"
              className="m0 svg-icon iconArrowUpLg"
              width="36"
              height="36"
              viewBox="0 0 36 36"
            >
              <path d="M2 26h32L18 10 2 26z"></path>
            </svg>
            <h3 className="black-text">{combo.netVote}</h3>
            <svg
              aria-hidden="true"
              className="m0 svg-icon iconArrowDownLg"
              width="36"
              height="36"
              viewBox="0 0 36 36"
            >
              <path d="M2 10h32L18 26 2 10z"></path>
            </svg>
          </div>

          {/* Combo detail */}
          <div className="detail">
            <h5>
              Posted by Breadkenty{' '}
              {moment(combo.datePosted)
                .startOf('hour')
                .fromNow()}
            </h5>
            <h2>{combo.title}</h2>

            <div>
              {returnDifficulty(combo.difficulty)}
              {returnTrueCombo(combo.trueCombo)}
              <h3>{combo.damage}%</h3>
            </div>
          </div>
        </header>

        {/* Combo inputs */}
        <section className="bg-grey combo-inputs">
          {`${combo.comboInput}`.split(' ').map(input => (
            <div
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

        <section className="add-comment bg-grey">
          <textarea placeholder="Add a comment" />
          <button className="bg-yellow button black-text" type="submit">
            Submit
          </button>
        </section>

        <section className="sort">
          <SortController sortType={sortType} setSortType={setSortType} />
        </section>

        <section className="comments">
          {comments.map(comment => (
            <Comment comment={comment} />
          ))}
        </section>
      </article>
    </div>
  )
}
