import React from 'react'
import moment from 'moment'

export function Comment(props) {
  return (
    <div className="comment">
      <div className="vote">
        <svg
          aria-hidden="true"
          className="m0 svg-icon iconArrowUpLg"
          width="36"
          height="36"
          viewBox="0 0 36 36"
        >
          <path d="M2 26h32L18 10 2 26z"></path>
        </svg>
        <h3 className="black-text">{props.comment.netVote}</h3>
        <svg
          aria-hidden="true"
          className="m0 svg-icon iconArrowDownLg"
          width="36"
          height="36"
          viewBox="0 0 36 36"
        >
          <path d="M2 10h32L18 26 2 10z"></path>
        </svg>
      </div>

      <div className="body">
        <h5>
          Posted by Tacotastic{' '}
          {moment(props.comment.datePosted)
            .startOf('hour')
            .fromNow()}
        </h5>
        <p>{props.comment.body}</p>
      </div>
    </div>
  )
}
