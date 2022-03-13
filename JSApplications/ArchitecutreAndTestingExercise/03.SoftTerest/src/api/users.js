import { get, post } from './api.js'

const urls = {
    'login': '/users/login',
    'register': '/users/register',
    'logout': '/users/logout',
}

export async function login(email, password){
    const user = await post(urls.login, {email, password});

    localStorage.setItem('user', JSON.stringify(user));
}

export async function register(email, password){
    const user = await post('/users/register', {email, password});
    
    localStorage.setItem('user', JSON.stringify(user));
}


export async function logout(){
    get(urls.logout);
    localStorage.removeItem('user');
}

window.login = login;