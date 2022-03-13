import { login } from "../api/users.js";

const section = document.getElementById('loginPage');
let form = document.querySelector('.form-user');
form.addEventListener('submit', onSubmit);

let ctx = null;

export function showLogin(context){
    ctx = context;
    window.context = context;
    console.log(ctx);
    console.log(context);
    context.showSection(section);
}

async function onSubmit(e){
    e.preventDefault();
    let formData = new FormData(form);
    
    let email = formData.get('email');
    let password = formData.get('password');
    
    await login(email, password);
    ctx.updateNav();
    ctx.goTo('/');
}