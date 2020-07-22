import React, { useState } from 'react'

export function SortController(props) {
  let [sortButtonActive, setSortButtonActive] = useState(false)

  function handleSortButton() {
    if (!sortButtonActive) {
      setSortButtonActive(true)
    } else {
      setSortButtonActive(false)
    }
  }

  function handleSortButtonClick(event) {
    props.setSortType(event.target.value)
  }

  return (
    <div className="sort-controller">
      <div>
        <span>Sort by</span>
        <button onClick={handleSortButton}>
          Best
          <i class="fas fa-caret-down"></i>
        </button>
      </div>
      <div
        className="pop-up-box"
        style={
          sortButtonActive
            ? {
                display: 'flex',
              }
            : {
                display: 'none',
              }
        }
      >
        <button
          value="best"
          onClick={event => {
            handleSortButtonClick(event)
            setSortButtonActive(false)
          }}
        >
          Best
        </button>
        <button
          value="newest"
          onClick={event => {
            handleSortButtonClick(event)
            setSortButtonActive(false)
          }}
        >
          Newest
        </button>
        <button
          value="oldest"
          onClick={event => {
            handleSortButtonClick(event)
            setSortButtonActive(false)
          }}
        >
          Oldest
        </button>
      </div>
    </div>
  )
}
