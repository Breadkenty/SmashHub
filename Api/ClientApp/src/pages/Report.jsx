import React, { useState, useEffect } from 'react'
import { Link } from 'react-router-dom'
import moment from 'moment'

export function Report(props) {
  const [confirmDismiss, setConfirmDismiss] = useState(false)
  const [report, setReport] = useState({
    body: '',
    combo: {
      id: {},
      character: {
        variableName: 'hi',
      },
      title: '',
    },
    comment: {
      combo: {
        id: 0,
        character: {
          variableName: 'hi',
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

  useEffect(() => {
    setReport(props.report)
  }, [])

  return (
    <div className="reports-row">
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
