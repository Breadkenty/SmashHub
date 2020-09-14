import React, { useState, useEffect } from 'react'
import { useParams } from 'react-router'
import { authHeader, isLoggedIn, getUser } from '../auth'

import { UserReports } from './UserReports'

import { Infractions } from './Infractions'
import { UserCombo } from './UserCombo'

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

  function getUserData() {
    fetch(`/api/Users/${isLoggedIn() ? '' : 'unauth/'}${displayName}`, {
      method: 'GET',
      headers: { 'content-type': 'application/json', ...authHeader() },
    })
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
        userId: user.id,
      }),
    })
      .then(response => {
        console.log(response)
        if (response.status === 200) {
          window.location.reload(false)
        } else {
          setErrorMessage(response.statusText)
          return response.json()
        }
      })
      .then(apiData => {
        console.log(apiData)
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

  useEffect(() => {
    getUserData()
  }, [])

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
          <UserCombo combo={combo} getUserData={getUserData} />
        ))}
      </section>
    </div>
  )
}
