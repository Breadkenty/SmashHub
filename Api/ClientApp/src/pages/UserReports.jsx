import React, { useState, useEffect } from 'react'
import { authHeader, isLoggedIn } from '../auth'
import { Report } from './Report'
import { useParams } from 'react-router'

export function UserReports(props) {
  const [reports, setReports] = useState([])
  const [errorMessage, setErrorMessage] = useState()
  const [toggleReportDropDown, setToggleReportDropDown] = useState(false)
  const [infractionType, setInfractionType] = useState('warn')
  const [infraction, setInfraction] = useState({
    banDuration: 0,
    points: 1,
    category: 0,
    body: '',
    userId: 0,
  })

  const params = useParams()
  const displayName = params.displayName

  function handleSubmit() {
    fetch(`/api/Infractions`, {
      method: 'POST',
      headers: { 'content-type': 'application/json', ...authHeader() },
      body: JSON.stringify(infraction),
    }).then(response => {
      if (response.status === 201) {
        return response.json()
      } else {
        setErrorMessage(response.statusText)
      }
    })

    setInfractionType('warn')
    setInfraction({
      ...infraction,
      banDuration: 0,
      points: 0,
      category: 0,
      body: '',
    })
  }

  function getUserReports() {
    fetch(`api/Reports/user/${displayName}`, {
      headers: { 'content-type': 'application/json', ...authHeader() },
    })
      .then(response => {
        return response.json()
      })
      .then(apiData => {
        setReports(apiData)
      })
  }

  useEffect(() => {
    isLoggedIn() && props.loggedInUser.userType > 1 && getUserReports()
  }, [])

  reports.sort((a, b) => new Date(b.dateReported) - new Date(a.dateReported))

  return (
    <section className="user-details">
      <header>
        <div>
          <h3>Reports: </h3>
          <h3 className="points">
            {reports.filter(report => report.dismiss === false).length}
          </h3>
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
                  points: 1,
                  category: 0,
                  banDuration: 0,
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
                  points: 0,
                  category: 0,
                  banDuration: 30,
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
                infraction.category === 0 ? 'active-button' : ''
              }`}
            >
              <button
                className="button bg-yellow"
                onClick={event => {
                  event.preventDefault()
                  setInfraction({
                    ...infraction,
                    category: 0,
                    points: infractionType === 'ban' ? 0 : 1,
                  })
                }}
              >
                Spam/Abuse
              </button>
            </div>

            <div
              className={`button-wrapper ${
                infraction.category === 2 ? 'active-button' : ''
              }`}
            >
              <button
                className="button bg-yellow"
                onClick={event => {
                  event.preventDefault()
                  setInfraction({
                    ...infraction,
                    category: 2,
                    points: infractionType === 'ban' ? 0 : 2,
                  })
                }}
              >
                Harassment
              </button>
            </div>

            <div
              className={`button-wrapper ${
                infraction.category === 1 ? 'active-button' : ''
              }`}
            >
              <button
                className="button bg-yellow"
                onClick={event => {
                  event.preventDefault()
                  setInfraction({
                    ...infraction,
                    category: 1,
                    points: infractionType === 'ban' ? 0 : 1,
                  })
                }}
              >
                Inappropriate
              </button>
            </div>

            <div
              className={`button-wrapper ${
                infraction.category === 3 ? 'active-button' : ''
              }`}
            >
              <button
                className="button bg-yellow"
                onClick={event => {
                  event.preventDefault()
                  setInfraction({
                    ...infraction,
                    category: 3,
                    points: infractionType === 'ban' ? 0 : 4,
                  })
                }}
              >
                Other
              </button>
            </div>
          </div>

          {infractionType === 'ban' && (
            <div className="ban-duration">
              <div
                className={`button-wrapper ${
                  infraction.banDuration === 30 ? 'active-button' : ''
                }`}
              >
                <button
                  className="button bg-yellow"
                  onClick={event => {
                    event.preventDefault()
                    setInfraction({
                      ...infraction,
                      banDuration: 30,
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
          {errorMessage && (
            <div className="error-message">
              <i className="fas fa-exclamation-triangle"></i> {errorMessage}
            </div>
          )}
          <textarea
            placeholder="reason"
            value={infraction.body}
            onChange={event => {
              setInfraction({
                ...infraction,
                body: event.target.value,
                userId: props.user.id,
              })
            }}
            required
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

        {reports.map(
          report =>
            report.dismiss === false && (
              <Report
                key={report.id}
                report={report}
                getUserData={props.getUserData}
                getUserReports={getUserReports}
              />
            )
        )}
      </div>
    </section>
  )
}
