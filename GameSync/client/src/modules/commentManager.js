import { getToken } from "./authManager";
const apiUrl = '/api/comment';

export const getAllComments = () => {
    return fetch(apiUrl)
        .then((res) => res.json())
};

export const getAllCommentsOnUserGame = (id) => {
    return getToken().then((token) => {
      return fetch(`${apiUrl}/getCommentsByUserGameId/${id}`, {
        method: "GET",
        headers: {
          Authorization: `Bearer ${token}`
        }
      }).then((resp) => resp.json())
      });
  };

  export const getCommentById = (id) => {
    return getToken().then((token) => {
    return fetch(`${apiUrl}/${id}`, {
      method: "GET",
      headers: {
        Authorization: `Bearer ${token}`
      }
    }).then((resp) => resp.json())
  });
};

export const addComment = (comment) => {
  return getToken().then((token) => {
    return fetch(apiUrl, {
      method: "POST",
      headers: {
        Authorization: `Bearer ${token}`,
        "Content-Type": "application/json"
      },
      body: JSON.stringify(comment)
    })
  });
};

export const updateComment = (comment) => {
  return getToken().then((token) => {
    return fetch(apiUrl, {
      method: "PUT",
      headers: {
        Authorization: `Bearer ${token}`,
        "Content-Type": "application/json"
      },
      body: JSON.stringify(comment)
    })
  })
}

export const deleteComment = (commentId) => {
  return getToken().then((token) => {
    return fetch(`${apiUrl}/${commentId}`, {
      method: "DELETE",
      headers: {
        Authorization: `Bearer ${token}`,
        "Content-Type": "application/json"
      }
    });
  });
};