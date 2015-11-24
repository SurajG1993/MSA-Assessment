﻿var FeedbackListLength = 0;
document.addEventListener("DOMContentLoaded", function () {
    console.log("DOM loaded and to go !");
    getFeedback();
});

function submitFeedback() {
    var postData = {
        "userName":"Suraj",
        "post":document.getElementById("FeedbackText").value
    }
    postFeedback(getFeedback, postData);
}

function getFeedback() {
    FeedbackModel.getFeedback(setupFeedbackTable)
}

function setupFeedbackTable(FeedbackList) {
    var MenuTable = document.getElementById("FeedBackList");
    MenuTable.innerHTML = null;
    FeedbackListLength = FeedbackList.length - 1;
    console.log("FBL : " + FeedbackListLength)
    for (i = FeedbackListLength; i >= 0; i--) {
        var row = document.createElement("tr");

        var userNameCol = document.createElement("td");
        userNameCol.innerHTML = FeedbackList[i].userName;
        row.appendChild(userNameCol);

        var postCol = document.createElement("td");
        postCol.innerHTML = FeedbackList[i].post;
        row.appendChild(postCol);

        var viewRepliesCol = document.createElement("button");
        viewRepliesCol.innerHTML = "Hello"
        viewRepliesCol.setAttribute("id", FeedbackList[i].id);
        viewRepliesCol.setAttribute("onclick", "storeFeedBackPost(this.id)")
        row.appendChild(viewRepliesCol);
        MenuTable.appendChild(row);
    }
}

function storeFeedBackPost(buttonID) {
    console.log(buttonID);
    if (typeof (Storage) !== "undefined") {
        var reply = document.getElementById("FeedBackList");
        if (FeedbackListLength + 1 == buttonID) {
            sessionStorage.setItem("UserName", reply.rows[0].cells[0].innerHTML);
            sessionStorage.setItem("Message", reply.rows[0].cells[1].innerHTML);
            sessionStorage.setItem("postID", buttonID);
            window.location.href = "replies.html";
        } else {
            sessionStorage.setItem("UserName", reply.rows[buttonID].cells[0].innerHTML);
            sessionStorage.setItem("Message", reply.rows[buttonID].cells[0].innerHTML);
            sessionStorage.setItem("postID", buttonID);
            window.location.href = "replies.html";
        }

    } else {
        document.getElementById("result").innerHTML = "Sorry, your browser does not support web storage...";
    }
}