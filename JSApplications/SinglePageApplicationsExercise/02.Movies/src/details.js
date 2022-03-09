import { showView } from "./utils.js";

let section = document.getElementById('movie-example');

export async function detailsPage(id){
    showView(section);

    let user = JSON.parse(localStorage.getItem('user'));

    let [movie, likes, isLikedByUser] = await Promise.all([
        getMove(id),
        getLikes(id),
        isLiked(id, user),
    ])

    section.replaceChildren(await createMovie(id, movie, likes, isLikedByUser, user))
}

async function createMovie(id, movie, likes, isLikedByUser, user){
    let m = await getMove(id)

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
                ${await generateBtns(movie, user, isLikedByUser)}
                <span class="enrolled-span">Liked ${likes}</span>
            </div>
        </div>
    `;
    
    const likeBtn = element.querySelector('.like-btn');
    if (likeBtn) {
        likeBtn.addEventListener('click', (e) => likeMovie(e, movie._id));
    }

    return element;
}

async function generateBtns(movie, user, isLikedByUser){
    let isOwner = user && user._id == movie._ownerId;

    let controls = [];

    if (isOwner) {
        controls.push('<a class="btn btn-danger" href="#">Delete</a>')
        controls.push('<a class="btn btn-warning" href="#">Edit</a>')
    }else if( user && isLikedByUser == false) {
        controls.push('<a class="btn btn-primary like-btn" href="#">Like</a>');
    }
    controls.push();

    return controls.join('');
}

async function getMove(id){
    let res = await fetch(`http://localhost:3030/data/movies/${id}`);
    let movie = await res.json();

    return movie;
}

async function getLikes(id){
    let res = await fetch(`http://localhost:3030/data/likes?where=movieId%3D%22${id}%22&distinct=_ownerId&count `);
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

    let res = await fetch('http://localhost:3030/data/likes', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': user.accessToken
        },
        body: JSON.stringify(data)
    });
    
    detailsPage(id);
}