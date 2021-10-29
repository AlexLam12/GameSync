import React, { useEffect, useState } from "react";
import { useHistory, useParams } from "react-router";
import { Card, CardBody } from "reactstrap";
import { deleteComment, getCommentById } from "../../modules/commentManager";

const Comment = ( {comment} ) => {

    const history = useHistory();
    const { userGameId } = useParams();
    // const [ com, setComment ] = useState();

    // const deleteSelectedComment = (event) => {
    //     event.preventDefault()
    //     const confirmDelete = window.confirm("Are you sure you would like to delete the comment?")
    //     if (confirmDelete) {
    //         deleteComment(comment.id).then(() => {history.push(`/userGames/detail/${userGameId}`)})
    //     };
    // }

if (!comment) {
    return null;
}

return (
        <Card >
            <CardBody>
                <p className="text-center px-4">
                    {"Your Comments"}
                </p>
                <div>
                <p className="text-left px-4">
                    -{comment.content}
                </p>
                </div>
            </CardBody>
            <button className="btns" 
            // onClick={() => {
            //     history.push(`/comments/edit/${comment.id}`)
			//         }}
                    >Edit</button>
        <button 
        // onClick={deleteSelectedComment}
        >Delete</button>
        </Card>
    )
};
export default Comment;