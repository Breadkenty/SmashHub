import React, { useState } from 'react'
import { Link } from 'react-router-dom'

export function Reports() {
  return (
    <div className="reports">
      <header>
        <h1>Reports</h1>
      </header>

      <section>
        <p>Reports</p>
        <p>User</p>
        <p>2</p>
        <Link to="/Breadkenty">BreadKenty</Link>
      </section>
    </div>
  )
}
