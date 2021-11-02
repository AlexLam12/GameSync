import React from 'react';

export const FriendCard = (props) => {
  return (
    <div className="friend-card ">
      <span className="friend-card__name">
        {props.friend.userName}
      </span>
    </div>
  );
};