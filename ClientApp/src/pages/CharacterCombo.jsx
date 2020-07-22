import React, { useState, useEffect } from 'react'
import moment from 'moment'

import peach from '../graphics/characters/PacMan/PacMan-5.png'
import input from '../graphics/inputs/png/aerial/back-aerial.png'
import { useParams } from 'react-router'

import { allCharacterPortrait } from '../components/allCharacterPortrait'
import { allComboInputs } from '../components/combo-inputs/allComboInputs'
import { returnDifficulty } from '../components/returnDifficulty'
import { returnTrueCombo } from '../components/returnTrueCombo'

export function CharacterCombo() {
  const params = useParams()

  const characterId = params.characterId
  const comboId = params.comboId

  const [character, setCharacter] = useState({})
  const [combo, setCombo] = useState({})

  // Set with example inputs
  const [inputs, setInputs] = useState(
    'downTilt thenConditional forwardFlick thenConditional downMove andConditional holdConditional fullHop thenConditional neutralAerial'
  )
  // Converts string of inputs into an array used to map
  const inputsAsArray = inputs.split(' ')

  function getCharacter() {
    fetch(`/api/Characters/${characterId}`)
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
        console.log(apiData)
      })
  }

  console.log(`${combo.comboInput}`.split(' '))

  useEffect(getCharacter, [])
  useEffect(getCombo, [])

  return (
    <div className="character-combo">
      {/* Character image header */}
      <header
        className="character-header"
        style={{
          backgroundImage: `url(${allCharacterPortrait[character.name]})`,
          backgroundPositionY: `${character.yPosition}%`,
        }}
      >
        <h1>{character.name}</h1>
      </header>

      {/* Video */}
      <div className="video-container">
        <iframe
          title={combo.title}
          width="560"
          height="315"
          src={`https://www.youtube.com/embed/${combo.videoId}?autoplay=1&start=${combo.videoStartTime}&mute=1&playsinline=1`}
          frameborder="0"
          allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture"
          donotallowfullscreen
        />
      </div>
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

        {/* Comment section */}
        <section className="comments">
          <div className="comment">
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
              <h3 className="black-text">42</h3>
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

            <div className="body">
              <h5>Posted by Tacotastic 1 hour ago</h5>
              <p>
                This is a really good find, ground float to nair is too strong!
                I'm gonna try to practice this when I get home. Thanks for
                sharing, this is extremely helpful in learning peach!
              </p>
            </div>
          </div>
          <div className="comment">
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
              <h3 className="black-text">42</h3>
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

            <div className="body">
              <h5>Posted by Tacotastic 1 hour ago</h5>
              <p>
                This is a really good find, ground float to nair is too strong!
                I'm gonna try to practice this when I get home. Thanks for
                sharing, this is extremely helpful in learning peach!
              </p>
            </div>
          </div>
          <div className="comment">
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
              <h3 className="black-text">42</h3>
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

            <div className="body">
              <h5>Posted by Tacotastic 1 hour ago</h5>
              <p>
                This is a really good find, ground float to nair is too strong!
                I'm gonna try to practice this when I get home. Thanks for
                sharing, this is extremely helpful in learning peach!
              </p>
            </div>
          </div>
          <div className="comment">
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
              <h3 className="black-text">42</h3>
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

            <div className="body">
              <h5>Posted by Tacotastic 1 hour ago</h5>
              <p>
                This is a really good find, ground float to nair is too strong!
                I'm gonna try to practice this when I get home. Thanks for
                sharing, this is extremely helpful in learning peach!
              </p>
            </div>
          </div>
          <div className="comment">
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
              <h3 className="black-text">42</h3>
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

            <div className="body">
              <h5>Posted by Tacotastic 1 hour ago</h5>
              <p>
                This is a really good find, ground float to nair is too strong!
                I'm gonna try to practice this when I get home. Thanks for
                sharing, this is extremely helpful in learning peach!
              </p>
            </div>
          </div>
          <div className="comment">
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
              <h3 className="black-text">42</h3>
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

            <div className="body">
              <h5>Posted by Tacotastic 1 hour ago</h5>
              <p>
                This is a really good find, ground float to nair is too strong!
                I'm gonna try to practice this when I get home. Thanks for
                sharing, this is extremely helpful in learning peach!
              </p>
            </div>
          </div>
          <div className="comment">
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
              <h3 className="black-text">42</h3>
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

            <div className="body">
              <h5>Posted by Tacotastic 1 hour ago</h5>
              <p>
                This is a really good find, ground float to nair is too strong!
                I'm gonna try to practice this when I get home. Thanks for
                sharing, this is extremely helpful in learning peach!
              </p>
            </div>
          </div>
        </section>
      </article>
    </div>
  )
}
