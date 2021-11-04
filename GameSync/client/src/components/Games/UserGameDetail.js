import React, { useEffect, useState } from "react";
import { useParams, useHistory } from "react-router-dom";
import { getUserGameById } from "../../modules/gameManager.js";
import CommentList from "../Comments/CommentList.js";

export const UserGameDetail = () => {
    const { id } = useParams();
    const [userGame, setUserGame] = useState({});

  useEffect(() => {
    getUserGameById(id).then(setUserGame);
  }, []);

  return (
    <div className="container">
      <center>
        <img src={userGame.game?.imageLocation} alt={userGame.game?.title} />
          <h2>{userGame.game?.title}</h2>
        <div>
        <CommentList />
      </div>
      </center>      
    </div>
  );
};

export default UserGameDetail;
