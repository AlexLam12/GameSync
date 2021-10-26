import { getToken } from "./authManager";

const apiUrl = "/api/userGame";

export const addUserGame = (userGame) => {
    return getToken().then((token) => {
      return fetch(apiUrl, {
        method: "POST",
        headers: {
          Authorization: `Bearer ${token}`,
          "Content-Type": "application/json",
        },
        body: JSON.stringify(userGame),
      })
    });
  };

  export const deleteUserGame = (id) => {
    return getToken().then((token) => {
      return fetch(`${baseUrl}/${id}`, {
        method: "DELETE",
        headers: {
          Authorization: `Bearer ${token}`,
          "Content-Type": "application/json"
        },
        body: JSON.stringify(id)
      })
    });
  };