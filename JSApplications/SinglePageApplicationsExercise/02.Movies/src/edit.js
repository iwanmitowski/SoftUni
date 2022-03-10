import { detailsPage } from "./details.js";
import { showView, updateNav } from "./utils.js";

let section= document.getElementById('edit-movie');
let form = section.querySelector('form');
form.addEventListener('submit', onSubmit)

let globalId;

let titleInput = document.querySelector('#edit-movie > form:nth-child(1) > div:nth-child(2) > input:nth-child(2)');
let descrInput = document.querySelector('#edit-movie > form:nth-child(1) > div:nth-child(3) > textarea:nth-child(2)');
let imageInput = document.querySelector('#edit-movie #imageUrl');

export async function editPage(id) {
    showView(section)
    console.log(`GLOBAL${id}`);

    globalId = id;
    let movie = await getMovie(id);
    await loadMovie(movie);
    
}

async function onSubmit(e){
    e.preventDefault();

    let formData = new FormData(form);

    let title = formData.get('title');
    let description = formData.get('description');
    let img = formData.get('imageUrl');

    console.log(img);

    if (!title ||
        !description ||
        !img) {
        alert('Fill all the data!');
        return;
    }

    await editMovie(title, description, img);
    detailsPage(globalId);
    updateNav();
}

async function getMovie(id){
    let res = await fetch(`http://localhost:3030/data/movies/${id}`);
    let movie = await res.json();

    return movie;
}

async function loadMovie(movie){
    titleInput.value = movie.title;
    descrInput.value = movie.description;
    imageInput.value = movie.img;
}

async function editMovie(title, description, img){
    try {
        let data = {
            title,
            description,
            img,
        }

        let user = JSON.parse(localStorage.getItem('user'));

        let res = await fetch(`http://localhost:3030/data/movies/${globalId}`, {
            method: 'put',
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

    } catch (error) {
        console.log(error.message);
    }
}