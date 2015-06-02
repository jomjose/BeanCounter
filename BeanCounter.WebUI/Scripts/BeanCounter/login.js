var login = function () {
    loginMethods = {};

    loginMethods.initialize = function () {
        loginMethods.setEvents();
    };

    loginMethods.prepareSignIn = function () {
        $("#blockSignUp,.back-login").addClass("hide");
        $("#blockSignIn,.back-signin").removeClass("hide");
    };
    loginMethods.prepareSignUp = function () {
        $("#blockSignIn,.back-signin").addClass("hide");
        $("#blockSignUp,.back-login").removeClass("hide");
    };
    loginMethods.signUp = function () {

        var profile = loginMethods.getProfileData();
        $.ajax({
            type: "POST",
            url:"Account/SignUp",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(profile),
            success: function (data) {
                data === true ? loginMethods.prepareSignIn() : alert("Something went wrong");
            }
        });

    };

    loginMethods.getProfileData = function () {
        var profile = {};
        profile.UserName = $("#txtUserName").val();
        profile.Password = $("#txtPassword").val();
        profile.FirstName = $("#txtFirstName").val();
        profile.LastName = $("#txtLastName").val();
        profile.Email = $("#txtEmail").val();
        return profile;
    };

    loginMethods.setEvents = function () {
        $("#linkSignUp").on("click", function () {
            loginMethods.prepareSignUp();
        });

        $("#linkSignIn").on("click", function () {
            loginMethods.prepareSignIn();
        });
        $("#formSignUp").on("submit", function (event) {
            event.preventDefault();
            loginMethods.signUp();
        });
    };


    return loginMethods;
}();
$(function () {
    login.initialize();
});