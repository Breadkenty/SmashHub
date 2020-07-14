import React from 'react'

const NotFound = () => {
  return (
    <div>
      <h2>
        {Math.ceil(Math.random() * 100) % 2 === 0 ? (
          <span>🤷🏼‍♂️</span>
        ) : (
          <span>🤷‍♀️</span>
        )}
        Not sure how you got here. Do you want to{' '}
        <a href="" onclick="window.history.go(-1); return false;">
          go back?
        </a>
      </h2>
    </div>
  )
}

export default NotFound
