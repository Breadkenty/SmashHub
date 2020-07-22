import React from 'react'

export function returnTrueCombo(trueCombo) {
  if (trueCombo) {
    return <div className="true-combo">true</div>
  } else {
    return <div className="not-true-combo">not true</div>
  }
}
