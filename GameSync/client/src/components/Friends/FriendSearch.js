import React, { useEffect, useState } from 'react';
import FriendCard from './FriendCard';
import { searchFriends } from '../modules/friendManager';

const FriendSearch = () => {
  const [ friends, setFriends ] = useState([]);
  const [ criterion, setCriterion ] = useState("");

  const doSearchFriends = (criterion) => {
    searchFriends(criterion)
      .then((friends) => setFriends(friends));
  };

  useEffect(() => {
    doSearchFriends(criterion);
  }, []);

  return (
    <>
      <h1>Friend Search</h1>
      <div className="friend-search__form">
        <input id="search" value={criterion} onChange={e => setCriterion(e.target.value)}/>
        <button onClick={() => doSearchFriends(criterion)}>Search</button>
      </div>
      <div className="friend-list">
        {friends.map(friend =>
          <FriendCard 
            key={friend.id}
            friend={friend}
            allowEdit={false} />
        )}
      </div>
    </>
  );
}