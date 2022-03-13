import { deleteIdea, getIdea } from "../api/data.js";

const section = document.getElementById('detailsPage');

let isOwner;

export async function showDetails(context, id){
    let idea = await getIdea(id);
    
    let user = JSON.parse(localStorage.getItem('user'));
    
    isOwner = user && user._id === idea._ownerId;
    section.innerHTML = createIdea(idea);

    if (isOwner) {
        section.querySelector('#deleteBtn').addEventListener('click' ,async (e)=>{
            e.preventDefault();
            await deleteIdea(idea._id);
            context.goTo('/catalog');
        })
    }
    context.showSection(section);
} 

function createIdea(idea){
    let html = `
    <img class="det-img" src="${idea.img}" />
        <div class="desc">
            <h2 class="display-5">${idea.title}</h2>
            <p class="infoType">Description:</p>
            <p class="idea-description">${idea.description}</p>
        </div>
    `

   if (isOwner) {
    html +=`
    <div class="text-center">
            <a class="btn detb" id="deleteBtn" href="">Delete</a>
    </div>
    `
   }
    return html;
}

