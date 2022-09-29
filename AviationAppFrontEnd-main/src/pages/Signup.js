import { useState, useEffect } from "react";
import { Component } from "react/cjs/react.development";
import {react} from "react";
//import "../styles/login.css"
import Navbar2 from "../components/Navbar2";
import { gql, ApolloClient, ApolloProvider, HttpLink, InMemoryCache, useMutation } from "@apollo/client";



const clientServer = new ApolloClient({
    cache: new InMemoryCache(),
    link: new HttpLink({
        uri: "https://localhost:5001/graphql"
    }),
    credentials: "same-origin"
})


function ClientAdd(cemail,cpassword,cgstin, cname){
  //console.log(cemail)
    clientServer.mutate({
      mutation: gql`
          mutation createClient($client:ClientInputType!){
            createClient(client:$client){
              clients{
                clientId
                clientName
              }
            }
          }`,
      variables: {client:{clientname:cname, email: cemail,password: cpassword,gstin:cgstin}},
    })
    .then(result => {
      if(result.data.createClient===null){
        alert("user Exists");
        window.location.href = 'home';
    }
    console.log(result);
    window.location.href = 'login';

    })
  }




export default function SignUp() {
  const initialValues = {  name:"",email: "",gstin: "", password: "", password1:"" };
  const [formValues, setFormValues] = useState(initialValues);
  const [formErrors, setFormErrors] = useState({});
  const [isSubmit, setIsSubmit] = useState(false);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormErrors(validate(formValues));
    setFormValues({ ...formValues, [name]: value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    setFormErrors(validate(formValues));
    ClientAdd(e.target.email.value,e.target.password.value,e.target.gstin.value,e.target.name.value)
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
    const regexgstin = /\d{2}[A-Z]{5}\d{4}[A-Z]{1}[A-Z\d]{1}[Z]{1}[A-Z\d]{1}/; 
    if (!values.email) {
      errors.email = "Email is required!";
    } else if (!regex.test(values.email)) {
      errors.email = "This is not a valid email format!";
    }
    if (!values.password) {
      errors.password = "Password is required";
    } else if (values.password.length < 4) {
      errors.password = "Password must be more than 4 characters";
    } 
    if (!values.gstin) {
      errors.gstin = "Gstin is required!";
    } else if (!regexgstin.test(values.gstin)) {
      errors.gstin = "This is not a valid gstin format!";
    }
    if (!values.password1) {
      errors.password1 = "Confirm Password please";
    }
    if(values.password!=values.password1){
      errors.password1 = "Passwords do not match!";
    }

    return errors;
  };
  
  return (
    <div>
      <Navbar2/>
    
    <div className="container">
      <form onSubmit={handleSubmit}>
      <h1>Sign Up </h1>
        <p>{formErrors.name}</p>
          <div className="field">
            <label>Name</label>
            <br/>
            <input
              type="text"
              name="name"
              value={formValues.name}
              onChange={handleChange}
            />
          </div>
          <p>{formErrors.username}</p>
          <div className="ui divider"></div>
          <div className="ui form">
          <div className="field">
            <label>Email</label>
            <br/>
            <input
              type="text"
              name="email"
              placeholder=""
              value={formValues.email}
              onChange={handleChange}
            />
          </div>
          <p>{formErrors.email}</p>
          <div className="field">
            <label>GSTIN</label>
            <br/>
            <input
              type="text"
              name="gstin"
              value={formValues.gstin}
              onChange={handleChange}
            />
          </div>
          <p>{formErrors.gstin}</p>
          <div className="field">
            <label>Password</label>
            <input
              type="password"
              name="password"
              placeholder=""
              value={formValues.password}
              onChange={handleChange}
            />
          </div>
          <p>{formErrors.password}</p>
          <div className="field">
            <label>Confirm Password</label>
            <input
              type="password"
              name="password1"
              value={formValues.password1}
              onChange={handleChange}
            />
          </div>
          <p>{formErrors.password1}</p>
          <button className="fluid ui button blue">Submit</button>
        </div>
      </form>
    </div>
    </div>
  );
}
  
  

//export default SignUp;