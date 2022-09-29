import React from "react";
import { Link } from "react-router-dom";
import BannerImage from "../assets/plane.jpg";
import "../styles/Home.css";
import Navbar from "../components/Navbar";
import {useState} from "react";

function Home() {

  return (
    <div>
      <Navbar/>
    <div className="home" style={{ backgroundImage: `url(${BannerImage})` }}>
      <div className="headerContainer">
        <h1> Aviation Fuel System </h1>
        <p> We Sell Fuel</p>
        <Link to="/menu">
          <button> ORDER NOW </button>
        </Link>
      </div>
    </div>
    </div>
  );
}

export default Home;
