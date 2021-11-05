import React, { useState } from 'react';
import { useHistory } from "react-router";
import { Card, CardBody, CardImg, CardText, CardTitle, CardSubtitle, Button } from "reactstrap";
import { addUserFriend } from '../../modules/friendManager';



export const FriendCard = (props) => {
    const history = useHistory()

    const handleSave = (event) => {
        event.preventDefault()
        addUserFriend(props.friend.id)
        .then(() => history.push("/myfriends"))
    };

    return(
            <dl className="friend-card">
                <dd className="friends-card__title">
                    <CardTitle> {props.friend.userName} </CardTitle>
                </dd>
                <dd>
                    <Button onClick={handleSave}>Add</Button>
                </dd>
            </dl>
        
    )
}