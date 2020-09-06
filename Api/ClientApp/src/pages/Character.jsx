import React, { useState, useEffect } from 'react'
import { Link } from 'react-router-dom'
import { useParams } from 'react-router'
import { authHeader, isLoggedIn } from '../auth'

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
            <div key={combo.id} className="combo">
              <div className="vote">
                <button
                  className="button-blank"
                  onClick={event => {
                    handleVote(event, combo.id, 'upvote')
                  }}
                >
                  <svg viewBox="0 0 81 45">
                    <path d="M40.55 3.003L3.015 41.985l19.406.044h.007l18.119-18.818 18.127 18.818h19.357L40.55 3.003z"></path>
                  </svg>
                </button>
                <h3 className="black-text">{combo.netVote}</h3>
                <button
                  className="button-blank"
                  onClick={event => {
                    handleVote(event, combo.id, 'downvote')
                  }}
                >
                  <svg className="down-vote" viewBox="0 0 81 45">
                    <path d="M40.55 3.003L3.015 41.985l19.406.044h.007l18.119-18.818 18.127 18.818h19.357L40.55 3.003z"></path>
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
                  <h5 className="white-text">
                    Posted by {combo.user.displayName}{' '}
                    {moment(combo.datePosted).fromNow()}
                  </h5>
                </footer>
              </div>
            </div>
          ))}
      </section>
    </div>
  )
}
