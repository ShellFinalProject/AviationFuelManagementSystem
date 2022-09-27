import { useState, useEffect } from "react";
import { Component } from "react/cjs/react.development";
import "./App.css";

export default function SignUp() {
  const initialValues = {  email: "",gstin: "", password: "", password1:"" };
  const [formValues, setFormValues] = useState(initialValues);
  const [formErrors, setFormErrors] = useState({});
  const [isSubmit, setIsSubmit] = useState(false);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormValues({ ...formValues, [name]: value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
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
    <>
    <div className="container">
      <form onSubmit={handleSubmit}>
        <h1>Sign Up </h1>
          <p>{formErrors.username}</p>
          <div className="ui divider"></div>
          <div className="ui form">
          <div className="field">
            <label>Email</label>
            <input
              type="text"
              name="email"
              placeholder="Email"
              value={formValues.email}
              onChange={handleChange}
            />
          </div>
          <p>{formErrors.email}</p>
          <div className="field">
            <label>GSTIN</label>
            <input
              type="text"
              name="gstin"
              placeholder="gstin"
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
              placeholder="Password"
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
              placeholder="Confirm Password"
              value={formValues.password1}
              onChange={handleChange}
            />
          </div>
          <p>{formErrors.password1}</p>
          <button className="fluid ui button blue">Submit</button>
        </div>
      </form>
    </div>
    </>
  );
}
  
  

//export default SignUp;