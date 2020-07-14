import React, { useState } from 'react'

const HelloWorld = () => {
  const [counter, setCounter] = useState(0)
  return (
    <div>
      <h1>This is checking that hooks are in effect: {counter}</h1>
      <button onClick={() => setCounter(p => p + 1)}>click me!</button>
    </div>
  )
}

export default HelloWorld
