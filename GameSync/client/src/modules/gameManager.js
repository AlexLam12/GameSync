import { getToken } from "./authManager";

const apiUrl = '/api/game';

export const getMyGames = () => {
    return getToken().then((token) => {
        return fetch(`${apiUrl}/myGames`, {
          method: "GET",
          headers: {
            Authorization: `Bearer ${token}`,
            "Content-Type": "application/json",
          }
        }).then(resp => resp.json());
      });  
};

export const searchGames = (criterion) => {
  return fetch(`${apiUrl}search?q=${criterion}`)
    .then(resp => resp.json());
};

// export const getGame = (id) => {
//   return fetch(apiUrl + id).then(resp => resp.json());
// };