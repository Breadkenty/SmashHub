import React from 'react'
import jabBasic from '../../graphics/inputs/png/basic/jab-basic.png'
import grabBasic from '../../graphics/inputs/png/basic/grab-basic.png'
import shieldBasic from '../../graphics/inputs/png/basic/shield-basic.png'

export function Basic() {
  return (
    <>
      <h3> Basic</h3>
      <div className="controller-buttons">
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${jabBasic})`,
          }}
        />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${grabBasic})`,
          }}
        />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${shieldBasic})`,
          }}
        />
      </div>
    </>
  )
}
