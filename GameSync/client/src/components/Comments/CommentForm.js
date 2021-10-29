import React, {useEffect, useState } from "react";
import { useHistory, useParams } from "react-router-dom";
import { addComment, getCommentById } from "../../modules/commentManager.js";
import { getGameById } from "../../modules/gameManager.js";

const CommentForm = (props) => {
    const [comment, setComment] = useState({
        content: "",
        Game_id: 0
    });

    const [ game, setGame ] = useState({});

    const history = useHistory();
    const { id } = useParams();
    

    const handleControlledInputChange = (event) => {
        const newComment = { ...comment }
        newComment[event.target.id] = event.target.value
        setComment(newComment)
        }

        const handleClickSaveComment = () => {
            
            if (comment.subject === "" || comment.content === "") {
                window.alert("Please complete the comment form.")
            } else {
                const newComment = {
                    game_id: props.game.id,
                    content: comment.content
                }
                addComment(newComment)
                .then(() => history.push(`/posts/detail/${props.game.id}`))
            }
        }

        useEffect(() => {
            getGameById(id).then(resp => setGame(resp));
        }, []);

        return(
            <>
             <form className="commentForm">
            <h2 className="commentForm__subject comment_header">New Comment</h2>
            <fieldset>
                <div className="form-group">
                    <label htmlFor="content">Comment:</label>
                    <input type="text" id="content" required autoFocus className="form-control" placeholder="Content" value={comment.content} onChange={handleControlledInputChange} />
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