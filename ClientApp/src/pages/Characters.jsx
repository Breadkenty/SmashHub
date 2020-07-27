import React, { useState, useEffect } from 'react'
import { Link } from 'react-router-dom'
import { getUser, isLoggedIn } from '../auth'

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

  const user = getUser()

  useEffect(getCharacters, [filterText])

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

      {isLoggedIn() && <h4>Welcome {user.displayName}</h4>}
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
