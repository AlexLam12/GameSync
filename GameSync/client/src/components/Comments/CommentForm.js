import React, {useEffect, useState } from "react";
import { useHistory, useParams } from "react-router-dom";
import { addComment, getCommentById, updateComment } from "../../modules/commentManager.js";

export const CommentForm = () => {
    
    const [ comment, setComment ] = useState({});
    useEffect(() => {
        if(commentId){
            getCommentById(commentId)
            .then(setComment())
        }
    }, []);
    const history = useHistory();
    const { commentId, userGameId } = useParams();
    

    const handleControlledInputChange = (event) => {
        const newComment = { ...comment }
        newComment[event.target.id] = event.target.value
        setComment(newComment)
    }

    const handleClickSaveComment = () => {
        
        if (comment.content === "") {
            window.alert("Please complete the comment form.")
        } else if (commentId) {
            updateComment({
                id: commentId,
                content: comment.content
            })
            .then(() => history.push(`/userGame/detail/${userGameId}`))
        } else {
            const newComment = {
                userGame_id: userGameId,
                content: comment.content
            }
            addComment(newComment)
            .then(() => history.push(`/userGame/detail/${userGameId}`))
        }
    }

        return(
            <>
             <form className="commentForm">
            <h2 className="commentForm__subject comment_header">{commentId ? "Update Comment" : "New Comment"}</h2>
            <fieldset>
                <div className="form-group">
                    <label htmlFor="content">Comment:</label>
                    <input type="text" id="content" required autoFocus className="form-control" placeholder="Content" value={comment?.content} onChange={handleControlledInputChange} />
                </div>
            </fieldset>
            <div className="buttons"><button className="btns" onClick={
                (event) => {
                    event.preventDefault()
                    handleClickSaveComment()
                }
            }>
            SAVE COMMENT
            </button> </div>
        </form>    
            </>
        )
}

export default CommentForm;