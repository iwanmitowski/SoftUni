import {htmlPostComposer} from './static/htmlComposer.js';

let form = document.querySelector('form');

let url = `http://localhost:3030/jsonstore/collections/myboard/posts`;

let cancelBtn = form.querySelector('.cancel');
let postBtn = form.querySelector('.public');


let topicNameInput = document.getElementById('topicName');
let userNameInput = document.getElementById('username');
let postTextInput = document.getElementById('postText');

cancelBtn.addEventListener('click', (e)=>{
    e.preventDefault();

    topicNameInput.value = '';
    userNameInput.value = '';
    postTextInput.value = '';
})

form.addEventListener('submit', (e)=>{
    e.preventDefault();

    let formData = new FormData(form);

    let topic = formData.get('topicName');
    let username = formData.get('username');
    let postText = formData.get('postText');

    if (!topic ||
        !username ||
        !postText) {
        return;
    }

    let data = {
        topic,
        username,
        postText,
    }

    fetch(url, {
        method: 'post',
        headers: {
            'Content-Type': 'application/json',
            
        },
        body: JSON.stringify(data)
    })
    .then(res => res.json())
    .then(data =>{
        htmlPostComposer(data.topic,data.username,data._id);
    })
    .catch(err =>{
        console.log(err);
    })
})