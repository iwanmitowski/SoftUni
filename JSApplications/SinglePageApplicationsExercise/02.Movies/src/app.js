import { homePage } from './home.js'
import { loginPage } from './login.js'
import { updateNav } from './utils.js';
import { registerPage } from './register.js';
import { createPage } from './create.js';

const routes = {
    '/': homePage,
    '/login': loginPage,
    '/logout': logout,
    '/register': registerPage,
    '/create': createPage,
}

document.querySelector('nav').addEventListener('click', onNavigate);
document.querySelector('#add-movie-button a').addEventListener('click', onNavigate);

function onNavigate(e){
    if (e.target.tagName == 'A' && e.target.href) {
        e.preventDefault();

        let url = new URL(e.target.href);
        console.log(url);
        let view = routes[url.pathname];
        console.log(url.pathname);
        if (typeof view == 'function') {
            view();
        }
    }
}

async function logout(){
    let user = JSON.parse(localStorage.getItem('user'));
    let res;
    
    if (user) {
        res = await fetch('http://localhost:3030/users/logout', {
        headers: {
            'X-Authorization': user.accessToken
        }});
    console.log(res);
    if (res.ok) {
        localStorage.removeItem('user');
        updateNav();   
    } 
}}

updateNav();
homePage();