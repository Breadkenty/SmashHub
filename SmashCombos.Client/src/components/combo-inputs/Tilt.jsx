import React from 'react'
import upTilt from '../../graphics/inputs/png/tilt/up-tilt.png'
import forwardTilt from '../../graphics/inputs/png/tilt/forward-tilt.png'
import downTilt from '../../graphics/inputs/png/tilt/down-tilt.png'
import backTilt from '../../graphics/inputs/png/tilt/back-tilt.png'

export function Tilt(props) {
  return (
    <>
      <h3>Tilt</h3>
      <div className="controller-buttons">
        <div className="blank-input-space" />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${upTilt})`,
          }}
          value="upTilt"
          onClick={props.addInput}
        />
        <div className="blank-input-space" />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${backTilt})`,
          }}
          value="backTilt"
          onClick={props.addInput}
        />
        <div className="blank-input-space" />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${forwardTilt})`,
          }}
          value="forwardTilt"
          onClick={props.addInput}
        />
        <div className="blank-input-space" />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${downTilt})`,
          }}
          value="downTilt"
          onClick={props.addInput}
        />
        <div className="blank-input-space" />
      </div>
    </>
  )
}
