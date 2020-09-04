import React, { useState } from 'react'
import { Link } from 'react-router-dom'
import moment from 'moment'

export function Infraction(props) {
  const [confirmDismiss, setConfirmDismiss] = useState(false)

  return (
    <div className="reports-row">
      <p className="points">{props.infraction.points}</p>
      <p>{props.infraction.body}</p>
      <Link to={`/user/${props.infraction.moderator.displayName}`}>
        {props.infraction.moderator.displayName}
      </Link>
      <p>{moment(props.infraction.dateInfracted).format('L')}</p>
      {confirmDismiss ? (
        <div className="report-dismiss">
          <p>Are you sure you want to dismiss this infraction?: </p>
          <button onClick={props.handleDismiss}>yes</button>
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
      )}
    </div>
  )
}
