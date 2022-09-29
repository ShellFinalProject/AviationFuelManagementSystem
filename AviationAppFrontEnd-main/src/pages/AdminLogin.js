import {react,Component} from "react";
import { useState, useEffect } from "react";
import Navbar2 from "../components/Navbar2";
import { gql, ApolloClient, ApolloProvider, HttpLink, InMemoryCache, useQuery } from "@apollo/client";



const clientServer = new ApolloClient({
    cache: new InMemoryCache(),
    link: new HttpLink({
        uri: "https://localhost:5001/graphql"
    }),
    credentials: "same-origin"
})
function AdminDetails(aid,apassword){
  aid=parseInt(aid)
  clientServer.query({
    query: gql`
        query getAdminsbyId($id: Int!,$password:String!){
          getAdminsbyId(id:$id,password:$password){
            admins{
              adminId
              adminName
            }
          }
        }`,
    variables: {id: aid,password: apassword},
})
.then(result => {
  if (result.data.getAdminsbyId.length==0){
    
    alert("Login unsuccessful, please retry")
    window.location.href = "AdminLogin"
  }
  else
  {
    // console.log(result.data.getClientsbyEmail[0].clients[0].clientName)
    alert("Login Successful")
    window.location.href="AdminHome"
  }
  })
  }


const AdminLogin=()=>{
    const initialValues = { id: "", password: "" };
    const [formValues, setFormValues] = useState(initialValues);
    const [formErrors, setFormErrors] = useState({});
    const [isSubmit, setIsSubmit] = useState(false);
  
    const handleChange = (e) => {
      const { name, value } = e.target;
      setFormValues({ ...formValues, [name]: value });
    };
  
    const handleSubmit = (e) => {
      e.preventDefault();
      AdminDetails(e.target.id.value,e.target.password.value)
      setFormErrors(validate(formValues));
      setIsSubmit(true);
    };
  
    useEffect(() => {
      console.log(formErrors);
      if (Object.keys(formErrors).length === 0 && isSubmit) {
        console.log(formValues);
      }
    }, [formErrors]);
    const validate = (values) => {
      const errors = {};
      if (!values.id) {
        errors.email = "ID is required!";
      } 
      if (!values.password) {
        errors.password = "Password is required";
      }
      return errors;
    };
  
    return (     
      <div>
          <Navbar2/>      
      <div className="container">
        <form onSubmit={handleSubmit}>
          <h1>Admin Login</h1>
          <div className="ui divider"></div>
          <div className="ui form">
          <div className="field">

            <label>ID</label>
            <br></br>
            <input
              type="text"
              name="id"
              value={formValues.id}
              onChange={handleChange}
            />
          </div>
          
          <p>{formErrors.email}</p>
         
            <div className="field">
              <label>Password</label>
              <input
                type="password"
                name="password"
                value={formValues.password}
                onChange={handleChange}
              />
            </div>
            <p>{formErrors.password}</p>
            <button className="fluid ui button blue">Submit</button>
          </div>
        </form>
      </div>
      </div>
    );
    
    }

export default AdminLogin;