import React, { useState } from 'react';
import { useHistory } from "react-router";
import { Link } from 'react-router-dom';
import { Card, CardBody, CardImg, CardText, CardTitle, CardSubtitle, Button } from "reactstrap";
import "./Game.css"
import { addUserGame } from '../../modules/userGameManager';



export const GameCard = (props) => {
    const history = useHistory()

    const handleSave = (event) => {
        event.preventDefault()
        addUserGame(props.game.id)
        .then(history.push("/mygames"))
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
                <Button onClick={handleSave}>Add</Button>
            </div>
        </Card>
    )
}