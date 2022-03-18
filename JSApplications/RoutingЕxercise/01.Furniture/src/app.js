import { render } from "../../node_modules/lit-html/lit-html.js";

import page from '../../node_modules/page/page.mjs'
import { logout } from "./api/users.js";
import { homePage } from './home.js'
import { loginPage } from "./login.js";
import { registerPage } from "./register.js";
import { createPage } from "./create.js"
import { myFurniturePage } from "./myFurniture.js";
import { detailsPage } from "./details.js";

const root = document.querySelector('.container');

document.getElementById('logoutBtn').addEventListener('click', logouting);

page(decorateContext);
page('/', homePage);
page('/details:id', detailsPage);
page('/edit:id', editPage);
page('/login', loginPage);
page('/register', registerPage);
page('/create', createPage);
page('/myFurniture', myFurniturePage);
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
}

function updateNav() {
    let user = localStorage.getItem('user');

    if (user) {
        document.querySelectorAll('#user').forEach(e => e.style.display = 'block');
        document.querySelectorAll('#guest').forEach(e => e.style.display = 'none');
    }
    else{
        document.querySelectorAll('#user').forEach(e => e.style.display = 'none');
        document.querySelectorAll('#guest').forEach(e => e.style.display = 'block');
    }
}