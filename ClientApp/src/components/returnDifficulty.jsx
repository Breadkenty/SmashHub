import React from 'react'

export function returnDifficulty(difficulty) {
  switch (difficulty) {
    case 'very easy':
      return <div className="very-easy">very easy</div>
      break
    case 'easy':
      return <div className="easy">easy</div>
      break
    case 'medium':
      return <div className="medium">medium</div>
      break
    case 'hard':
      return <div className="hard">hard</div>
      break
    case 'very hard':
      return <div className="very-hard">very hard</div>
      break
    default:
      return <div className="very-hard">very hard</div>
  }
}
