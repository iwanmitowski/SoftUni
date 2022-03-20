import { logout } from "../src/api/users.js";
import page from '../../node_modules/page/page.mjs'
import { render } from "../../node_modules/lit-html/lit-html.js";
import { loginPage } from "./login.js";
import { homePage } from "./home.js";
import { registerPage } from "./register.js";
import { browsePage } from "./browse.js";

const root = document.querySelector('main');

document.getElementById('logoutBtn').addEventListener('click', logouting);

page(decorateContext);
page('/',homePage);
page('/login', loginPage);
page('/register', registerPage);
page('/browse', browsePage);
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
}

function updateNav() {
    let user = localStorage.getItem('user');

    if (user) {
        document.querySelectorAll('.user').forEach(e => e.style.display = 'block');
        document.querySelectorAll('.guest').forEach(e => e.style.display = 'none');
    }
    else{
        document.querySelectorAll('.user').forEach(e => e.style.display = 'none');
        document.querySelectorAll('.guest').forEach(e => e.style.display = 'block');
    }
}