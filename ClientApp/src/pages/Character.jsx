import React, { useState, useEffect } from 'react'
import { Link } from 'react-router-dom'
import { useParams } from 'react-router'
import { authHeader } from '../auth'

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

  function handleVote(event, id, upOrDown) {
    event.preventDefault()

    fetch(`/api/ComboVotes/${id}/${upOrDown}`, {
      method: 'POST',
      headers: { 'content-type': 'application/json', ...authHeader() },
    }).then(() => {
      getCharacters()
    })
  }

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
          // Change position Y to match the character portrait
          backgroundPositionY: `${character.yPosition}%`,
        }}
      >
        <h1>{character.name}</h1>
      </header>

      <div className="search-container bg-grey">
        <div className="search-container-items">
          <input
            className="bg-yellow"
            type="search"
            placeholder="Search"
            onChange={event => setFilterText(event.target.value)}
          />
          <div>
            <SortController sortType={sortType} setSortType={setSortType} />
            <Link to={`/submit/${characterVariableName}`}>
              <button className="button bg-yellow black-text">
                Submit a combo
              </button>
            </Link>
          </div>
        </div>
      </div>
      <section className="combos">
        {sortedCombos
          .filter(combo =>
            combo.title.toLowerCase().includes(filterText.toLowerCase())
          )
          .map(combo => (
            <div key={combo.id} className="combo">
              <div className="vote bg-yellow">
                <button
                  className="button-blank"
                  onClick={event => {
                    handleVote(event, combo.id, 'upvote')
                  }}
                >
                  <svg
                    aria-hidden="true"
                    className="m0 svg-icon iconArrowUpLg"
                    width="36"
                    height="36"
                    viewBox="0 0 36 36"
                  >
                    <path d="M2 26h32L18 10 2 26z"></path>
                  </svg>
                </button>
                <h3 className="black-text">{combo.netVote}</h3>
                <button
                  className="button-blank"
                  onClick={event => {
                    handleVote(event, combo.id, 'downvote')
                  }}
                >
                  <svg
                    aria-hidden="true"
                    className="m0 svg-icon iconArrowDownLg"
                    width="36"
                    height="36"
                    viewBox="0 0 36 36"
                  >
                    <path d="M2 10h32L18 26 2 10z"></path>
                  </svg>
                </button>
              </div>

              <div className="information">
                <header>
                  <Link to={`/character/${characterVariableName}/${combo.id}`}>
                    <h3>{combo.title}</h3>
                  </Link>
                  {returnDifficulty(combo.difficulty)}
                </header>

                <div className="combo-inputs">
                  {combo.comboInput.split(' ').map((input, index) => (
                    <div
                      key={index}
                      className="combo-input"
                      style={{
                        backgroundImage: `url(${allComboInputs[input]})`,
                      }}
                    ></div>
                  ))}
                </div>

                <footer>
                  <p className="white-text">
                    Posted by {combo.user.displayName}{' '}
                    {moment(combo.datePosted).fromNow()}
                  </p>
                </footer>
              </div>
            </div>
          ))}
      </section>
    </div>
  )
}
