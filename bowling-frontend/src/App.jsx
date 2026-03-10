import Heading from "./components/Heading";
import BowlerTable from "./components/BowlerTable";
import "./App.css";

// App component -- root of the app, renders the Heading and BowlerTable
function App() {
  return (
    <div>
      {/* Page heading with title and description */}
      <Heading />

      {/* Table listing all Marlins and Sharks bowlers */}
      <BowlerTable />
    </div>
  );
}

export default App;
