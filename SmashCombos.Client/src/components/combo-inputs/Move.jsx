import React from 'react'
import upMove from '../../graphics/inputs/png/move/up-move.png'
import forwardMove from '../../graphics/inputs/png/move/forward-move.png'
import downMove from '../../graphics/inputs/png/move/down-move.png'
import backMove from '../../graphics/inputs/png/move/back-move.png'

export function Move(props) {
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
          value="upMove"
          onClick={props.addInput}
        />
        <div className="blank-input-space" />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${backMove})`,
          }}
          value="backMove"
          onClick={props.addInput}
        />
        <div className="blank-input-space" />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${forwardMove})`,
          }}
          value="forwardMove"
          onClick={props.addInput}
        />
        <div className="blank-input-space" />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${downMove})`,
          }}
          value="downMove"
          onClick={props.addInput}
        />
        <div className="blank-input-space" />
      </div>
    </>
  )
}
