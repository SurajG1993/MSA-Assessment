var MenuModel = (function () {
    /* Only the variables from the return functions can be accessed via other JS. */
    return {
        getMenu: function (callback) {
            // Code for API calls goes here
            console.log("this was called from student module");

            $.ajax({
                type: "GET",
                dataType: "json",
                url: "http://localhost:2480/api/MenuModels",
                success: function (data) {
                    callback(data);
                }
            });
        }
    }
}());