import {react,Component} from "react";
import { useState, useEffect } from "react";
import "../styles/login.css"
import Navbar3 from "../components/Navbar3";

const Addnewfuel=()=>{
    return (
      <div>
        <Navbar3/>
    <div className="container">
        <form>
          <h1>Add New Fuel</h1>
          <div className="ui divider"></div>
          <div className="ui form">
          <div className="field">
            <label>Fuel Name</label>
            <br></br>
            <input
              type="text"
              name="fuelname"
            />
          </div>
          <div className="field">
            <br></br>
            <label>Cost</label>
            <br></br>
            <input
              type="text"
              name="cost"
            />
          </div>
          <div className="field">
            <br/><br/>
            <label>Place</label>
            <br></br>
            <input
              type="text"
              name="place"
            />
          </div>
            <button className="fluid ui button blue">Submit</button>
          </div>
        </form>
      </div>
      </div>
    )
}

export default Addnewfuel;