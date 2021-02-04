import React, { useEffect, useState } from "react";

const baseUrl = process.env.REACT_APP_API_BASE_URL;

interface Character {
  id: number;
  name: string;
  yPosition: number;
  releaseOrder: number;
}

function App() {
  const [characters, setCharacters] = useState<Character[]>([]);

  function getCharacters() {
    fetch(`${baseUrl}/characters`)
      .then((response) => response.json())
      .then((apiData) => setCharacters(apiData));
  }

  useEffect(getCharacters, []);

  return (
    <div className="App">
      <h1>Huh? what did you say?</h1>

      {characters &&
        characters.map((character: Character) => <p>{character.name}</p>)}
    </div>
  );
}

export default App;
