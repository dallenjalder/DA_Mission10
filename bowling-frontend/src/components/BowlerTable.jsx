import { useEffect, useState } from "react";

// BowlerTable component -- fetches bowler data from the API and renders it in a table
function BowlerTable() {
  // bowlers: array of bowler objects from the API
  let [bowlers, setBowlers] = useState([]);
  // error: holds any fetch error message
  let [error, setError] = useState(null);

  // Fetch bowlers from the .NET API when the component mounts
  useEffect(() => {
    fetch("http://localhost:5250/api/bowlers")
      .then((response) => {
        if (!response.ok) {
          throw new Error("Failed to fetch bowler data");
        }
        return response.json();
      })
      .then((data) => setBowlers(data))
      .catch((err) => setError(err.message));
  }, []);

  // Show error message if the fetch failed
  if (error) {
    return <p style={{ color: "red" }}>Error: {error}</p>;
  }

  return (
    <div className="table-wrapper">
      <table>
        <thead>
          <tr>
            <th>Name</th>
            <th>Team</th>
            <th>Address</th>
            <th>City</th>
            <th>State</th>
            <th>Zip</th>
            <th>Phone</th>
          </tr>
        </thead>
        <tbody>
          {bowlers.map((bowler, index) => (
            <tr key={index}>
              {/* Combine first, middle initial, and last name into one cell */}
              <td>
                {bowler.bowlerFirstName}{" "}
                {bowler.bowlerMiddleInit ? bowler.bowlerMiddleInit + ". " : ""}
                {bowler.bowlerLastName}
              </td>
              <td>{bowler.teamName}</td>
              <td>{bowler.bowlerAddress}</td>
              <td>{bowler.bowlerCity}</td>
              <td>{bowler.bowlerState}</td>
              <td>{bowler.bowlerZip}</td>
              <td>{bowler.bowlerPhoneNumber}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default BowlerTable;
