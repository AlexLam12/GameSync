import React, { useEffect, useState } from 'react';
import FriendCard from './FriendCard';
import { getFriends } from '../modules/friendManager';

const FriendList = () => {
  const [ friends, setFriends ] = useState([]);

  useEffect(() => {
    getFriends().then(friends => setFriends(friends));
  }, []);

  return (
    <>
      <h1>Friend List</h1>
      <div className="friend-list">
        {friends.map(friend =>
          <FriendCard
            key={friend.id}
            friend={friend}
            allowEdit={true} />
        )}
      </div>
    </>
  );
}