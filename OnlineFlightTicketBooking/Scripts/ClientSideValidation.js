function validateEmail() {
    var pattern = "\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
    var email = document.getElementById("EmailId").value;
    if (!email.match(pattern)) {
        email.innerHTML = "<span style='color: red;'>Invalid EmailId</span>";
    }
    else {
        email.innerHTML = "";
    }
}

function validateUserName() {
    var pattern = "^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))+$";
    var name = document.getElementById("Name").value;
    if (!name.match(pattern)) {
        name.innerHTML = "<span style='color: red;'>Invalid UserName</span>";
    }
    else {
        name.innerHTML = "";
    }
}

function validateMobileNumber() {
    var number = document.getElementById("PhoneNumber").value;
    if (!number.match("^[789]+[0-9]{9}$")) {
        number.innerHTML = "<span style='color: red;'>Invalid Mobile Number</span>";
    }
    else {
        number.innerHTML = "";
    }
}
function validatePassword() {
    var pattern = "^.* (?=.{ 8, })(?=.*\d) (?=.* [a - z])(?=.* [A - Z])(?=.* [!*@#$ %^&+=]).* $";
    var number = document.getElementById("Password").value;
    if (!number.match(pattern)) {
        password.innerHTML = "<span style='color: red;'>Invalid Password<br>" +
            "At least one lower case letter,<br>" +
            "At least one upper case letter,<br>" +
            "At least one number,<br>At least 8 characters length</span > ";
    }
    else {
        password.innerHTML = "";
    }
}

function validateConfirmPassword() {
    var password = document.getElementById("Password").value;
    var confirmPassword = document.getElementById("ConfirmPassword").value;
    if (password != confirmPassword) {
        confirmpassword.innerHTML = "<span style='color: red;'>Password doesn't Matched</span>";
    }
    else {
        confirmpassword.innerHTML = "";
    }
}