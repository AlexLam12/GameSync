import { getToken } from "./authManager";

const apiUrl = '/api/friend';

export const getFriends = () => {
    return getToken().then((token) => {
        return fetch(apiUrl, {
          method: "GET",
          headers: {
            Authorization: `Bearer ${token}`,
            "Content-Type": "application/json",
          }
        }).then(resp => resp.json());
    });  
};


export const getMyFriends = () => {
    return getToken().then((token) => {
        return fetch(`${apiUrl}/myFriends`, {
          method: "GET",
          headers: {
            Authorization: `Bearer ${token}`,
            "Content-Type": "application/json",
          }
        }).then(resp => resp.json());
    });  
};

export const searchFriends = (criterion) => {
    return getToken().then((token) => {
        return fetch(`${apiUrl}/search?q=${criterion}`, {
          method: "GET",
          headers: {
            Authorization: `Bearer ${token}`,
            "Content-Type": "application/json",
          }
        }).then(resp => resp.json());
    });
};
export const getUserFriendById = (id) => {
    return getToken().then((token) => {  
      return fetch(`${apiUrl}/${id}`, {
        method: "GET",
        headers: {
          Authorization: `Bearer ${token}`
        }
      }).then(resp => resp.json());
    });
  };

  export const addUserFriend = (userFriendId) => {
    return getToken().then((token) => {
      return fetch(apiUrl, {
        method: "POST",
        headers: {
          Authorization: `Bearer ${token}`,
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
            Friend_id: userProfileId,
            UserProfile_id: 0 
        })
      })
    });
  };

  export const deleteUserFriend = (id) => {
    return getToken().then((token) => {
      return fetch(`${apiUrl}/${id}`, {
        method: "DELETE",
        headers: {
          Authorization: `Bearer ${token}`,
          "Content-Type": "application/json"
        }
      })
    });
  };
