


var IdCount = 100;

const register = async () => {


    try {
        //Use const
        var userName = document.getElementById("userName").value

        var password = document.getElementById("password").value
        var firstName = document.getElementById("firstName").value
        var lastName = document.getElementById("lastName").value
        var User = { userName, password, firstName, lastName }
        //const user = { UserName:userName, Password:password, FirstName:firstName, LastName:lastName }, Prefix -UpperCase


        const res = await fetch('api/users', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(User)

        });
       //Check response status code- if response is ok..., if not alert a suitable message...
        const dataPost = await res.json();
        alert(dataPost)
    }
    catch (er) {
        //Alerting errors to the user is not recommended, log them to the console.
        alert(er)
    }


}


const checkLength = () => {
    //const
    var userName = document.getElementById("userName").value
    if (userName.length > 10) {
        //too
        alert("to long")
    }
} 

var users;



const checkPassword = async () => {
    var res;
    var strength = {
        0: "Worst",
        1: "Bad",
        2: "Weak",
        3: "Good",
        4: "Strong"
    }
    var password = document.getElementById("password").value;
    var meter = document.getElementById('password-strength-meter');
    var text = document.getElementById('password-strength-text');
    await fetch('api/Users/check',
        {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(password)

        })
        //await! instead of .then
        .then(r => r.json())
        .then(data => res = data)


    if (res <= 2)
        /* alert("your password is weak!! try again")*/
        meter.value = res;

    // Update the password strength meter
    meter.value = res;

    // Update the text indicator
 
    if (password !== "") {
        text.innerHTML = "Strength: " + strength[res];
    } else {
        text.innerHTML = "";
    }
}




const login = async () => {
    try {
        //Use const...
        var userName2 = document.getElementById("userName2").value
        var password2 = document.getElementById("password2").value
        //Use `` for js strings with variables ex:userName=`${userNameLogin}`
        var url = 'api/users' + "?" + "userName=" + userName2 + "&password=" + password2;
        const res = await fetch(url,);
        console.log(res)
        if (!res.ok) {
            throw new Error("eror!!!")
            //Alert: userName or password incorrect try again....
        }
        else {
            var data = await res.json() 
            sessionStorage.setItem("user", JSON.stringify(data))
            alert("you loged in")
            window.location.href = "./newPage.html"
   
        }
    }
    catch (er) {
        alert(er.message)
    }
   
 
    }



