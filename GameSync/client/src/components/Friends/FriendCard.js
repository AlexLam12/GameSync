import React from 'react';
import {  CardTitle, Button } from "reactstrap";
import { deleteUserFriend } from '../../modules/friendManager';
import "./Friend.css"


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
            <dl className="friend-card">
                <dt className="friends-card__title">
                    <CardTitle> {friend.userProfile.userName} </CardTitle>
                </dt>                
                <dd>
                    <label class="switch">
                    <input type="checkbox"/>
                    <span class="slider round"></span>
                    </label>
                </dd>
                <dd>
                    <Button onClick={handleDelete}>Delete</Button>
                </dd>

            </dl>
        
    )
}