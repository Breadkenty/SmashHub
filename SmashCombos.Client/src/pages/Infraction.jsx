import React, { useState } from 'react'
import { authHeader, getUser } from '../auth'
import { Link } from 'react-router-dom'
import moment from 'moment'

export function Infraction(props) {
  const loggedInUser = getUser()

  const [confirmDismiss, setConfirmDismiss] = useState(false)

  const handleDismiss = event => {
    event.preventDefault()

    fetch(`/api/Infractions/dismiss/${props.infraction.id}`, {
      method: 'PUT',
      headers: { 'content-type': 'application/json', ...authHeader() },
      body: JSON.stringify({
        infractionId: props.infraction.id,
        dismiss: true,
      }),
    })
    window.location.reload(false)
  }

  return (
    <div className="reports-row">
      <p className="points">{props.infraction.points}</p>
      <p>{props.infraction.body}</p>
      <Link to={`/user/${props.infraction.moderator.displayName}`}>
        {props.infraction.moderator.displayName}
      </Link>
      <p>{moment(props.infraction.dateInfracted).format('L')}</p>
      {loggedInUser.userType > 1 ? (
        confirmDismiss ? (
          <div className="report-dismiss">
            <p>Are you sure you want to dismiss this infraction?: </p>
            <button onClick={handleDismiss}>yes</button>
            <button
              onClick={() => {
                setConfirmDismiss(false)
              }}
            >
              no
            </button>
          </div>
        ) : (
          <div className="report-dismiss">
            <button
              onClick={() => {
                setConfirmDismiss(true)
              }}
            >
              dismiss
            </button>
          </div>
        )
      ) : null}
    </div>
  )
}
