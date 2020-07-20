import React from 'react'
import upFlick from '../../graphics/inputs/png/flick/up-flick.png'
import forwardFlick from '../../graphics/inputs/png/flick/forward-flick.png'
import downFlick from '../../graphics/inputs/png/flick/down-flick.png'
import backFlick from '../../graphics/inputs/png/flick/back-flick.png'

export function Flick() {
  return (
    <>
      <h3>Flick</h3>
      <div className="controller-buttons">
        <div className="blank-input-space" />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${upFlick})`,
          }}
        />
        <div className="blank-input-space" />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${backFlick})`,
          }}
        />
        <div className="blank-input-space" />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${forwardFlick})`,
          }}
        />
        <div className="blank-input-space" />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${downFlick})`,
          }}
        />
        <div className="blank-input-space" />
      </div>
    </>
  )
}
