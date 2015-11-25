document.addEventListener("DOMContentLoaded", function () {
    console.log("DOM loaded and to go !");
    getReplies(sessionStorage.getItem("postID"));
});

function submitReply() {
    var postData = {
        "userName": getFacebookUserName(),
        "reply": document.getElementById("ReplyText").value,
        "postID": getPostID()
    }
    postReply(getReplies, postData)
}

function getReplies(postID) {
    storePostID(postID)
    console.log("getting replies" + getPostID())
    FeedbackReplyModel.getReplies(setupFeedbackReplyTable, postID);
}

function setupFeedbackReplyTable(ReplyList, postID) {
    var MenuTable = document.getElementById("ReplyList");
    MenuTable.innerHTML = null;
    console.log("populating data " + ReplyList.length);
    console.log("postID : " + postID);
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

function checkValidPost() {
    var TextAreaMessage = document.getElementById("ReplyText").value;
    if (TextAreaMessage.length !== 0 && getFacebookUserName() !== null) {
        submitReply();
    } else {
        alert("Error : Reply is blank")
    }
}

function storePostID(postID) {
    sessionStorage.setItem("postID",postID);
}

function getPostID() {
    return  sessionStorage.getItem("postID");
}