import {react,Component} from "react";
import { useState, useEffect } from "react";
import "../styles/login.css"
import Navbar from "../components/Navbar";
import { gql, ApolloClient, ApolloProvider, HttpLink, InMemoryCache, useMutation } from "@apollo/client";



const clientServer = new ApolloClient({
    cache: new InMemoryCache(),
    link: new HttpLink({
        uri: "https://localhost:5001/graphql"
    }),
    credentials: "same-origin"
})


function FlightAdd(fnumber, forigin, fdestination ,airtype,clientid){
  //console.log(cemail)
  clientid=parseInt(clientid)
    clientServer.mutate({
      mutation: gql`
          mutation createFlight($flight:FlightInputType!){
            createFlight(flight:$flight){
              flights{
                flightNo
              
              }
            }
          }`,
      variables: {flight:{flightno:fnumber, origin: forigin,destination:fdestination,aircrafttype:airtype,clientid:clientid}},
    })
    .then(result => {
      if(result.data.createFlightr===null){
        alert("New Flight cannot be added");
        window.location.href = 'home';
    }
    console.log(result);
    alert("New Flight Created")
    window.location.href = 'Orderfuel';

    })
  }

const Addnewflights=()=>{
  const handleSubmit = (e) => {
    e.preventDefault();
    console.log(e.target.flightno.value)
    FlightAdd(e.target.flightno.value,e.target.Origin.value,e.target.Destination.value,e.target.aircrafts.value,e.target.clientid.value)
  };
  return (
    <div>
      <Navbar/>
    <div className="container">
        <form onSubmit={handleSubmit}>

          <h1>Add New Flight</h1>
          <div className="ui divider"></div>
          <div className="ui form">
          <div className="field">
            <label>Flight No</label>
            <br></br>
            <input id="flightno"
              type="text"
              name="flightno"
            />
          </div>
          <br></br>
          <div className="field">
            <label>Client ID</label>
            <br></br>
            <input id="clientid"
              type="text"
              name="clientid"
            />
          </div>
          <br></br>
          <div className="field">
            <label>Origin</label>
            <br></br><br></br>
            <select name="Origin" id="Origin">
                  <option value="Mumbai">Mumbai</option>
                  <option value="Chennai">Chennai</option>
                  <option value="Kolkata">Kolkata</option>
                  <option value="Delhi">Delhi</option>
                  <option value="Bangalore">Bangalore</option>
            </select>
          </div>
          <br></br>
          <div className="field">
            <label>Destination</label>
            <br></br><br></br>
            <select name="Destination" id="Destination">
                  <option value="Delhi">Delhi</option>
                  <option value="Mumbai">Mumbai</option>
                  <option value="Chennai">Chennai</option>
                  <option value="Kolkata">Kolkata</option>
                  <option value="Bangalore">Bangalore</option>
            </select>
          </div>
          <br></br>
          <div className="field">
            <label>Aircraft Type</label>
            <br></br><br></br>
            <select name="aircrafts" id="aircrafts">
                  <option value="Airbus A319neo">Airbus A319neo</option>
                  <option value="ATR Evo">ATR Evo</option>
                  <option value="Boeing 777X">Boeing 777X</option>
                  <option value="Cessna 408">Cessna 408</option>
                  <option value="Irkut MC-21">Irkut MC-21</option>
                  <option value="TVRS-44 Ladoga">TVRS-44 Ladoga</option>
                  <option value="CRAIC CR929">CRAIC CR929</option>
                  <option value="Comac C919">Comac C919</option>
            </select>
          </div>
            <button className="fluid ui button blue">Submit</button>
          </div>
        </form>
      </div>
      </div>
    )
}

export default Addnewflights;