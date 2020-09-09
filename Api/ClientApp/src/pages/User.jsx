import React, { useState, useEffect } from 'react'
import { Link } from 'react-router-dom'
import { useParams, useHistory } from 'react-router'
import { authHeader, isLoggedIn, getUser } from '../auth'

import { allComboInputs } from '../components/combo-inputs/allComboInputs'
import { allCharacterCloseUp } from '../components/allCharacterCloseUp'
import { returnDifficulty } from '../components/returnDifficulty'

import { UserReports } from './UserReports'

import moment from 'moment'
import { Infractions } from './Infractions'

export function User() {
  const params = useParams()
  const loggedInUser = getUser()

  const displayName = params.displayName

  const [errorMessage, setErrorMessage] = useState()

  const [user, setUser] = useState({
    combos: [],
    comments: [],
    displayName: '',
    infractions: [],
    userType: 1,
    id: 0,
  })

  const [toggleInfractionDropDown, setToggleInfractionDropDown] = useState(
    false
  )

  function handleVote(event, id, upOrDown) {
    event.preventDefault()

    fetch(`/api/ComboVotes/${id}/${upOrDown}`, {
      method: 'POST',
      headers: { 'content-type': 'application/json', ...authHeader() },
    }).then(response => {
      if (response.status === 204) {
        getUserData()
      } else {
        setErrorMessage('login to vote')
      }
    })
  }

  function getUserData() {
    fetch(`/api/Users/${displayName}`)
      .then(response => {
        return response.json()
      })
      .then(apiData => {
        setUser(apiData)
      })
  }

  function unbanUser() {
    fetch(`/api/Users/unban/${user.id}`, {
      method: 'PUT',
      headers: { 'content-type': 'application/json', ...authHeader() },
      body: JSON.stringify({
        userDisplayName: user.id,
      }),
    }).then(response => {
      if (response.status === 200) {
        window.location.reload(false)
      } else {
        setErrorMessage(response.statusText)
      }
    })
  }

  function sumInfraction(user) {
    let totalInfraction = 0
    user.infractions
      .filter(infraction => infraction.dismissDate == null)
      .forEach(
        infraction => (totalInfraction = totalInfraction + infraction.points)
      )
    return totalInfraction
  }

  useEffect(getUserData, [])

  const isBanned = user.infractions
    .filter(infraction => infraction.dismissDate === null)
    .some(infraction => {
      const dateInfracted = new Date(infraction.dateInfracted)
      const now = new Date()
      const banDuration = dateInfracted.setSeconds(
        dateInfracted.getSeconds() + infraction.banDuration
      )

      return banDuration > now
    })

  return (
    <div className="user">
      <header>
        {isLoggedIn() && isBanned && loggedInUser.userType > 1 && (
          <button className="unban button bg-red" onClick={unbanUser}>
            Unban
          </button>
        )}
        <h1>
          {displayName}
          {isBanned && '[Banned]'}
        </h1>
        {errorMessage && (
          <div className="error-message">
            <i className="fas fa-exclamation-triangle"></i> {errorMessage}
          </div>
        )}
      </header>

      {isLoggedIn() && loggedInUser.userType > 1 && (
        <UserReports loggedInUser={loggedInUser} user={user} />
      )}
      {(isLoggedIn() && loggedInUser.userType > 1 && (
        <Infractions
          sumInfraction={sumInfraction}
          setToggleInfractionDropDown={setToggleInfractionDropDown}
          toggleInfractionDropDown={toggleInfractionDropDown}
          user={user}
        />
      )) ||
        (isLoggedIn() && loggedInUser.displayName === displayName && (
          <Infractions
            sumInfraction={sumInfraction}
            setToggleInfractionDropDown={setToggleInfractionDropDown}
            toggleInfractionDropDown={toggleInfractionDropDown}
            user={user}
          />
        ))}

      <section className="combos">
        {user.combos.map(combo => (
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
            <div className="detail">
              <header>
                <div>
                  <Link to={`/character/${combo.character.variableName}`}>
                    <img
                      src={
                        allCharacterCloseUp[`${combo.character.variableName}`]
                      }
                      alt={`${combo.character.name}'s portrait`}
                    />
                  </Link>
                  <Link
                    to={`/character/${combo.character.variableName}/${combo.id}`}
                  >
                    <h3>{combo.title}</h3>
                  </Link>
                </div>
                {returnDifficulty(`${combo.difficulty}`)}
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
                )) || <></>}
              </div>

              <footer>
                <h5 className="white-text">
                  Posted {moment(combo.datePosted).fromNow()}
                </h5>
              </footer>
            </div>
          </div>
        ))}
      </section>
    </div>
  )
}
