import React, { useState, useEffect } from 'react'
import { Link } from 'react-router-dom'
import { useParams } from 'react-router'

import { allCharacterPortrait } from '../components/allCharacterPortrait'
import { allComboInputs } from '../components/combo-inputs/allComboInputs'
import { returnDifficulty } from '../components/returnDifficulty'

import { SortController } from '../components/SortController'
import { sortingFunctions } from '../components/sortingFunctions'

import moment from 'moment'

export function Character() {
  const params = useParams()
  const characterVariableName = params.characterVariableName

  const [character, setCharacter] = useState({})
  const [combos, setCombos] = useState([])
  let [filterText, setFilterText] = useState('')
  let [sortType, setSortType] = useState('best')

  function getCharacters() {
    fetch(`/api/Characters/${characterVariableName}`)
      .then(response => response.json())
      .then(apiData => {
        setCharacter(apiData)
        setCombos(apiData.combos)
      })
  }

  useEffect(getCharacters, [])

  const sortedCombos = combos.sort(sortingFunctions[sortType])

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
        <input
          className="bg-yellow"
          type="search"
          placeholder="Search"
          onChange={event => setFilterText(event.target.value)}
        />

        <SortController sortType={sortType} setSortType={setSortType} />
      </div>
      <section className="combos">
        {sortedCombos
          .filter(combo =>
            combo.title.toLowerCase().includes(filterText.toLowerCase())
          )
          .map(combo => (
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
                  <Link to={`/character/${characterVariableName}/${combo.id}`}>
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
