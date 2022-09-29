import React from "react";
import { MenuList } from "../helpers/MenuList";
import MenuItem from "../components/MenuItem";
import "../styles/Menu.css";
import { Link } from "react-router-dom";
import Navbar from "../components/Navbar";

function Menu() {
  return (
    <div>
      <Navbar/>
    <div className="menu">
      <h1 className="menuTitle">Our Menu</h1>
      <div className="headerContainer">
      <Link to="/Addnewflights">
          <button> Add New Flights </button>
      </Link>
      <br/><br/><br/><br/><br/>      
      <Link to="/Orderfuel">         
        <button> Order Fuel </button>
      </Link>
      <br/><br/><br/><br/><br/>      
      <Link to="/Vieworders">         
        <button> View Orders </button>
      </Link>
      </div>
    </div>
    </div>
  );
}

export default Menu;