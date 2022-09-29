import React from "react";
import { Link } from "react-router-dom";
import BannerImage from "../assets/plane2.png";
import "../styles/Landing.css";
import Navbar2 from "../components/Navbar2";
//import ReactFragment from "react";

function Landing() {
  return (
    <div>
      <Navbar2/>   
    <div className="landing" style={{ backgroundImage: `url(${BannerImage})` }}>
      <div className="headerContainer">
        <h1> Need Fuel? We Got It </h1>
        <p> One stop for Airline Fuel Requirements</p>
        <Link to="/login">
          <button> LOGIN </button>
        </Link>
        <br/><br/><br/><br/><br/>      
        <Link to="/AdminLogin">         
          <button> ADMIN LOGIN</button>
        </Link>
        <br/>
          <br/>
          <br/> <br/>
          <br/>      
        <Link to="/Signup">         
          <button> SIGN UP </button>
        </Link>
      </div>
    </div>
    </div>
  );
}

export default Landing;
