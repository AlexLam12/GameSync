import React, { useState } from 'react';
import { useHistory } from "react-router";
import { Card, CardBody, CardImg, CardText, CardTitle, CardSubtitle, Button } from "reactstrap";
import { addUserFriend } from '../../modules/friendManager';



export const FriendCard = (props) => {
    const history = useHistory()

    const handleSave = (event) => {
        event.preventDefault()
        addUserFriend(props.friend.id)
        .then(history.push("/myfriends"))
    };

    return(
        <Card>
            <div className={"friend-card"}>
                <span className="friends-card__title">
                    <CardTitle> {props.friend.userName} </CardTitle>
                </span>
                <Button onClick={handleSave}>Add</Button>
            </div>
        </Card>
    )
}