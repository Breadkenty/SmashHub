import React, { useState } from 'react'
import moment from 'moment'
import { authHeader } from '../auth'

import { getUserId } from '../auth'

export function Comment(props) {
  console.log(props)
  const [editedComment, setEditedComment] = useState(props.comment)

  const [editingComment, setEditingComment] = useState(false)
  const [errorMessage, setErrorMessage] = useState()

  function handleTextChange(event) {
    setEditedComment({
      ...editedComment,
      body: event.target.value,
    })
  }
  function submitComment(event) {
    event.preventDefault()

    console.log(editedComment)

    fetch(`/api/Comments/${parseInt(props.comment.id)}`, {
      method: 'PUT',
      headers: { 'content-type': 'application/json', ...authHeader() },
      body: JSON.stringify(editedComment),
    })
      .then(response => {
        console.log(response)
        // return response.json()
        if (response.status === 401) {
          return { status: 401, errors: { login: 'Not Authorized' } }
        } else if (response.status === 404) {
          // This one is for user doesn't match logged in user
          return { status: 404, errors: { login: 'Not Authorized' } }
        } else {
          return response.json()
        }
      })
      .then(apiData => {
        console.log(apiData)
        if (apiData.errors) {
          const newMessage = Object.values(apiData.errors).join(' ')
          setErrorMessage(newMessage)
          console.log(apiData.errors)
        } else {
          setEditingComment(false)
          props.getCombo()
        }
      })
  }
  return (
    <div className="comment">
      <div className="vote">
        <button
          className="button-blank"
          onClick={event => {
            props.handleVote(event, 'CommentVotes', props.comment.id, 'upvote')
          }}
        >
          <svg
            aria-hidden="true"
            className="m0 svg-icon iconArrowUpLg"
            width="36"
            height="36"
            viewBox="0 0 36 36"
          >
            <path d="M2 26h32L18 10 2 26z"></path>
          </svg>
        </button>
        <h3 className="black-text">{props.comment.netVote}</h3>
        <button
          className="button-blank"
          onClick={event => {
            props.handleVote(
              event,
              'CommentVotes',
              props.comment.id,
              'downvote'
            )
          }}
        >
          <svg
            aria-hidden="true"
            className="m0 svg-icon iconArrowDownLg"
            width="36"
            height="36"
            viewBox="0 0 36 36"
          >
            <path d="M2 10h32L18 26 2 10z"></path>
          </svg>
        </button>
      </div>

      <div className="body">
        <h5>
          Posted by {props.comment.user.displayName}{' '}
          {moment(props.comment.datePosted).fromNow()}
          <button
            className="edit"
            onClick={() => {
              setEditingComment(true)
            }}
          >
            edit
          </button>
        </h5>
        {editingComment && (
          <form className="edit-comment" onSubmit={submitComment}>
            <textarea value={editedComment.body} onChange={handleTextChange} />
            <button className="bg-yellow button black-text" type="submit">
              Submit
            </button>
          </form>
        )}
        {editingComment || <p>{props.comment.body}</p>}
      </div>
    </div>
  )
}
