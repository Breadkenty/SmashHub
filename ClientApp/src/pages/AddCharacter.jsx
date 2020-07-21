import React from 'react'

export function AddCharacter() {
  return (
    <div className="add-character">
      <fieldset>
        <label for="name">Name</label>
        <input
          className="bg-yellow"
          id="name"
          type="text"
          placeholder="Mario"
        />
      </fieldset>

      <fieldset>
        <label for="variable-name">VariableName</label>
        <input
          className="bg-yellow"
          id="variable-name"
          type="text"
          placeholder="ZeroSuitSamus"
        />
      </fieldset>

      <fieldset>
        <label for="y-position">Y Position</label>
        <input
          className="bg-yellow"
          id="y-position"
          type="text"
          placeholder="20"
        />
      </fieldset>

      <button className="button bg-yellow black-text">Submit</button>
    </div>
  )
}
