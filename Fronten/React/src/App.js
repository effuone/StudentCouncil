import { createContext } from "react";
import { BrowserRouter } from 'react-router-dom';
import AppRouter from "./components/AppRouter";

export const Context = createContext(null)

function App() {
  return (
    <BrowserRouter>
      <AppRouter />
    </BrowserRouter>
  );
}

export default App;
