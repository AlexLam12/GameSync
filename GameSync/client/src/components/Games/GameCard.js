import React from 'react';
import { useHistory } from "react-router";
import { Link } from 'react-router-dom';
import { Card, CardBody, CardImg, CardText, CardTitle, CardSubtitle, Button } from "reactstrap";
import "./Game.css";
import { deleteUserGame } from '../../modules/userGameManager';

export const GameCard = (props) => {

    const handleDelete = () => {
        deleteUserGame(props.game.id)
        .then(props.onDelete);
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
                <Button onClick={handleDelete}>Delete</Button>
            </div>
        </Card>
    )
}