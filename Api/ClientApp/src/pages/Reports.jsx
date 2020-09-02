import React, { useState, useEffect } from 'react'
import { Link } from 'react-router-dom'

export function Reports() {
  const [users, setUsers] = useState([])

  function getReports() {
    fetch('/api/Users')
      .then(response => response.json())
      .then(apiData => {
        setUsers(apiData)
      })
  }

  function sumReports(user) {
    let totalReports = 0
    user.combos.forEach(
      combo => (totalReports = totalReports + combo.reports.length)
    )
    user.comments.forEach(
      comment => (totalReports = totalReports + comment.reports.length)
    )
    return totalReports
  }

  useEffect(getReports, [])
  console.log(users)

  return (
    <div className="reports">
      <header>
        <h1>Reports</h1>
      </header>

      <section>
        <p>Reports</p>
        <p>User</p>
        {users
          .filter(user => sumReports(user) > 0)
          .map(user => (
            <>
              <p>{sumReports(user)}</p>
              <Link to={`/user/${user.displayName}`}>{user.displayName}</Link>
            </>
          ))}
      </section>
    </div>
  )
}
