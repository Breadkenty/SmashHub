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
      <section className="announcements">
        <h4>Announcements</h4>
        <ul>
          <li className="announcement">
            <h5>
              To view the demo of how this app works, feel free to watch my
              presentation!
            </h5>
            <a href="https://youtu.be/7lSaNBIl1Y8?t=3516">
              The Demo (skip to 1:02:05 to skip the introduction)
            </a>
          </li>
          <li>
            <h5>
              This project is a work in progress, please submit feature requests
              by tweeting to
            </h5>
            <a href="https://twitter.com/KentoKawakami/">@KentoKawakami</a>
          </li>
          <li>
            <h5>Or join our official discord server</h5>
            <a href="https://discord.gg/VbnAwUg">
              Official Smash Combos Discord
            </a>
          </li>
        </ul>
      </section>

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
