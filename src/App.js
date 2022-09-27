import { useState, useEffect } from "react";
import "./App.css";
import SignUp from "./Components/Signup";
import { Route, Redirect, Routes, BrowserRouter as  Router, Link } from "react-router-dom";
import Login from './Components/Login';
import { Component } from "react/cjs/react.production.min";


class App extends Component{
  render(){
    return(
        <div>
          <Router>
          <nav className="">
            <ul>
              <li><Link to={'/Login'}>Login</Link></li>
              <li><Link to={'/SignUp'}>Signup</Link></li>
            </ul>
          </nav>
          <hr/>
          <Routes>
            <Route exact path='/SignUp' element={<SignUp/>}/>
            <Route path='/Login' element={<Login />}/>          
          </Routes>
          </Router>
        </div>
    )
  }
}


export default App;
