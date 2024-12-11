function Validate() {
    const password = document.getElementById("password");
    const cpassword = document.getElementById("cpassword");

    if (password.value !== cpassword.value) {
        password.style.borderColor("Red");
        cpassword.style.borderColor("Red");
        console.log("KO");
    } else {
        console.log("OK");
    }
};