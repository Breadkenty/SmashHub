import React from 'react'
import shortHop from '../../graphics/inputs/png/hop/short-hop.png'
import mediumHop from '../../graphics/inputs/png/hop/medium-hop.png'
import fullHop from '../../graphics/inputs/png/hop/full-hop.png'
// Smash
// Special

export function Hop(props) {
  return (
    <>
      <h3>Hop</h3>
      <div className="controller-buttons">
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${shortHop})`,
          }}
          value="shortHop"
          onClick={props.addInput}
        />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${mediumHop})`,
          }}
          value="mediumHop"
          onClick={props.addInput}
        />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${fullHop})`,
          }}
          value="fullHop"
          onClick={props.addInput}
        />
      </div>
    </>
  )
}
