import { getAllIdeas } from "../api/data.js";

const section = document.getElementById('dashboard-holder');

section.addEventListener('click', onDetailsClick)

let ctx = null;

export async function showCatalog(context){
    ctx = context;
    let ideas = await getAllIdeas();

    if (ideas.length == 0) {
        section.innerHTML = '<h1>No ideas yet! Be the first one :)</h1>'
    }
    else{
        section.replaceChildren(...ideas.map(createIdea));
    }
    
    context.showSection(section);
}

function createIdea(idea){
    let element = document.createElement('div');
    element.className = 'card overflow-hidden current-card details';
    element.style.width = '20rem'
    element.style.height = '18rem';
    element.innerHTML = `
    <div class="card-body">
        <p class="card-text">${idea.title}</p>
    </div>
    <img class="card-image" src="${idea.img}" alt="Card image cap">
    <a data-id="${idea._id}" class="btn" href="">Details</a>
    `;

    return element;
}

function onDetailsClick(e){
    console.log(e.target.dataset.id);
    if (e.target.tagName == 'A') {
        e.preventDefault();
        ctx.goTo('/details', e.target.dataset.id);
    }
}