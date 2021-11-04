import React from 'react';
import { useHistory } from "react-router";
import { Card, CardBody, CardImg, CardText, CardTitle, CardSubtitle, Button } from "reactstrap";
import "./Game.css";
import { deleteUserGame } from '../../modules/userGameManager';

export const GameCard = (props) => {
    const history = useHistory()

    const handleDelete = () => {
        const confirmDelete = window.confirm(
            "Are you sure you would like to delete this game?"
          );
          if (confirmDelete) {
        deleteUserGame(props.game.id)
        .then(props.onDelete);
        }
      };
      
    return(
        <Card>
            <div className={"game-card"}>
                <span className="games-card__title">
                    <CardTitle> {props.game.title} </CardTitle>
                </span>
                <span className="game-card__image">
                    <CardImg src={props.game.imageLocation} alt={props.game.title}/>
                </span>
                <Button onClick={() => {history.push(`/userGame/detail/${props.game.id}`)}}>View Comments</Button>
                <Button onClick={handleDelete}>Delete</Button>
            </div>
        </Card>
    )
}