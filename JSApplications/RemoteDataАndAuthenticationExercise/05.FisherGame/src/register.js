const form = document.getElementById('register-form');

const baseUrl = `http://localhost:3030/users/register`;

const anchors = document.getElementsByTagName('a');

const userSpanElement = document.getElementById('user-span');
const divGuestElement = document.getElementById('guest');
const logoutAnchor = document.getElementById('logout');

form.addEventListener('submit', async (ev) => {

    ev.preventDefault();

    const formData = new FormData(form);

    if (formData.get('rePass') !== formData.get('password')) {

        alert('Password and Password Repeat don\'t match');
        return;

    }

    const data = { 
        email: formData.get('email'),
        password: formData.get('password') 
    };

    fetch(baseUrl, {
        method: 'POST',
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(data)

    })
    .then(res=>{
        if (res.ok) {
            return res.json();
        }
    })
    .then(data =>{
        let username = data.email.split('@');
        let registeredUserObject = {
            email: registerResult.email,
            username: username[0][0].toUpperCase() + username[0].slice(1),
            accessToken: registerResult.accessToken,
            _id: registerResult._id
        };

        sessionStorage.setItem('user', JSON.stringify(registeredUserObject));

        location.href = 'index.html';
    })
    .finally(()=>{
        form.reset();
    })

})

window.onload = () => {

    Array.from(anchors).forEach(a => a.classList.remove('active'));

    document.getElementById('register').classList.add('active');

    if (sessionStorage.user) {

        const userObject = JSON.parse(sessionStorage.user);

        userSpanElement.textContent = userObject.username;
        divGuestElement.classList.add('hide-navigation');
        logoutAnchor.classList.remove('hide-navigation');

    } else {

        divGuestElement.classList.remove('hide-navigation');
        userSpanElement.textContent = 'guest';
        logoutAnchor.classList.add('hide-navigation');

    }

}