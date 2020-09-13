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
          <i className="fas fa-search"></i>
          <input
            className="bg-yellow"
            type="search"
            placeholder="Search"
            value={filterText}
            onChange={event => setFilterText(event.target.value)}
          />
        </div>
      </header>
      <section className="announcements">
        <h3>Announcements</h3>
        <ul>
          <li>
            <h4>We're back!</h4>
            <p>
              We're happy to announce we've implemented a moderator feature to
              keep the contents of Smash Combos appropriate. Please check the{' '}
              <Link to="/rules">rules</Link> before posting!
            </p>
          </li>
          <li>
            <Link className="header-link" to="https://discord.gg/VbnAwUg">
              Official Smash Combos Discord
            </Link>
          </li>
        </ul>
      </section>

      <h3>Choose your character</h3>
      <div className="characters">
        {characters
          .sort((a, b) => a.releaseOrder - b.releaseOrder)
          .map(character => (
            <Link
              key={character.id}
              to={`/character/${character.variableName}`}
            >
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
