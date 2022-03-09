import * as catchesUtility from "./catches-module.js";

const userSpanElement = document.getElementById('user-span');
const divGuestElement = document.getElementById('guest');
const logoutAnchor = document.getElementById('logout');
const anchors = document.getElementsByTagName('a');

const buttonLoadElement = document.getElementsByClassName('load')[0];
buttonLoadElement.addEventListener('click', catchesUtility.loadCatches);

const addForm = document.getElementById('add-form');
addForm.addEventListener('submit', catchesUtility.addCatch);

logoutAnchor.addEventListener('click', async () => {

    const baseUrl = `http://localhost:3030/users/logout`;

    const userObject = JSON.parse(sessionStorage.user);

    await fetch(baseUrl, {
        headers: {
            "X-Authorization": userObject.accessToken
        }
    })
    .then(res =>{
        if (res.ok) {
            sessionStorage.clear();
            location.href = `index.html`;
        }
    });
})

window.onload = () => {

    Array.from(anchors).forEach(a => a.classList.remove('active'));

    document.getElementById('home').classList.add('active');

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

    catchesUtility.enableAddButton();
}