import React, { useState, useEffect } from 'react'
import { Link } from 'react-router-dom'
import { authHeader } from '../auth'
import moment from 'moment'

export function Report(props) {
  const [errorMessage, setErrorMessage] = useState()
  const [confirmDismiss, setConfirmDismiss] = useState(false)
  const [report, setReport] = useState({
    body: '',
    combo: {
      id: {},
      character: {
        variableName: '',
      },
      title: '',
    },
    comment: {
      combo: {
        id: 0,
        character: {
          variableName: '',
        },
      },
      body: '',
    },
    dateReported: '',
    dismiss: false,
    id: 0,
    reporter: {},
    user: {},
  })

  const handleDismiss = event => {
    event.preventDefault()

    fetch(`/api/Reports/${report.id}`, {
      method: 'PUT',
      headers: { 'content-type': 'application/json', ...authHeader() },
      body: JSON.stringify({
        id: report.id,
        dismiss: true,
      }),
    })
    window.location.reload(false)
  }

  useEffect(() => {
    setReport(props.report)
  }, [])
  useEffect(() => {
    props.getUserData()
    props.getUserReports()
  }, [confirmDismiss])

  return (
    <div className="reports-row">
      {errorMessage && (
        <div className="error-message">
          <i className="fas fa-exclamation-triangle"></i> {errorMessage}
        </div>
      )}
      <p>{moment(props.report.dateReported).format('L')}</p>
      <Link
        to={
          report.combo
            ? `/character/${report.combo.character.variableName}/${report.combo.id}`
            : `/character/${report.comment.combo.character.variableName}/${report.comment.combo.id}#${report.comment.id}`
        }
      >
        {report.combo
          ? `Combo: ${report.combo.title}`
          : `Comment: ${report.comment.body}`}
      </Link>
      <p>{report.body}</p>
      <Link to={`/user/${report.reporter.displayName}`}>
        {report.reporter.displayName}
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
