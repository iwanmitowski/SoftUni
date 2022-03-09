import { homePage } from "./home.js";
import { showView, updateNav } from "./utils.js";

let section = document.getElementById('add-movie');
let form = section.querySelector('form');
form.addEventListener('submit', onSubmit);

export function createPage(){
    showView(section);
}

async function onSubmit(e){
    e.preventDefault();

    let formData = new FormData(form);

    let title = formData.get('title');
    let description = formData.get('description');
    let img = formData.get('imageUrl');

    if (!title ||
        !description ||
        !img) {
        alert('Fill all the data!');
        return;
    }

    await createMovie(title, description, img);
    homePage();
    updateNav();
}

async function createMovie(title, description, img){
    try {
        let data = {
            title,
            description,
            img,
        }

        let user = JSON.parse(localStorage.getItem('user'));

        let res = await fetch('http://localhost:3030/data/movies', {
            method: 'post',
            headers:{
                'Content-Type': 'application/json',
                'X-Authorization': user.accessToken
            },
            body: JSON.stringify(data)
        });

        if (!res.ok) {
            let error = res.json();
            throw new Error(error.message);
        }

        let movie = await res.json();
        console.log(movie);
    } catch (error) {
        
    }
}

