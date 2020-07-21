import React, { useState, useEffect } from 'react'

import peach from '../graphics/characters/PacMan/PacMan-5.png'
import input from '../graphics/inputs/png/aerial/back-aerial.png'
import { useParams } from 'react-router'

import { allCharacterPortrait } from '../components/allCharacterPortrait'
import { allComboInputs } from '../components/combo-inputs/allComboInputs'

export function CharacterCombo() {
  const params = useParams()

  const characterId = params.characterId
  const comboId = params.comboId

  const [character, setCharacter] = useState({})

  // Set with example inputs
  const [inputs, setInputs] = useState(
    'downTilt thenConditional forwardFlick thenConditional downMove andConditional holdConditional fullHop thenConditional jabBasic thenConditional releaseConditional thenConditional upTilt andConditional jabBasic'
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

  useEffect(getCharacter, [])

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
          title="down tilt ground float nair"
          width="560"
          height="315"
          src="https://www.youtube.com/embed/01nFQmMcVlc?autoplay=1&start=438&mute=1&playsinline=1"
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

          {/* Combo detail */}
          <div className="detail">
            <h5>Posted by Breadkenty 2 hours ago</h5>
            <h2>Down-Tilt Ground Float Nair</h2>

            <div>
              <div className="tag bg-pink white-text">Hard</div>
              <div className="tag bg-green white-text">True</div>
              <h3>~56%</h3>
            </div>
          </div>
        </header>

        {/* Combo inputs */}
        <section className="bg-grey combo-inputs">
          {inputsAsArray.map(input => (
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
          <p>
            This combo is best used against fast falling characters. Keep in
            mind, when doing the nair, you have to release the direction as soon
            as you get the momentum of going forward.
          </p>
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
