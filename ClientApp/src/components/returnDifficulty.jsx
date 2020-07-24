import React from 'react'

export function returnDifficulty(difficulty) {
  switch (difficulty) {
    case 'very easy':
      return <div className="very-easy">very easy</div>
    case 'easy':
      return <div className="easy">easy</div>
    case 'medium':
      return <div className="medium">medium</div>
    case 'hard':
      return <div className="hard">hard</div>
    case 'very hard':
      return <div className="very-hard">very hard</div>
    default:
      return <div className="very-hard">very hard</div>
  }
}
