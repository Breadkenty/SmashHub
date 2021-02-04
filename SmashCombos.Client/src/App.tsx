import React, { useState } from "react";

function App() {
  const baseUrl = process.env.REACT_APP_API_BASE_URL;
  const [characters, setCharacters] = useState([]);

  function getCharacters() {
    fetch(`${baseUrl}/characters`)
      .then((response) => response.json())
      .then((apiData) => setCharacters(apiData));
  }

  getCharacters();

  console.log(characters);
  return (
    <div className="App">
      <h1>Huh? what did you say?</h1>
    </div>
  );
}

export default App;
