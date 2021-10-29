import React, { useEffect, useState,} from "react";
import { useParams, useHistory } from "react-router-dom";
import { getAllComments, getAllCommentsOnUserGame } from "../../modules/commentManager.js";
import Comment from './Comment.js'


export const CommentList = () => {
  const [comments, setComments] = useState([]);

  const history = useHistory();

  const { id } = useParams();
  const getComments = (id) => {
    getAllCommentsOnUserGame(id).then(comments => setComments(comments));
  };

  useEffect(() => {
    getComments(id)
  }, []);

  return (
    <>
    <div className="container">
      <div className="row justify-content-center">
        {comments.map((comment) => (
          <Comment comment={comment} key={comment.id} />
        ))}
      </div>
    </div>
    <div>
    <button className="btns" 
        // onClick={() => {
        //         history.push(`/comments/create/${id}`)
		// 	        }}
                    >Create New Comment</button>
    </div>
    </>
  );
};

export default CommentList;