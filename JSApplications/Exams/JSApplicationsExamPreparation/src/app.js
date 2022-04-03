import { render } from "../node_modules/lit-html/lit-html.js";

import page from '../node_modules/page/page.mjs'
import { allPage } from "./all.js";
import { logout } from "./api/users.js";
import { createPage } from "./create.js";
import { detailsPage } from "./details.js";
import { editPage } from "./edit.js";
import { homePage } from "./home.js";
import { loginPage } from "./login.js";
import { myPage } from "./my.js";
import { registerPage } from "./register.js";


const root = document.querySelector('main');
console.log(root);
document.getElementById('logoutBtn').addEventListener('click', logouting);

page(decorateContext);
page('/details/:id', detailsPage);
page('/edit/:id', editPage);
page('/', homePage)
page('/login', loginPage);
page('/register', registerPage);
page('/all', allPage);
page('/my', myPage);
page('/create', createPage);
updateNav();
page.start();

function decorateContext(ctx, next){
    ctx.render = (content) => render(content, root);
    ctx.updateNav = updateNav;

    next();
}

function logouting(){
    logout();
    updateNav();
    page.redirect('/');
}

function updateNav() {
    let user = JSON.parse(localStorage.getItem('user'));

    if (user) {
        document.querySelectorAll('#profile').forEach(e => e.style.display = 'block');
        document.querySelectorAll('#guest').forEach(e => e.style.display = 'none');
        document.getElementById('welcome').textContent = `Welcome ${user.username}`;
    }
    else{
        document.querySelectorAll('#profile').forEach(e => e.style.display = 'none');
        document.querySelectorAll('#guest').forEach(e => e.style.display = 'block');
    }
}