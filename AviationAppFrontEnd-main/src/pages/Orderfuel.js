import {react,Component} from "react";
import { useState, useEffect } from "react";
import "../styles/login.css"
import Navbar from "../components/Navbar";
import { gql, ApolloClient, ApolloProvider, HttpLink, InMemoryCache, useMutation } from "@apollo/client";
import { getDirectiveNames } from "@apollo/client/utilities";



const clientServer = new ApolloClient({
    cache: new InMemoryCache(),
    link: new HttpLink({
        uri: "https://localhost:5001/graphql"
    }),
    credentials: "same-origin"
})


function OrderAdd(fno ,amt, fueldate,fuelname){
  amt=parseFloat(amt)
  fuelname=parseInt(fuelname)
  clientServer.query({
    query: gql`
        query getfuel12{
   							fuels{
              fuelId
              fuelName
            }    
        }`
  })
  .then(result => {
  console.log(result.data.fuels)
  })
  
    clientServer.mutate({
      mutation: gql`
          mutation createOrder1($order:OrderInputType!){
            createOrder(order:$order){
              orders{
                flightNo
                
              }
            }
          }`,
      variables: {order:{flightno:fno,fuelamt:amt, clientid:2, fuelid:fuelname,status:"Pending"}},
    })
    .then(result => {
      if(result.data.createOrder===null){
        alert("Fuel order cannot be created");
        window.location.href = 'home';
    }

    alert("Order created. Order No: " + result.data.createOrder.orderId.ToString())
    window.location.href = 'vieworders';

     })
  }


const Orderfuel=()=>{
  const handleSubmit = (e) => {
    e.preventDefault();
    OrderAdd(e.target.flightno.value,e.target.amt.value,e.target.preferreddeldate.value,e.target.fuels.value)
  }
      return (
          <div>
              <Navbar/>
          <div className="container">
              <form onSubmit={handleSubmit}>    
                <h1>Order Fuel</h1>
                <div className="ui divider"></div>
                <div className="ui form">
                <div className="field">
                  <br></br>
                  <label>Flight No</label>
                  <br></br>
                  <input
                    type="text"
                    id="flightno"
                    name="flightno"
                  />
                </div>
                <div className="field">
                  <br/>
                  <label>Amount of Fuel</label>
                  <input
                    type="text"
                    name="amt"
                  />
                </div>
                <div className="field">
                  <br></br>
                  <label>Preferred Delivery Date</label>
                  <br></br>
                  <br></br>
                  <input
                    type="date"
                    name="preferreddeldate"
                  />
                </div>
                <div className="field">
                  <br></br>
                  <label>Fuel Type</label>
                  <br></br><br></br>
         
                  <input
                    type="text"
                    name="fuels"
                    id="fuels"
                  />

                </div>
                  <button className="fluid ui button blue">Submit</button>
                </div>
              </form>
            </div>
            </div>
          )
      
      }
  
  export default Orderfuel;