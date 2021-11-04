import React from 'react';
import { useHistory } from "react-router";
import { Card, CardBody, CardImg, CardText, CardTitle, CardSubtitle, Button, ListGroup, ListGroupItem } from "reactstrap";
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
        <Card className={"game-card"} style={{width:'18rem'}}>
                    <CardImg variant="top" src={props.game.imageLocation} alt={props.game.title}/>
                <CardBody className="games-card__title">
                    <CardTitle> {props.game.title} </CardTitle>
                </CardBody>
        <ListGroup className="list-group-flish">
            <ListGroupItem><Button onClick={() => {history.push(`/userGame/detail/${props.game.id}`)}}>View Comments</Button></ListGroupItem>
            <ListGroupItem><Button onClick={handleDelete}>Delete</Button></ListGroupItem>
        </ListGroup>
        </Card>
    )
}