import React, { useState } from 'react'

const HeyWorld = () => {
  const [counter, setCounter] = useState<number>(0)
  return (
    <div>
      <h1>This is checking is TS is install: {counter}</h1>
      <h4>this is written in a TSX file</h4>
      <button onClick={() => setCounter(p => p + 1)}>Click me</button>
    </div>
  )
}

export default HeyWorld
