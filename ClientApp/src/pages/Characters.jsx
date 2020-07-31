import React, { useState, useEffect } from 'react'
import { Link } from 'react-router-dom'
import { allCharacterCloseUp } from '../components/allCharacterCloseUp'

export function Characters() {
  let [characters, setCharacters] = useState([])
  const [filterText, setFilterText] = useState('')

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

  return (
    <div className="character-select">
      <header>
        <div className="search-bar">
          <i class="fas fa-search"></i>
          <input
            className="bg-yellow"
            type="search"
            placeholder="Search"
            value={filterText}
            onChange={event => setFilterText(event.target.value)}
          />
        </div>
      </header>
      <h5>
        Tune in for my presentation of the live demo and cool code stuff
        Saturday, August 1, 2020 @ 11:00 AM
      </h5>
      <a href="https://suncoast.io/conference">Register for the free event</a>

      <h3>Choose your character</h3>
      <div className="characters">
        {characters.map(character => (
          <Link key={character.id} to={`/character/${character.variableName}`}>
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
