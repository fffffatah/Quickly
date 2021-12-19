import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import DefaultPage from "./components/Entry/DefaultPage";
import Home from "./components/Entry/Home";
import VerifyUser from "./components/Entry/VerifyUser";

function App() {
  return (
    <div className="App">
      <Router>
        <Routes>
          <Route exact path="/" element={<DefaultPage/>}/>
          <Route exact path="/home" element={<Home/>}/>
          <Route exact path="/verify/:id" element={<VerifyUser/>}/>
        </Routes>
      </Router>
    </div>
  );
}

export default App;
