import React, { useState } from 'react';
import { NavLink as RRNavLink } from "react-router-dom";
import {
  Collapse,
  Navbar,
  NavbarToggler,
  NavbarBrand,
  Nav,
  NavItem,
  NavLink
} from 'reactstrap';
import { logout } from '../modules/authManager';
import "./Header.css"

export default function Header({ isLoggedIn }) {
  const [isOpen, setIsOpen] = useState(false);
  const toggle = () => setIsOpen(!isOpen);

  return (
    <div>
      <Navbar className='header'  light expand="md">
        <NavbarBrand tag={RRNavLink} to="/"><img src="/Top_logo-removebg-preview.PNG" alt="Welcome"width="125rem"/></NavbarBrand>
        <NavbarToggler onClick={toggle} />
        <Collapse isOpen={isOpen} navbar>
          <Nav className="mr-auto" navbar>
            { /* When isLoggedIn === true, we will render the Home link */}
            {isLoggedIn &&
              <NavItem>
                <NavLink tag={RRNavLink} to="/">Home</NavLink>
              </NavItem>
            }
            </Nav>
           
          <Nav className="mr-auto" navbar>
            {isLoggedIn &&
              <NavItem>
                <NavLink tag={RRNavLink} to="/mygames">My Games</NavLink>
              </NavItem>
            }
          </Nav>
            <Nav className="mr-auto" navbar>
            {isLoggedIn &&
              <NavItem>
                <NavLink tag={RRNavLink} to="/search">Game Seach</NavLink>
              </NavItem>
            }
          </Nav>
          <Nav className="mr-auto" navbar>
            {isLoggedIn &&
              <NavItem>
                <NavLink tag={RRNavLink} to="/myfriends">Friends List</NavLink>
              </NavItem>
            }
          </Nav>
          <Nav navbar>
            {isLoggedIn &&
              <>
                <NavItem>
                  <a aria-current="page" className="nav-link"
                    style={{ cursor: "pointer" }} onClick={logout}>Logout</a>
                </NavItem>
              </>
            }
            {!isLoggedIn &&
              <>
                <NavItem>
                  <NavLink tag={RRNavLink} to="/login">Login</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={RRNavLink} to="/register">Register</NavLink>
                </NavItem>
              </>
            }
          </Nav>
        </Collapse>
      </Navbar>
    </div>
  );
}
