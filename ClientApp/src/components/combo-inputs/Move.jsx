import React from 'react'
import upMove from '../../graphics/inputs/png/move/up-move.png'
import forwardMove from '../../graphics/inputs/png/move/forward-move.png'
import downMove from '../../graphics/inputs/png/move/down-move.png'
import backMove from '../../graphics/inputs/png/move/back-move.png'

export function Move() {
  return (
    <>
      <h3>Move</h3>
      <div className="controller-buttons">
        <div className="blank-input-space" />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${upMove})`,
          }}
        />
        <div className="blank-input-space" />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${backMove})`,
          }}
        />
        <div className="blank-input-space" />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${forwardMove})`,
          }}
        />
        <div className="blank-input-space" />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${downMove})`,
          }}
        />
        <div className="blank-input-space" />
      </div>
    </>
  )
}
