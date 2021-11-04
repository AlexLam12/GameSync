import React, { useEffect, useState } from "react";
import { useHistory, useParams } from "react-router";
import { Card, CardBody, Button } from "reactstrap";
import { deleteComment, getCommentById } from "../../modules/commentManager";
import { getUserGameById } from "../../modules/gameManager.js";

const Comment = ( {comment, onDelete} ) => {

    const history = useHistory();
    const {id} = useParams();


    const deleteSelectedComment = () => {
        const confirmDelete = window.confirm(
            "Are you sure you would like to delete this comment?"
            );
        if (confirmDelete) {
            deleteComment(comment.id)
            .then(onDelete)
        };
    }

if (!comment) {
    return null;
}

return (
        <Card >
            <CardBody>
                <div>
                <p className="text-left px-4">
                    -{comment.content}
                </p>
                </div>
            </CardBody>
            <Button className="btns" 
            onClick={() => {
                history.push(`/comments/edit/${id}/${comment.id}`)
			        }}>
                        Edit</Button>
        <Button onClick={deleteSelectedComment}>
            Delete
            </Button>
        </Card>
    )
};
export default Comment;