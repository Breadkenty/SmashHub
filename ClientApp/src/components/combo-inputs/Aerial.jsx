import React from 'react'
import upAerial from '../../graphics/inputs/png/aerial/up-aerial.png'
import forwardAerial from '../../graphics/inputs/png/aerial/forward-aerial.png'
import downAerial from '../../graphics/inputs/png/aerial/down-aerial.png'
import backAerial from '../../graphics/inputs/png/aerial/back-aerial.png'
import zAerial from '../../graphics/inputs/png/aerial/z-aerial.png'
import neutralAerial from '../../graphics/inputs/png/aerial/neutral-aerial.png'

export function Aerial() {
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
        />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${zAerial})`,
          }}
        />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${backAerial})`,
          }}
        />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${neutralAerial})`,
          }}
        />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${forwardAerial})`,
          }}
        />
        <div className="blank-input-space" />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${downAerial})`,
          }}
        />
        <div className="blank-input-space" />
      </div>
    </>
  )
}
