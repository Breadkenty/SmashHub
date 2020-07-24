import React from 'react'
import upAerial from '../../graphics/inputs/png/aerial/up-aerial.png'
import forwardAerial from '../../graphics/inputs/png/aerial/forward-aerial.png'
import downAerial from '../../graphics/inputs/png/aerial/down-aerial.png'
import backAerial from '../../graphics/inputs/png/aerial/back-aerial.png'
import zAerial from '../../graphics/inputs/png/aerial/z-aerial.png'
import neutralAerial from '../../graphics/inputs/png/aerial/neutral-aerial.png'

export function Aerial(props) {
  return (
    <>
      <h3>Aerial</h3>
      <div className="controller-buttons">
        <div className="blank-input-space" />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${upAerial})`,
          }}
          value="upAerial"
          onClick={props.addInput}
        />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${zAerial})`,
          }}
          value="zAerial"
          onClick={props.addInput}
        />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${backAerial})`,
          }}
          value="backAerial"
          onClick={props.addInput}
        />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${neutralAerial})`,
          }}
          value="neutralAerial"
          onClick={props.addInput}
        />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${forwardAerial})`,
          }}
          value="forwardAerial"
          onClick={props.addInput}
        />
        <div className="blank-input-space" />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${downAerial})`,
          }}
          value="downAerial"
          onClick={props.addInput}
        />
        <div className="blank-input-space" />
      </div>
    </>
  )
}
