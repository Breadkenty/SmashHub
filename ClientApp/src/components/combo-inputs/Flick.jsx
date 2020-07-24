import React from 'react'
import upFlick from '../../graphics/inputs/png/flick/up-flick.png'
import forwardFlick from '../../graphics/inputs/png/flick/forward-flick.png'
import downFlick from '../../graphics/inputs/png/flick/down-flick.png'
import backFlick from '../../graphics/inputs/png/flick/back-flick.png'

export function Flick(props) {
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
          value="upFlick"
          onClick={props.addInput}
        />
        <div className="blank-input-space" />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${backFlick})`,
          }}
          value="backFlick"
          onClick={props.addInput}
        />
        <div className="blank-input-space" />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${forwardFlick})`,
          }}
          value="forwardFlick"
          onClick={props.addInput}
        />
        <div className="blank-input-space" />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${downFlick})`,
          }}
          value="downFlick"
          onClick={props.addInput}
        />
        <div className="blank-input-space" />
      </div>
    </>
  )
}
