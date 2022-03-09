import { showView, updateNav } from "./utils.js";
import { homePage } from "./home.js"

let section = document.querySelector('#form-login');
let form = document.querySelector('#form-login form');
form.addEventListener('submit', onSubmit);

export function loginPage(){
    showView(section);
}

async function onSubmit(e){
    e.preventDefault();
    
    let formData = new FormData(form);

    let email = formData.get('email');
    let password = formData.get('password');

    await login(email, password);
    form.reset();
    homePage();
    updateNav();
}

async function login(email, password){
    try {
        let data = {
            email,
            password
        }
    
        let res = await fetch('http://localhost:3030/users/login', {
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