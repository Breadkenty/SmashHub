import React from 'react'
import upSmash from '../../graphics/inputs/png/smash/up-smash.png'
import forwardSmash from '../../graphics/inputs/png/smash/forward-smash.png'
import downSmash from '../../graphics/inputs/png/smash/down-smash.png'
import backSmash from '../../graphics/inputs/png/smash/back-smash.png'

export function Smash(props) {
  return (
    <>
      <h3>Smash</h3>
      <div className="controller-buttons">
        <div className="blank-input-space" />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${upSmash})`,
          }}
          value="upSmash"
          onClick={props.addInput}
        />
        <div className="blank-input-space" />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${backSmash})`,
          }}
          value="backSmash"
          onClick={props.addInput}
        />
        <div className="blank-input-space" />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${forwardSmash})`,
          }}
          value="forwardSmash"
          onClick={props.addInput}
        />
        <div className="blank-input-space" />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${downSmash})`,
          }}
          value="downSmash"
          onClick={props.addInput}
        />
        <div className="blank-input-space" />
      </div>
    </>
  )
}
