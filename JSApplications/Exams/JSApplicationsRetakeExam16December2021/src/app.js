import { render } from "../node_modules/lit-html/lit-html.js";

import page from '../node_modules/page/page.mjs'
import { logout } from "./api/users.js";
import { createPage } from "./create.js";
import { detailsPage } from "./details.js";
import { editPage } from "./edit.js";
import { homePage } from "./home.js";
import { loginPage } from "./login.js";
import { profilePage } from "./profile.js";
import { registerPage } from "./register.js";

const root = document.querySelector('#content');

document.getElementById('logoutBtn').addEventListener('click', logouting);

page(decorateContext);
page('/', homePage);
page('/login', loginPage);
page('/register', registerPage);
page('/create', createPage);
page('/details/:id', detailsPage);
page('/edit/:id', editPage);
page('/profile', profilePage);
updateNav();
page.start();

function decorateContext(ctx, next){
    ctx.render = (content) => render(content, root);
    ctx.updateNav = updateNav;

    next();
}

function logouting(e){
    e.preventDefault();
    logout();
    updateNav();
    page.redirect('/');
}

function updateNav() {
    let user = JSON.parse(localStorage.getItem('user'));

    if (user) {
        document.querySelectorAll('#user').forEach(e => e.style.display = 'block');
        document.querySelectorAll('#guest').forEach(e => e.style.display = 'none');
        console.log(user.email);
        // document.getElementById('email').textContent = `Welcome, ${user.email}`;
    }
    else{
        document.querySelectorAll('#user').forEach(e => e.style.display = 'none');
        document.querySelectorAll('#guest').forEach(e => e.style.display = 'block');
    }
}