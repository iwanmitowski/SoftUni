import { register } from "../api/users.js";

const section = document.getElementById('registerPage');

let form = document.querySelector('#registerPage > div > form');

form.addEventListener('submit', onSubmitReg);

let ctx;

export function showRegister(context){
    ctx = context;
    
    context.showSection(section);
}

async function onSubmitReg(e){
    e.preventDefault();
    let formData = new FormData(form);

    let email = formData.get('email');
    let password = formData.get('password');
    let repeatPassword = formData.get('repeatPassword');

    if (email.length < 3) {
        alert('The email should be at least 3 characters long');
        return;
    }
    if (password.length < 3) {
        alert('The password should be at least 3 characters long');
        return;
    }
    if (password !== repeatPassword) {
        alert('The repeat password should be equal to the password');
        return;
    }

    await register(email, password);
    ctx.updateNav();
    ctx.goTo('/');
}

