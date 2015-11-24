document.addEventListener("DOMContentLoaded", function () {
    console.log("DOM loaded and to go !");
    getReplies(sessionStorage.getItem("postID"));
});

function submitReply() {
    var postData = {
        "userName":"Suraj",
        "post":document.getElementById("FeedbackText").value
    }
    postFeedback(getFeedback, postData);
}

function getReplies(postID) {
    FeedbackReplyModel.getFeedback(setupFeedbackReplyTable, postID);
}

function setupFeedbackReplyTable(ReplyList, postID) {
    var MenuTable = document.getElementById("ReplyList");
    for (i = ReplyList.length - 1; i >= 0; i--) {
        if (postID == ReplyList[i].postID) {
            var row = document.createElement("tr");

            var userNameCol = document.createElement("td");
            userNameCol.innerHTML = ReplyList[i].userName;
            row.appendChild(userNameCol);

            var replyCol = document.createElement("td");
            replyCol.innerHTML = ReplyList[i].reply;
            row.appendChild(replyCol);
            MenuTable.appendChild(row);
        }
    }
}

