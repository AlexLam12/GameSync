import React, { useEffect, useState,} from "react";
import { useParams, useHistory } from "react-router-dom";
import { getAllComments, getAllCommentsOnUserGame } from "../../modules/commentManager.js";
import Comment from './Comment.js'
import { Card, CardBody, CardImg, CardText, CardTitle, CardSubtitle, Button } from "reactstrap";


export const CommentList = () => {
  const [comments, setComments] = useState([]);
  const history = useHistory();
  const {id} = useParams();


  useEffect(() => {
    getAllCommentsOnUserGame(id).then(setComments);
  }, []);
  useEffect(() => {
    console.log(comments)
  }, [comments]);

  const onDelete = () => {
    getAllCommentsOnUserGame(id).then(setComments)
  }

  return (
    <>
    <div className="container">
      <div className="comment-list">
        {comments.map((comment) => (
          <Comment 
          comment={comment} 
          key={comment.id} 
          onDelete={onDelete}/>
        ))}
      </div>
    </div>
    <div>
    <Button className="btns" 
        onClick={() => {
                history.push(`/comments/create/${id}`)
			        }}>Create New Comment</Button>
    </div>
    </>
  );
};

export default CommentList;