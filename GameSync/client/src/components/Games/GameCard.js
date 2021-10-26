import React from 'react';
import { Link } from 'react-router-dom';
import { Card, CardBody, CardImg, CardText, CardTitle, CardSubtitle } from "reactstrap";

export const GameCard = (props) => {
    return(
        <div className={"game-card"}>
            <span className="games-card__title">
                {props.game.title}
            </span>
            <span className="game-card__image">
                <img src={props.game.imageLocation} alt={props.game.title}/>
            </span>
        </div>
    )
}