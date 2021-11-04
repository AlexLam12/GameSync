import React from 'react';
import { Card, CardBody, CardImg, CardText, CardTitle, CardSubtitle, Button } from "reactstrap";
import { deleteUserFriend } from '../../modules/friendManager';

export const FriendCard = ({friend, onDelete}) => {

    const handleDelete = () => {
        const confirmDelete = window.confirm(
            "Are you sure you would like to delete this friend from your friends list?"
          );
          if (confirmDelete) {
        deleteUserFriend(friend.id)
        .then(onDelete);
        }
      };
      
    return(
        <Card>
            <div className={"friend-card"}>
                <span className="friends-card__title">
                    <CardTitle> {friend.userProfile.userName} </CardTitle>
                </span>
                <Button onClick={handleDelete}>Delete</Button>
            </div>
        </Card>
    )
}