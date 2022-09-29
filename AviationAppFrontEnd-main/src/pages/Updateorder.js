import {react,Component} from "react";
import { useState, useEffect } from "react";
import "../styles/login.css"
import Navbar3 from "../components/Navbar3";

const Updateorder=()=>{
    return (
      <div>
        <Navbar3/>
    <div className="container">
        <form onSubmit={alert("Updated")}>
          <h1>Update Order Status</h1>
          <div className="ui divider"></div>
          <div className="ui form">
          <div className="field">
            <label>Order ID</label>
            <br></br>
            <input
              type="text"
              name="orderid"
            />
          </div>
          <div className="field">
          <br/><br/>
            <label>Current Status: </label>
            <label name="currstatus">{}Pending</label>
            
            <br></br>    
          </div>
          <div className="field">
          <br/><br/> 
            <label>Enter New Status</label>
            <br></br>
            <select name="newstatus" id="newstatus">
                  <option value="pending">Preparing</option>
                  <option value="fulfilled">Dispatch</option>
                  <option value="pending">Pending</option>
                  <option value="fulfilled">Fullfilled</option>
                
                </select>
          </div>
          
            <button className="fluid ui button blue">Update Order</button>
          </div>
        </form>
      </div>
      </div>
    )
}

export default Updateorder;