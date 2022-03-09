const loginForm = document.getElementById('login-form');
const anchors = document.getElementsByTagName('a');

const userSpanElement = document.getElementById('user-span');
const divGuestElement = document.getElementById('guest');
const logoutAnchor = document.getElementById('logout');

logoutAnchor.addEventListener('click', async () => {

    const baseUrl = `http://localhost:3030/users/logout`;

    await fetch(baseUrl)
    .then(res =>{
        if (res.ok) {
            sessionStorage.clear();
            location.href = `index.html`;
        }
    })
})

loginForm.addEventListener('submit', async (ev) => {

    ev.preventDefault();

    const baseUrl = `http://localhost:3030/users/login`;

    const formData = new FormData(loginForm);

    const data = {
        email: formData.get('email'),
        password: formData.get('password') 
    };

    await fetch(baseUrl, {
        method: 'POST',
        headers: {
            "Content-type": "application/json"
        },
        body: JSON.stringify(data)
    })
    .then(res =>{
        if (res.ok) {
            location.href = `index.html`;
            return;    
        }
    })
    .catch(err =>{
        alert('Invalid email or password');
    })
    .finally(()=>{
        sessionStorage.setItem('user', JSON.stringify(loginResult));
        loginForm.reset();
    });
    
});

window.onload = () => {

    Array.from(anchors).forEach(a => a.classList.remove('active'));

    document.getElementById('login').classList.add('active');

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
