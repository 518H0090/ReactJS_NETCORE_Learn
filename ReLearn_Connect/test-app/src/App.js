import "./App.css";
import { useEffect } from "react";
import { useState } from "react";

function App() {
  const [values, setValues] = useState(null);

  useEffect(() => {
    fetch("http://localhost:5010/api/Values")
      .then((data) => data.json())
      .then((json) => setValues(json));
  }, []);

  return (
    <>
      {values &&
        values.map((obj) => {
          return (
            <ul key={obj.id}>
              <li>{obj.name}</li>
              <li>{obj.information}</li>
              <li>{obj.numberMage}</li>
            </ul>
          );
        })}
    </>
  );
}

export default App;
