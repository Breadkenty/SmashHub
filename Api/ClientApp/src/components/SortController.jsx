import React, { useState } from 'react'
import useOnClickOutside from 'use-onclickoutside'

export function SortController(props) {
  const ref = React.useRef(null)

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

  useOnClickOutside(ref, () => {
    if (sortButtonActive) {
      handleSortButton()
    }
  })

  return (
    <div className="sort-controller">
      <div>
        <span>Sort by</span>
        <button className="sort-controller-active" onClick={handleSortButton}>
          {props.sortType}
          <i className="fas fa-caret-down"></i>
        </button>
      </div>
      <div
        ref={ref}
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
