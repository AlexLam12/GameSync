import React, { useState } from "react";
import { Button, Form, FormGroup, Label, Input } from "reactstrap";
import { useHistory, Link } from "react-router-dom";
import { login } from "../modules/authManager";
// import logo from "./quill-logo.png";

export default function Login() {
  const history = useHistory();

  const [email, setEmail] = useState();
  const [password, setPassword] = useState();

  const loginSubmit = (e) => {
    e.preventDefault();
    login(email, password)
      .then(() => history.push("/"))
      .catch(() => alert("Invalid email or password"));
  };

  return (
    <>
      <div className="center">
        <Form className="login-container" onSubmit={loginSubmit}>
          <FormGroup>
            {/* <img src={logo} alt="logo" className="login-logo" /> */}
          </FormGroup>
          <fieldset>
            <FormGroup>
              {/* <Label for="email">Email</Label> */}
              <Input
                id="email"
                type="text"
                placeholder="Email"
                autoFocus
                onChange={(e) => setEmail(e.target.value)}
              />
            </FormGroup>
            <FormGroup>
              {/* <Label for="password">Password</Label> */}
              <Input
                id="password"
                type="password"
                placeholder="Password"
                onChange={(e) => setPassword(e.target.value)}
              />
            </FormGroup>
            <FormGroup>
              <Button className="login-button">Login</Button>
            </FormGroup>
            <em>
              Not registered? <Link to="register">Register</Link>
            </em>
          </fieldset>
        </Form>
      </div>
    </>
  );
}