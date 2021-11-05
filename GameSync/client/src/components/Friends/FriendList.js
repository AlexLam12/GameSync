import React, { useEffect, useState } from 'react';
import { useHistory } from 'react-router';
import { FriendCard } from './FriendCard';
import { getMyFriends } from '../../modules/friendManager';
import { Button } from 'reactstrap';
import "./Friend.css"

export const FriendList = () => {
  const history = useHistory()
  const [ friends, setFriends ] = useState([]);

  useEffect(() => {
    getMyFriends().then(setFriends);
  }, []);
  const onClick = () => {
    history.push("/searchfriend")
  }
  const onDelete = () => {
    getMyFriends().then(setFriends)
  }

  return (
    <>
      <h1>Friend List</h1>
      <Button onClick={onClick}>Add a Friend</Button>
      <div className="friend-list">
        {friends.map(friend =>
          <FriendCard
            key={friend.id}
            friend={friend}
            onDelete={onDelete} />
        )}
      </div>
      <div className='click-button'>
        <Button>See what games games you have in common. Click here</Button>
      </div>  
    </>
  );
}