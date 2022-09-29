import {react,Component} from "react";
import { useState, useEffect } from "react";
import "../styles/login.css"
import Navbar3 from "../components/Navbar3";

const Updatefuel=()=>{
    return (
      <div>
        <Navbar3/>
    <div className="container">
        <form>
          <h1>Update Fuel Details</h1>
          <div className="ui divider"></div>
          <div className="ui form">
          <div className="field">
            <label>Fuel ID</label>
            <br></br>
            <input
              type="text"
              name="fuelid"
            />
          </div>
          <div className="field">
            <br/>
            <label>Fuel Name</label>
            <br></br>
            <input
              type="text"
              name="fuelname"
            />
          </div>
          <div className="field">
            <br/>
            <label>Cost</label>
            <br></br>
            <input
              type="text"
              name="cost"
            />
          </div>
          <div className="field">
            <br/>
            <label>Last Updated</label>
            <br/>
            <input
              type="date"
              name="lastupdated"
            />
          </div>
          <div className="field">
            <br/>
            <label>Place</label>
            <br></br>
            <input
              type="text"
              name="place"
            />
          </div>
            <button className="fluid ui button blue">Update</button>
          </div>
        </form>
      </div>
      </div>
    )
}

export default Updatefuel;