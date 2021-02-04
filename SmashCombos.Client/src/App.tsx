import React from "react";

function App() {
  const environment = process.env.NODE_ENV;
  return (
    <div className="App">
      <h1>Huh? what did you say?</h1>
      {environment}
    </div>
  );
}

export default App;
