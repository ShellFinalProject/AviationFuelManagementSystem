import {react,Component} from "react";
import { useState, useEffect } from "react";
import "../styles/login.css";
import Navbar from "../components/Navbar";
import { gql, ApolloClient, ApolloProvider, HttpLink, InMemoryCache, useQuery } from "@apollo/client";

const clientServer = new ApolloClient({
  cache: new InMemoryCache(),
  link: new HttpLink({
      uri: "https://localhost:5001/graphql"
  }),
  credentials: "same-origin"
})
function OrderDetails(oid){
//console.log(cemail)
oid=parseInt(oid)
clientServer.query({
  query: gql`
      query getOrderbyId($id:Int!){
        getOrderbyId(orderId:$id){
          orders{
            orderId
            clientId
            flightNo
            status
            fuelAmt
          }
        }
      }`,
  variables: {id: oid},
})
.then(result => {
  console.log(result.data)
if (result.data.getOrderbyId.length==0){
  
  alert("Order Not Found")
  window.location.href = "vieworders"
}
else
{
  // console.log(result.data.getClientsbyEmail[0].clients[0].clientName)
  var res=result.data.getOrderbyId[0].orders[0]
  document.getElementById("orid").innerHTML=res.orderid
  document.getElementById("flightno").innerHTML=res.flightno
  document.getElementById("amount").innerHTML=res.fuelamt
  document.getElementById("status").innerHTML="Pending"

}
});



const ViewFuelorders=()=>{
  const handleSubmit = (e) => {
    e.preventDefault();
    OrderDetails(e.target.orderid.value)
  };
  return (
    <div>
      <Navbar/>
      <div className="container1">
        <form onSubmit={handleSubmit}>    
            <h1>Enter order ID</h1>
            <div className="ui divider"></div>
            <div className="ui form">
            <div className="field">
              <label >Order ID</label>
              <br></br><br></br>
              <input
              id="orderid"
                type="text"
                name="orderid"
              />
            </div>
            </div>
            <button className="fluid ui button blue">View Status</button>
          </form>
      <table class="table table-dark">
<thead>
  <tr>
    <th scope="col">Order ID</th>
    <th scope="col">Flight Number</th>
    <th scope="col">Amount of Fuel</th>
    <th scope="col">Status</th>
  </tr>
</thead>
<tbody>
  <tr>
    <td id="orid"></td>
    <td id="flightno"></td>
    <td id="amount"></td>

    <td id="status"></td>
  </tr>
</tbody>
</table>
<br></br><br></br>
</div>
</div>
  )
  
}

}

export default ViewFuelorders;