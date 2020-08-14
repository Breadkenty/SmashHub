import React from 'react'
import upThrow from '../../graphics/inputs/png/throw/up-throw.png'
import forwardThrow from '../../graphics/inputs/png/throw/forward-throw.png'
import downThrow from '../../graphics/inputs/png/throw/down-throw.png'
import backThrow from '../../graphics/inputs/png/throw/back-throw.png'

export function Throw(props) {
  return (
    <>
      <h3>Throw</h3>
      <div className="controller-buttons">
        <div className="blank-input-space" />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${upThrow})`,
          }}
          value="upThrow"
          onClick={props.addInput}
        />
        <div className="blank-input-space" />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${backThrow})`,
          }}
          value="backThrow"
          onClick={props.addInput}
        />
        <div className="blank-input-space" />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${forwardThrow})`,
          }}
          value="forwardThrow"
          onClick={props.addInput}
        />
        <div className="blank-input-space" />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${downThrow})`,
          }}
          value="downThrow"
          onClick={props.addInput}
        />
        <div className="blank-input-space" />
      </div>
    </>
  )
}
