import { logout } from './api/users.js';
import { init } from './router.js';
import { showCatalog } from './views/catalog.js';
import { showCreate } from './views/create.js';
import { showDetails } from './views/details.js';
import { showHome } from './views/home.js';
import { showLogin } from './views/login.js';
import { showRegister } from './views/register.js';

document.getElementById('views').remove();

const links = {
    '/': showHome,
    '/catalog': showCatalog,
    '/login': showLogin,
    '/register': showRegister,
    '/details': showDetails,
    '/create': showCreate,
    '/logout': onLogout,
}

const router = init(links);
router.updateNav();
// Не знам защо логин не работи, в конзолата има window.login връща всичко и работи както трябва.
// Същото важи и за Create
// Ще се радвам за предложения защо :)

router.goTo('/');

function onLogout(){
    logout();
    router.updateNav();
    router.goTo('/');
}
