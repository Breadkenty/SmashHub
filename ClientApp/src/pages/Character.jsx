import React, { useState, useEffect } from 'react'
import { Link } from 'react-router-dom'
import { useParams } from 'react-router'

import { allCharacterPortrait } from '../components/allCharacterPortrait'
import { allComboInputs } from '../components/combo-inputs/allComboInputs'
import { returnDifficulty } from '../components/returnDifficulty'

import moment from 'moment'

export function Character() {
  const params = useParams()
  const id = params.characterId

  const [character, setCharacter] = useState({})
  const [combos, setCombos] = useState([])

  console.log(combos)
  // Set with example inputs
  const [inputs, setInputs] = useState(
    'downTilt thenConditional forwardFlick thenConditional downMove andConditional holdConditional fullHop thenConditional jabBasic thenConditional releaseConditional'
  )
  // Converts string of inputs into an array used to map
  const inputsAsArray = inputs.split(' ')

  function getCharacters() {
    fetch(`/api/Characters/${id}`)
      .then(response => response.json())
      .then(apiData => {
        setCharacter(apiData)
        setCombos(apiData.combos)
      })
  }

  useEffect(getCharacters, [])

  return (
    <div className="character-combos">
      <header
        className="character-header"
        style={{
          backgroundImage: `url(${allCharacterPortrait[character.name]})`,
          // Change position Y to match the character portrait
          backgroundPositionY: `${character.yPosition}%`,
        }}
      >
        <h1>{character.name}</h1>
      </header>

      <div className="search-container bg-grey">
        <input className="bg-yellow" type="text" placeholder="Search" />
        <div>
          <button className="bg-red button white-text">Popular</button>
          <button className="bg-red button white-text">Newest</button>
        </div>
      </div>

      <section className="combos">
        {combos.map(combo => (
          <div className="combo">
            <div className="vote bg-yellow">
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

            <div className="information">
              <header>
                <Link to={`/character/${id}/1`}>
                  <h3>{combo.title}</h3>
                </Link>
                {returnDifficulty(combo.difficulty)}
              </header>

              <div className="combo-inputs">
                {combo.comboInput.split(' ').map(input => (
                  <div
                    className="combo-input"
                    style={{
                      backgroundImage: `url(${allComboInputs[input]})`,
                    }}
                  ></div>
                ))}
              </div>

              <footer>
                <p className="white-text">
                  Posted by Breadkenty{' '}
                  {moment(combo.datePosted)
                    .startOf('hour')
                    .fromNow()}
                </p>
              </footer>
            </div>
          </div>
        ))}
      </section>
    </div>
  )
}
