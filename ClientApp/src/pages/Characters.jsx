import React, { useState, useEffect } from 'react'
import { Link } from 'react-router-dom'

import { allCharacterCloseUp } from '../components/allCharacterCloseUp'

export function Characters() {
  let [characters, setCharacters] = useState([])
  const [filterText, setFilterText] = useState('')

  // function getCharacters() {
  //   fetch('/api/Characters')
  //     .then(response => response.json())
  //     .then(apiData => {
  //       setCharacters(apiData)
  //     })
  // }

  function getCharacters() {
    const url =
      filterText.length === 0
        ? `/api/Characters`
        : `/api/Characters?filter=${filterText.toLowerCase()}`
    fetch(url)
      .then(response => response.json())
      .then(apiData => {
        setCharacters(apiData)
      })
  }

  useEffect(getCharacters, [filterText])
  // characters.map(character => {
  //   console.log(character.name)
  // })

  return (
    <div className="character-select">
      <header>
        <input
          className="bg-yellow"
          type="search"
          placeholder="Search"
          value={filterText}
          onChange={event => setFilterText(event.target.value)}
        />
      </header>
      <h3>Choose your character</h3>
      <div className="characters">
        {characters.map(character => (
          <Link to={`/character/${character.id}`}>
            <img
              src={allCharacterCloseUp[character.variableName]}
              alt={`${character.name}'s portrait`}
            />
          </Link>
        ))}
      </div>
    </div>
  )
}
