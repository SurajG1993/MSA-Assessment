var SpecialModel = (function () {
    /* Only the variables from the return functions can be accessed via other JS. */
    return {
        getSpecial: function (callback) {
            // Code for API calls goes here
            console.log("this was called from student module");

            $.ajax({
                type: "GET",
                dataType: "json",
                url: "http://nandoso-suraj.azurewebsites.net/api/SpecialModels",
                success: function (data) {
                    callback(data);
                }
            });
        }
    }
}());