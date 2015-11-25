var FeedbackModel = (function () {
    var postData = {
        "userName": "YOLO",
        "post": "success",
    }
    /* Only the variables from the return functions can be accessed via other JS. */
    return {
        getFeedback: function (callback) {
            // Code for API calls goes here
            $.ajax({
                type: "GET",
                dataType: "json",
                url: "http://nandoso-suraj.azurewebsites.net/api/ForumPosts",
                success: function (data) {
                    callback(data);
                }
            });
        }
    }
}());

function postFeedback(callback , postData) {
    $.ajax({
        type: "POST",
        url: "http://nandoso-suraj.azurewebsites.net/api/ForumPosts",
        data: JSON.stringify(postData),
        dataType: "json",
        contentType: 'application/json',
        success: function (data) {
            callback(data)
        }
    });
}