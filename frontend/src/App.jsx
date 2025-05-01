import { ToastContainer, toast } from "react-toastify";
import React from "react";
import { Routes, Route, useMatch } from "react-router-dom";
import NavBar from "./components/user/NavBar";
import Home from "./pages/user/Home";

const App = () => {
  return (
    <div className="text-default min-h-screen bg-white">
      <ToastContainer />
      <NavBar />
      <Routes>
        <Route path="/" element={<Home />} />
      </Routes>
    </div>
  );
};

export default App;
