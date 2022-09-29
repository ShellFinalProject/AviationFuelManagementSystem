import React from "react";
import MultiplePizzas from "../assets/Aboutus.png";
import "../styles/About.css";
import Navbar from "../components/Navbar";


function About() {
  return (
    <div>
      <Navbar/>
    <div className="about">
      <div
        className="aboutTop"
        style={{ backgroundImage: `url(${MultiplePizzas})` }}
      ></div>
      <div className="aboutBottom">
        <h1> ABOUT US</h1>
        <p>
        We are the aviation fuel distribution company , our main motive is to supply ample amount of fuel to all our customers. We have major airline companies as our customers , and we supply fuel to them which is our major job.
<br></br><br></br>
We make sure that we show the fluctuating prices of every type of fuel in order to help our customers to understand the prices of fuel better.
<br></br><br></br>
We aim at making flying easier and higher for our consumers!
        </p>
      </div>
    </div>
    </div>
  );
}

export default About;
