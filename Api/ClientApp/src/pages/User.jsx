import React, { useState, useEffect } from 'react'
import { Link } from 'react-router-dom'
import { useParams } from 'react-router'
import { authHeader } from '../auth'

import { allComboInputs } from '../components/combo-inputs/allComboInputs'
import { allCharacterCloseUp } from '../components/allCharacterCloseUp'
import { returnDifficulty } from '../components/returnDifficulty'

import { sortingFunctions } from '../components/sortingFunctions'
import { Report } from './Report'

import moment from 'moment'

export function User() {
  const params = useParams()
  const displayName = params.displayName

  const [user, setUser] = useState({
    combos: [],
    comments: [],
    displayName: '',
    infractions: [],
    userType: 1,
  })

  const [reports, setReports] = useState([])

  const [toggleReportDropDown, setToggleReportDropDown] = useState(false)
  const [toggleInfractionDropDown, setToggleInfractionDropDown] = useState(
    false
  )
  const [infractionType, setInfractionType] = useState('warn')
  const [infraction, setInfraction] = useState({
    userId: 0,
    moderatorId: 0,
    banDuration: 0,
    points: 0,
    category: '',
    body: '',
  })

  const handleSubmit = event => {
    event.preventDefault()
    console.log('Submit:')
    console.log(infraction)
  }

  function handleVote(event, id, upOrDown) {
    event.preventDefault()

    fetch(`/api/ComboVotes/${id}/${upOrDown}`, {
      method: 'POST',
      headers: { 'content-type': 'application/json', ...authHeader() },
    }).then(() => {
      getUser()
    })
  }

  function getUser() {
    fetch(`/api/Users/${displayName}`)
      .then(response => response.json())
      .then(apiData => {
        setUser(apiData)
      })
  }

  function getUserReports() {
    fetch(`api/Reports/user/${displayName}`)
      .then(response => response.json())
      .then(apiData => {
        setReports(apiData)
      })
  }

  function getCharacter(characterVariableName) {
    fetch(`/api/Characters/${characterVariableName}`)
      .then(response => response.json())
      .then(apiData => {
        console.log(apiData)
      })
  }

  function sumInfraction(user) {
    let totalInfraction = 0
    user.infractions.forEach(
      infraction => (totalInfraction = totalInfraction + infraction.points)
    )
    return totalInfraction
  }

  useEffect(getUser, [])
  useEffect(getUserReports, [])

  reports.sort((a, b) => new Date(b.dateReported) - new Date(a.dateReported))

  console.log(user)

  return (
    <div className="user">
      <header>
        <h1>{displayName}</h1>
      </header>

      <section className="user-details">
        <header>
          <div>
            <h3>Reports: </h3>
            <h3 className="points">5</h3>
          </div>
          <button
            onClick={() => {
              if (!toggleReportDropDown) {
                setToggleReportDropDown(true)
              } else {
                setToggleReportDropDown(false)
              }
            }}
          >
            <svg
              viewBox="0 0 81 45"
              style={
                toggleReportDropDown ? { transform: 'rotate(360deg)' } : null
              }
            >
              <path d="M40.55 3.003L3.015 41.985l19.406.044h.007l18.119-18.818 18.127 18.818h19.357L40.55 3.003z"></path>
            </svg>
          </button>
        </header>

        <div
          className="drop-down"
          style={
            toggleReportDropDown ? { display: 'block' } : { display: 'none' }
          }
        >
          <div className="infraction-actions">
            <div
              className={`button-wrapper ${
                infractionType === 'warn' ? 'active-button' : ''
              }`}
            >
              <button
                className="button bg-yellow"
                onClick={() => {
                  setInfractionType('warn')
                  setInfraction({
                    ...infraction,
                    category: '',
                    banDuration: 0,
                    body: '',
                    points: 0,
                  })
                }}
              >
                Warn
              </button>
            </div>
            <div
              className={`button-wrapper ${
                infractionType === 'ban' ? 'active-button' : ''
              }`}
            >
              <button
                className="button bg-red white-text"
                onClick={() => {
                  setInfractionType('ban')
                  setInfraction({
                    ...infraction,
                    category: '',
                    banDuration: 0,
                    body: '',
                    points: 0,
                  })
                }}
              >
                Ban
              </button>
            </div>
          </div>
          <form className="infraction-form" onSubmit={handleSubmit}>
            <div className="types">
              <div
                className={`button-wrapper ${
                  infraction.category === 'Spam/Abuse' ? 'active-button' : ''
                }`}
              >
                <button
                  className="button bg-yellow"
                  onClick={event => {
                    event.preventDefault()
                    setInfraction({
                      ...infraction,
                      category: 'Spam/Abuse',
                      points: 1,
                    })
                  }}
                >
                  Spam/Abuse
                </button>
              </div>

              <div
                className={`button-wrapper ${
                  infraction.category === 'Harassment' ? 'active-button' : ''
                }`}
              >
                <button
                  className="button bg-yellow"
                  onClick={event => {
                    event.preventDefault()
                    setInfraction({
                      ...infraction,
                      category: 'Harassment',
                      points: 2,
                    })
                  }}
                >
                  Harassment
                </button>
              </div>

              <div
                className={`button-wrapper ${
                  infraction.category === 'Inappropriate' ? 'active-button' : ''
                }`}
              >
                <button
                  className="button bg-yellow"
                  onClick={event => {
                    event.preventDefault()
                    setInfraction({
                      ...infraction,
                      category: 'Inappropriate',
                      points: 1,
                    })
                  }}
                >
                  Inappropriate
                </button>
              </div>

              <div
                className={`button-wrapper ${
                  infraction.category === 'Off-topic' ? 'active-button' : ''
                }`}
              >
                <button
                  className="button bg-yellow"
                  onClick={event => {
                    event.preventDefault()
                    setInfraction({
                      ...infraction,
                      category: 'Off-topic',
                      points: 1,
                    })
                  }}
                >
                  Off-topic
                </button>
              </div>
            </div>

            {infractionType === 'ban' && (
              <div className="ban-duration">
                <div
                  className={`button-wrapper ${
                    infraction.banDuration === 172800 ? 'active-button' : ''
                  }`}
                >
                  <button
                    className="button bg-yellow"
                    onClick={event => {
                      event.preventDefault()
                      setInfraction({
                        ...infraction,
                        banDuration: 172800,
                      })
                    }}
                  >
                    2 Days
                  </button>
                </div>

                <div
                  className={`button-wrapper ${
                    infraction.banDuration === 604800 ? 'active-button' : ''
                  }`}
                >
                  <button
                    className="button bg-yellow"
                    onClick={event => {
                      event.preventDefault()
                      setInfraction({
                        ...infraction,
                        banDuration: 604800,
                      })
                    }}
                  >
                    1 Week
                  </button>
                </div>

                <div
                  className={`button-wrapper ${
                    infraction.banDuration === 1209600 ? 'active-button' : ''
                  }`}
                >
                  <button
                    className="button bg-yellow"
                    onClick={event => {
                      event.preventDefault()
                      setInfraction({
                        ...infraction,
                        banDuration: 1209600,
                      })
                    }}
                  >
                    2 Weeks
                  </button>
                </div>

                <div
                  className={`button-wrapper ${
                    infraction.banDuration === 2419200 ? 'active-button' : ''
                  }`}
                >
                  <button
                    className="button bg-yellow"
                    onClick={event => {
                      event.preventDefault()
                      setInfraction({
                        ...infraction,
                        banDuration: 2419200,
                      })
                    }}
                  >
                    1 Month
                  </button>
                </div>
              </div>
            )}
            <textarea
              placeholder="reason"
              value={infraction.body}
              onChange={event => {
                setInfraction({ ...infraction, body: event.target.value })
              }}
            />
            <button className="button" type="submit">
              Submit
            </button>
          </form>

          <div className="reports-header">
            <h5>Date</h5>
            <h5>Reported Content</h5>
            <h5>Comments</h5>
            <h5>Reported By</h5>
          </div>

          {reports.map(report => (
            <Report report={report} />
          ))}
        </div>
      </section>

      <section className="user-details">
        <header>
          <div>
            <h3>Infractions:</h3>
            <h3 className="points">{sumInfraction(user)}</h3>
          </div>
          <button
            onClick={() => {
              if (!toggleInfractionDropDown) {
                setToggleInfractionDropDown(true)
              } else {
                setToggleInfractionDropDown(false)
              }
            }}
          >
            <svg
              viewBox="0 0 81 45"
              style={
                toggleInfractionDropDown
                  ? { transform: 'rotate(360deg)' }
                  : null
              }
            >
              <path d="M40.55 3.003L3.015 41.985l19.406.044h.007l18.119-18.818 18.127 18.818h19.357L40.55 3.003z"></path>
            </svg>
          </button>
        </header>

        <div
          className="drop-down"
          style={
            toggleInfractionDropDown
              ? { display: 'block' }
              : { display: 'none' }
          }
        >
          <div className="reports-header">
            <h5>Points</h5>
            <h5>Comment</h5>
            <h5>Moderator</h5>
            <h5>Date</h5>
          </div>
          {user.infractions.map(infraction => (
            <div className="reports-row">
              <p className="points">{infraction.points}</p>
              <p>{infraction.body}</p>
              <Link to="#">{infraction.moderator.displayName}</Link>
              <p>{moment(infraction.dateInfracted).format('L')}</p>
            </div>
          ))}
        </div>
      </section>

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
                  <Link to={`/character/Peach`}>
                    <img
                      src={allCharacterCloseUp['Peach']}
                      alt={`Peach's portrait`}
                    />
                  </Link>
                  <Link to={`/character/Mario/1`}>
                    <h3>{combo.title}</h3>
                  </Link>
                </div>
                {returnDifficulty('hard ')}
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
