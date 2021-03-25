import React, { useEffect, useState } from "react";
import Button from "@material-ui/core/Button";

const baseUrl = process.env.REACT_APP_API_BASE_URL || "http://localhost:5000";

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
      <Button variant="contained">Default</Button>
      <Button variant="contained" color="primary">
        Primary
      </Button>
      <Button variant="contained" color="secondary">
        Secondary
      </Button>
      <Button variant="contained" disabled>
        Disabled
      </Button>
      <Button variant="contained" color="primary" href="#contained-buttons">
        Link
      </Button>

      <h1>Huh? what did you say?</h1>

      {characters &&
        characters.map((character) => (
          <p key={character.name}>{character.name}</p>
        ))}
    </div>
  );
}

export default App;
