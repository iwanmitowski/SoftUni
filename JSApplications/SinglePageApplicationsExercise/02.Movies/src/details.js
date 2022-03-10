import { editPage } from "./edit.js";
import { homePage } from "./home.js";
import { showView } from "./utils.js";

let section = document.getElementById('movie-example');
let globalId;

export async function detailsPage(id){
    showView(section);
    globalId = id;
    let user = JSON.parse(localStorage.getItem('user'));

    const [likes, isLikedByUser] = await Promise.all([
        getLikes(id),
        isLiked(id, user)
    ]);

    section.replaceChildren(await createMovie(id, likes, isLikedByUser, user))
}

async function createMovie(id, likes, isLikedByUser, user){
    let m = await getMovie(id)

    let element = document.createElement('div');
    element.className = 'container';
    element.innerHTML = `
    <div class="row bg-light text-dark">
            <h1>Movie title: ${m.title}</h1>

            <div class="col-md-8">
                <img class="img-thumbnail" src="${m.img}"
                     alt="Movie">
            </div>
            <div class="col-md-4 text-center">
                <h3 class="my-3 ">Movie Description</h3>
                <p>${m.description}</p>
                ${await generateBtns(m, user, isLikedByUser)}
                <span class="enrolled-span">Liked ${likes}</span>
            </div>
        </div>
    `;
    
    let likeBtn = element.querySelector('.like-btn');
    if (likeBtn) {
        likeBtn.addEventListener('click', (e) => likeMovie(e, m._id));
    }

    let deleteBtn = element.querySelector('.delete-btn');
    if (deleteBtn) {
        deleteBtn.addEventListener('click', (e) => deleteMovie(e, m._id))
    }

    let editBtn = element.querySelector('.edit-btn');
    if (editBtn) {
        editBtn.addEventListener('click', openEditPage)
    }

    return element;
}

async function generateBtns(movie, user, isLikedByUser){
    let isOwner = user && user._id == movie._ownerId;

    let controls = [];

    if (isOwner) {
        controls.push('<a class="btn btn-danger delete-btn" href="#">Delete</a>')
        controls.push('<a class="btn btn-warning edit-btn" href="#">Edit</a>')
    }else if( user && isLikedByUser == false) {
        controls.push('<a class="btn btn-primary like-btn" href="#">Like</a>');
    }
    controls.push();

    return controls.join('');
}

async function getMovie(id){
    let res = await fetch(`http://localhost:3030/data/movies/${id}`);
    let movie = await res.json();

    return movie;
}

async function getLikes(id){
    let res = await fetch(`http://localhost:3030/data/likes?where=movieId%3D%22$${id}%22&distinct=_ownerId&count`);
    let likes = await res.json();

    return likes;
}

async function isLiked(id, user){
    if (!user) {
        return false;
    }

    const res = await fetch(`http://localhost:3030/data/likes?where=movieId%3D%22${id}%22%20and%20_ownerId%3D%22${user._id}%22`);
    const like = await res.json();

    return like.length > 0;
}

async function likeMovie(e, id){
    e.preventDefault();

    let data = {
        id
    }
    
    const user = JSON.parse(localStorage.getItem('user'));

    await fetch('http://localhost:3030/data/likes', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': user.accessToken
        },
        body: JSON.stringify(data)
    });
    
    detailsPage(id);
}


async function deleteMovie(e, id){
    e.preventDefault();
    
    const user = JSON.parse(localStorage.getItem('user'));

    let res = await fetch(`http://localhost:3030/data/movies/${id}`, {
        method: 'delete',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': user.accessToken
        },
    });

    console.log(res.json());
    
    homePage();
}

async function openEditPage(e){
    e.preventDefault();
    editPage(globalId);
}