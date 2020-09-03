import React, { useState } from 'react'
import { Link } from 'react-router-dom'
import moment from 'moment'

export function Report(props) {
  const [confirmDismiss, setConfirmDismiss] = useState(false)

  const handleDismiss = event => {
    event.preventDefault()
    console.log('Dismiss:')
  }

  return (
    <div className="reports-row">
      <p>{moment(props.report.dateReported).format('L')}</p>
      <Link to="#">Down tilt ground float nair</Link>
      <p>{props.report.body}</p>
      <Link to={`/user/${props.report.reporter.displayName}`}>
        {props.report.reporter.displayName}
      </Link>
      {confirmDismiss ? (
        <div className="report-dismiss">
          <p>Are you sure you want to dismiss this report?: </p>
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
      )}
    </div>
  )
}
