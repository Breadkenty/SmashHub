import React from 'react'
import andConditional from '../../graphics/inputs/png/conditional/and-conditional.png'
import thenConditional from '../../graphics/inputs/png/conditional/then-conditional.png'
import holdConditional from '../../graphics/inputs/png/conditional/hold-conditional.png'
import releaseConditional from '../../graphics/inputs/png/conditional/release-conditional.png'
import startRepeatConditional from '../../graphics/inputs/png/conditional/startrepeat-conditional.png'
import endRepeatConditional from '../../graphics/inputs/png/conditional/endrepeat-conditional.png'

export function Conditional(props) {
  return (
    <>
      <h3>Conditional</h3>
      <div className="controller-buttons">
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${andConditional})`,
          }}
          value="andConditional"
          onClick={props.addInput}
        />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${thenConditional})`,
          }}
          value="thenConditional"
          onClick={props.addInput}
        />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${holdConditional})`,
          }}
          value="holdConditional"
          onClick={props.addInput}
        />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${releaseConditional})`,
          }}
          value="releaseConditional"
          onClick={props.addInput}
        />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${startRepeatConditional})`,
          }}
          value="startRepeatConditional"
          onClick={props.addInput}
        />
        <button
          className="combo-input"
          style={{
            backgroundImage: `url(${endRepeatConditional})`,
          }}
          value="endRepeatConditional"
          onClick={props.addInput}
        />
      </div>
    </>
  )
}
