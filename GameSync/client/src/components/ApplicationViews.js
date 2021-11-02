import React from "react";
import { Switch, Route, Redirect } from "react-router-dom";
import Login from "./Login";
import Register from "./Register";
import Hello from "./Hello";
import { GameList } from "./Games/GameList";
import { UserGameDetail } from "./Games/UserGameDetail";
import GameSearch from "./Games/GameSearch";
import { CommentForm } from "./Comments/CommentForm";


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

        <Route path="/userGame/detail/:id">
        {isLoggedIn ? <UserGameDetail /> : <Redirect to="/login" />}
        </Route>

        <Route path="/comments/create/:id" >
        {isLoggedIn ? <CommentForm /> : <Redirect to="/login" />}
        </Route>

        <Route path="/comments/edit/:userGameId/:commentId" exact>
          {isLoggedIn ? <CommentForm /> : <Redirect to="/login" />}
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