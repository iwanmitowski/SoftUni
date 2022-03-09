import { homePage } from "./home.js";
import { showView, updateNav } from "./utils.js";

let section = document.getElementById('form-sign-up');
let form = document.querySelector('#form-sign-up form');
form.addEventListener('submit', onSubmit);

export function registerPage(){
    showView(section);
}

async function onSubmit(e){
    e.preventDefault();

    let formData = new FormData(form);

    let email = formData.get('email');
    let password = formData.get('password');
    let repeatPassword = formData.get('repeatPassword');

    if (!email ||
        !password ||
        !repeatPassword) {
        alert('Fill all the fields!')
        return;
    }

    if (password !== repeatPassword) {
        alert('Passwords do not match!');
        return;
    }

    if (password.length < 6) {
        alert('Password should be more than 6 symbols!');
        return;
    }

    await register(email, password);
    homePage();
    updateNav();
}

async function register(email, password){
    try {
        let data = {
            email,
            password
        }
    
        let res = await fetch('http://localhost:3030/users/register', {
            method: 'post',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        })
        if (!res.ok) {
            let error = res.json();
            throw new Error(error.message);
        }
 
        let user = await res.json();
        localStorage.setItem('user', JSON.stringify(user))
    } catch (error) {
        alert(error.message);
        throw error;
    }
    
    
}