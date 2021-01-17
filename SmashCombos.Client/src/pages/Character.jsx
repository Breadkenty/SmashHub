import React, { useState, useEffect } from 'react'
import { Link } from 'react-router-dom'
import { useParams } from 'react-router'
import { isLoggedIn } from '../auth'

import { allCharacterPortrait } from '../components/allCharacterPortrait'
import { allComboInputs } from '../components/combo-inputs/allComboInputs'
import { returnDifficulty } from '../components/returnDifficulty'

import { SortController } from '../components/SortController'
import { sortingFunctions } from '../components/sortingFunctions'
import { CharacterCombo } from './CharacterCombo'

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
          backgroundImage: `url(${
            allCharacterPortrait[character.variableName]
          })`,
          backgroundPositionY: `${character.yPosition}%`,
        }}
      >
        <h1>{character.name}</h1>
      </header>

      <div className="search-container bg-grey">
        <div className="search-container-items">
          <div className="search-bar">
            <i className="fas fa-search"></i>
            <input
              type="search"
              placeholder="Search"
              onChange={event => setFilterText(event.target.value)}
            />
          </div>
          <div>
            <SortController sortType={sortType} setSortType={setSortType} />
            {isLoggedIn() && (
              <Link to={`/submit/${characterVariableName}`}>
                <button className="button">Submit a combo</button>
              </Link>
            )}
          </div>
        </div>
      </div>
      <section className="combos">
        {sortedCombos
          .filter(combo =>
            combo.title.toLowerCase().includes(filterText.toLowerCase())
          )
          .map(combo => (
            <CharacterCombo
              combo={combo}
              characterVariableName={characterVariableName}
              getCharacters={getCharacters}
            />
          ))}
      </section>
    </div>
  )
}
