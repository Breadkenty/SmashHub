import React from 'react'
import { Link } from 'react-router-dom'

export function Forbidden() {
  return (
    <div className="forbidden">
      <h1>Whoops!</h1>
      <h3>Looks like you're not supposed to be here...</h3>
      <Link to="/">Click here to return to the character select screen</Link>
    </div>
  )
}
