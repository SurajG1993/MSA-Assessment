﻿var FeedbackReplyModel = (function () {
    /* Only the variables from the return functions can be accessed via other JS. */
    return {
        getReplies: function (callback, postID, row) {
            // Code for API calls goes here
            $.ajax({
                type: "GET",
                dataType: "json",
                url: "http://nandoso-suraj.azurewebsites.net/api/ForumReplies",
                success: function (data) {
                    callback(data, postID, row)
                }
            });
        }
    }
}());

function postReply(callback , postData) {
    $.ajax({
        type: "POST",
        url: "http://nandoso-suraj.azurewebsites.net/api/ForumReplies",
        data: JSON.stringify(postData),
        dataType: "json",
        contentType: 'application/json',
        success: function (data) {
            console.log("postID for callback " + postData.postID);
            callback(postData.postID)
        }
    });
}