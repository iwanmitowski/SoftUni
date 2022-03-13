import * as data from "../api/data.js";

const section = document.getElementById('createPage');
const form = document.querySelector('form');

form.addEventListener('submit', onSubmit);

let ctx = null;

export function showCreate(context){
    ctx = context;
    context.showSection(section);
}

async function onSubmit(){
    e.preventDefault();
    let formData = new FormData(form);

    let title = formData.get('title');
    let description = formData.get('description');
    let img = formData.get('imageURL')

    if (title.length < 6) {
        alert('The title should be at least 6 characters long.');
        return;
    }

    if (description.length < 10) {
        alert('The description should be at least 10 characters long.');
        return;
    }

    if (img.length < 5) {
        alert('The description should be at least 10 characters long.');
        return;
    }

    let idea = {
        title,
        description,
        img,
    }

    await data.createIdea(idea);
    form.reset();
    ctx.goTo('/catalog');

}