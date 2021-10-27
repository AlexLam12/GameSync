import { getToken } from "./authManager";

const apiUrl = "/api/userGame";

export const addUserGame = (userGameId) => {
    return getToken().then((token) => {
      return fetch(apiUrl, {
        method: "POST",
        headers: {
          Authorization: `Bearer ${token}`,
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
            Game_id: userGameId,
            UserProfile_id: 0 
        })
      })
    });
  };

  export const deleteUserGame = (id) => {
    return getToken().then((token) => {
      return fetch(`${apiUrl}/${id}`, {
        method: "DELETE",
        headers: {
          Authorization: `Bearer ${token}`,
          "Content-Type": "application/json"
        },
        body: JSON.stringify(id)
      })
    });
  };