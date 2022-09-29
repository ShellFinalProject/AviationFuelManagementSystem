import React from "react";
import { MenuList } from "../helpers/MenuList";
import MenuItem from "../components/MenuItem";
import "../styles/Menu.css";
import { Link } from "react-router-dom";
import Navbar3 from "../components/Navbar3";

function Adminhome() {
  return (
    <div>
      <Navbar3/>
    <div className="menu">
      <h1 className="menuTitle">Admin Menu</h1>
      <div className="headerContainer">
      <Link to="/Addnewfuel">
          <button> Add New Fuel </button>
      </Link>
      <br/><br/><br/><br/><br/>      
      <Link to="/Updatefuel">     
        <button> Update Fuel Details </button>
      </Link>
      <br/><br/><br/><br/><br/>      
      <Link to="/Viewfuelorders">         
        <button> View Fuel Orders </button>
      </Link>
      <br/><br/><br/><br/><br/>      
      <Link to="/Updateorder">         
        <button> Update Order Status</button>
      </Link>
      </div>
    </div>
    </div>
  );
}
export default Adminhome;