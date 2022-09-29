import React, { useState } from "react";
import Logo from "../assets/Icon.png";
import { Link } from "react-router-dom";
import ReorderIcon from "@material-ui/icons/Reorder";
import "../styles/Navbar.css";
import { Route } from "react-router-dom";

function Navbar3() {
  const [openLinks, setOpenLinks] = useState(false);

  const toggleNavbar = () => {
    setOpenLinks(!openLinks);
  };
  return (
    <div className="navbar">
      <div className="leftSide" id={openLinks ? "open" : "close"}>
      <Link to="/Adminhome"><img src={Logo} /></Link>
        <div className="hiddenLinks">
          <Link to="/Adminhome">Admin Home </Link>
          <Link to="/about2"> About </Link>
          <Link to="/contact2"> Contact </Link>
        </div>
      </div>
      <div className="rightSide">
        <Link to="/Adminhome">Admin Home </Link>
        <Link to="/about2"> About Us </Link>
        <Link to="/contact2"> Contact Us</Link>
        <Link to="/">Log Out</Link>
        <button onClick={toggleNavbar}>
          <ReorderIcon />
        </button>
      </div>
    </div>
  );
}

export default Navbar3;
