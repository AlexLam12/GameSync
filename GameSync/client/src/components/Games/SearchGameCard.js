import React, { useState } from 'react';
import { useHistory } from "react-router";
import { Card, CardBody, CardImg, CardText, CardTitle, CardSubtitle, Button, ListGroup, ListGroupItem } from "reactstrap";
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
    <Card className={"game-card"} style={{width:'18rem'}}>
        <CardImg variant="top" src={props.game.imageLocation} alt={props.game.title}/>
        <CardBody className="games-card__title">
            <CardTitle> {props.game.title} </CardTitle>
        </CardBody>
        <ListGroup className="list-group-flish">
            <ListGroupItem><Button onClick={handleSave} className="add-button">Add</Button></ListGroupItem>
        </ListGroup>
    </Card>
    )
}