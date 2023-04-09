// // import logo from './logo.svg';
// import './App.css';
// import LoginPage from './My Components/LoginPage';
// import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
// import { Routes } from 'react-router-dom';
// import VehicleForm from './My Components/VehicleForm';
// import DailyDataForm from './My Components/DailyDataForm';
// import DateWiseView from './My Components/DateWiseView';
// import AverageView from './My Components/AverageView';
// import ConsolidatedView from './My Components/ConsolidatedView';

// import { Link } from 'react-router-dom';
// import DashBoard from './My Components/DashBoard';
// import { useState } from 'react';

// // function Navigation() {
// //   return (
// //     <nav>
// //       <ul>
// //         <li>
// //           <Link to="/">VehicleForm</Link>
// //         </li>
// //         <li>
// //           <Link to="/daily-data">Daily Data Form</Link>
// //         </li>
// //         <li>
// //           <Link to="/dashboard">Dashboard View</Link>
// //         </li>
// //         <li>
// //           <Link to="/date-wise-table">Date-wise Tabular View</Link>
// //         </li>
// //         <li>
// //           <Link to="/average-view">Average View</Link>
// //         </li>
// //         <li>
// //           <Link to="/consolidated-view">Consolidated View</Link>
// //         </li>
// //       </ul>
// //     </nav>
// //   );
// // }

// function App() {
//   const [isLoggedIn, setIsLoggedIn] = useState(false);
//   return (
//     <Router>

//       <Routes>
//         <Route exact path="/login" element={<LoginPage setIsLoggedInFunc={setIsLoggedIn} />}  />
//         <Route exact path="/dashboard" element={<DashBoard />} />
//         {/* <Route exact path="/Vehicleform" element={<VehicleForm />} />
//         <Route exact path="/daily-data" element={<DailyDataForm />} />
//         <Route exact path="/date-wise-table" element={<DateWiseView />} />
//         <Route exact path="/average-view" element={<AverageView />} />
//         <Route exact path="/consolidated-view" element={<ConsolidatedView />} /> */}
//       </Routes>
//     </Router>
//   );
// }

// export default App;


import React, { createContext, useState } from 'react'

import {
  BrowserRouter as Router,
  Route,
  Routes
} from 'react-router-dom'
import DashBoard from './Components/DashBoard'
import Login from './Components/Login'
import Register from './Components/Register'


export const AppContext = createContext();

const App = () => {

  const [rootUser, setRootUser] = useState({})

  return (
    <AppContext.Provider value={{
      rootUser,
      setRootUser
    }}>
      <Router>
        <Routes>
          <Route exact path="/" element={<DashBoard />} />
          <Route exact path="/login" element={<Login />} />
          <Route exact path="/register" element={<Register />} />
        </Routes>
      </Router>
    </AppContext.Provider>
  )
}

export default App

