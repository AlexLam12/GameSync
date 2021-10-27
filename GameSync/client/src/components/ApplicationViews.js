import React from "react";
import { Switch, Route, Redirect } from "react-router-dom";
import Login from "./Login";
import Register from "./Register";
import Hello from "./Hello";
import { GameList } from "./Games/GameList";
import GameSearch from "./Games/GameSearch";


export default function ApplicationViews({ isLoggedIn }) {

  return (
    <main>
      <Switch>
        <Route path="/" exact>
          {isLoggedIn ? <Hello /> : <Redirect to="/login" />}
        </Route>

        <Route path="/mygames">
        {isLoggedIn ? <GameList /> : <Redirect to="/login" />}
        </Route>

        <Route path="/search">
        {isLoggedIn ? <GameSearch /> : <Redirect to="/login" />}
        </Route>



        <Route path="/login">
          <Login />
        </Route>



        <Route path="/register">
          <Register />
        </Route>
      </Switch>
    </main>
  );
};