function submitReply() {
    var postData = {
        "userName":"Suraj",
        "post":document.getElementById("FeedbackText").value
    }
    postFeedback(getFeedback, postData);
}

function getReplies(postID,row) {
    FeedbackReplyModel.getFeedback(setupFeedbackReplyTable, postID,row);
}

function setupFeedbackReplyTable(ReplyList, postID,row) {
 //   var MenuTable = document.getElementById("FeedBackList");
    for (i = ReplyList.length - 1; i >= 0; i--) {
        if (postID == ReplyList[i].postID) {
            var ReplyCol = document.createElement("td");
            ReplyCol.innerHTML = ReplyList[i].userName + ":   " + ReplyList[i].reply;
            row.appendChild(ReplyCol);
        }
    }
}