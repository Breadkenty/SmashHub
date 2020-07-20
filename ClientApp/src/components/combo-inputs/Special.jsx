import React from 'react'
import upSpecial from '../../graphics/inputs/png/special/up-special.png'
import forwardSpecial from '../../graphics/inputs/png/special/forward-special.png'
import downSpecial from '../../graphics/inputs/png/special/down-special.png'
import backSpecial from '../../graphics/inputs/png/special/back-special.png'
import neutralSpecial from '../../graphics/inputs/png/special/neutral-special.png'
// Throw

export function Special() {
  return (
    <>
      <h3>Special</h3>
      <div className="controller-buttons">
        <div className="blank-input-space" />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${upSpecial})`,
          }}
        />
        <div className="blank-input-space" />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${backSpecial})`,
          }}
        />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${neutralSpecial})`,
          }}
        />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${forwardSpecial})`,
          }}
        />
        <div className="blank-input-space" />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${downSpecial})`,
          }}
        />
        <div className="blank-input-space" />
      </div>
    </>
  )
}
