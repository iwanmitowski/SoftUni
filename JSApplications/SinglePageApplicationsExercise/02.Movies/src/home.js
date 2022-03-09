import { detailsPage } from "./details.js";
import { showView } from "./utils.js";

let section = document.querySelector('#home-page');
let movie = document.querySelector('#movie');
let cardDeck = movie.querySelector('.card-deck');

cardDeck.addEventListener('click', (e)=>{
    if (e.target.tagName == 'BUTTON') {
        e.preventDefault();
        let id = e.target.dataset.id;
        detailsPage(id);
    }
})

export function homePage() {
    showView(section);
    showView(movie);
    displayMovies();
}

async function displayMovies(){
    let movies = await getMovies();

    cardDeck.replaceChildren(...movies.map(createMovie));
}

function createMovie(m){
    let element = document.createElement('div');
    element.className = 'card mb-4';

    element.innerHTML = `
                    <img class="card-img-top" src="${m.img}"
                         alt="Card image cap" width="400">
                    <div class="card-body">
                        <h4 class="card-title">${m.title}</h4>
                    </div>
                    <div class="card-footer">
                        <a href="/details/${m._id}">
                            <button data-id="${m._id}" type="button" class="btn btn-info">Details</button>
                        </a>
                    </div>`
    return element;
}

async function getMovies(){
    let res = await fetch('http://localhost:3030/data/movies');
    let data = await res.json();

    return data;
}