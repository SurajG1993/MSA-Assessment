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
    for (i = FeedbackList.length-1;i >= 0; i--) {
        var row = document.createElement("tr");

        var userNameCol = document.createElement("td");
        userNameCol.innerHTML = FeedbackList[i].userName;
        row.appendChild(userNameCol);

        var postCol = document.createElement("td");
        postCol.innerHTML = FeedbackList[i].post;
        row.appendChild(postCol);
        getReplies(FeedbackList[i].id,row);
        MenuTable.appendChild(row);
    }
}