import {react,Component} from "react";
import { useState, useEffect } from "react";
import "../styles/login.css";
import Navbar2 from "../components/Navbar2";
import { gql, ApolloClient, ApolloProvider, HttpLink, InMemoryCache, useQuery } from "@apollo/client";

const clientServer = new ApolloClient({
  cache: new InMemoryCache(),
  link: new HttpLink({
      uri: "https://localhost:5001/graphql"
  }),
  credentials: "same-origin"
})
function ClientDetails(cemail,cpassword){
//console.log(cemail)
clientServer.query({
  query: gql`
      query getClientsbyEmail($email: String!,$password:String!){
        getClientsbyEmail(email:$email,password:$password){
          clients{
            clientId
            clientName
          }
        }
      }`,
  variables: {email: cemail,password: cpassword},
})
.then(result => {
if (result.data.getClientsbyEmail.length==0){
  
  alert("Please Register")
  window.location.href = "Signup"
}
else
{
  // console.log(result.data.getClientsbyEmail[0].clients[0].clientName)
  alert("Login Successful")
  window.location.href="Home"
}
})
}


const Login=()=>{
    const initialValues = { email: "", password: "" };
    const [formValues, setFormValues] = useState(initialValues);
    const [formErrors, setFormErrors] = useState({});
    const [isSubmit, setIsSubmit] = useState(false);
  
    const handleChange = (e) => {
      const { name, value } = e.target;
      setFormValues({ ...formValues, [name]: value });
    };
  
    const handleSubmit = (e) => {
      e.preventDefault();
      ClientDetails(e.target.email.value,e.target.password.value)
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
      const regex = /^[^\s@]+@[^\s@]+\.[^\s@]{2,}$/i;
      if (!values.email) {
        errors.email = "Email is required!";
      } else if (!regex.test(values.email)) {
        errors.email = "This is not a valid email format!";
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
          <h1>Login</h1>
          <div className="ui divider"></div>
          <div className="ui form">
          <div className="field">
            <label>Email</label>
            <br/>
            <input
              type="text"
              name="email"
              value={formValues.email}
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

export default Login;