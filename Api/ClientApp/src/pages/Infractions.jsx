import React, { useState } from 'react'
import { Infraction } from './Infraction'

export function Infractions(props) {
  const [toggleInfractionDropDown, setToggleInfractionDropDown] = useState(
    false
  )

  function sumInfraction(user) {
    let totalInfraction = 0
    user.infractions
      .filter(infraction => infraction.dismissDate == null)
      .forEach(
        infraction => (totalInfraction = totalInfraction + infraction.points)
      )
    return totalInfraction
  }

  return (
    <section className="user-details">
      <header>
        <div>
          <h3>Infractions:</h3>
          <h3 className="points">{sumInfraction(props.user)}</h3>
        </div>
        <button
          onClick={() => {
            if (!toggleInfractionDropDown) {
              setToggleInfractionDropDown(true)
            } else {
              setToggleInfractionDropDown(false)
            }
          }}
        >
          <svg
            viewBox="0 0 81 45"
            style={
              toggleInfractionDropDown ? { transform: 'rotate(360deg)' } : null
            }
          >
            <path d="M40.55 3.003L3.015 41.985l19.406.044h.007l18.119-18.818 18.127 18.818h19.357L40.55 3.003z"></path>
          </svg>
        </button>
      </header>

      <div
        className="drop-down"
        style={
          toggleInfractionDropDown ? { display: 'block' } : { display: 'none' }
        }
      >
        <div className="reports-header">
          <h5>Points</h5>
          <h5>Comment</h5>
          <h5>Moderator</h5>
          <h5>Date</h5>
        </div>
        {props.user.infractions
          .filter(infraction => infraction.dismissDate == null)
          .map(infraction => (
            <Infraction key={infraction.id} infraction={infraction} />
          ))}
      </div>
    </section>
  )
}
