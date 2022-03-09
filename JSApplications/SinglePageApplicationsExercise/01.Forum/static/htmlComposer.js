function htmlPostComposer(title, username, id) {
    let topicContainer = document.querySelector('.topic-container');
    let date = new Date();
    let today = date.getFullYear() + '-' + (date.getMonth() + 1) + '-' + date.getDate() + ' ' + date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds();
    let divWrapper = document.createElement('div');
    divWrapper.className = 'topic-name-wrapper';
    let divTopicName = document.createElement('div');
    divTopicName.className = 'topic-name';
    let anchor = document.createElement('a');
    anchor.style.cursor = 'pointer';
    anchor.className = 'normal';
    anchor.id = id;
    anchor.addEventListener('click', display);
    let h2 = document.createElement('h2');
    h2.textContent = title;
    let divColumns = document.createElement('div');
    divColumns.className = 'columns';
    let divDateUser = document.createElement('div');
    let pTime = document.createElement('p');
    let time = document.createElement('time');
    time.textContent = today;
    pTime.textContent = `Date: `;
    pTime.appendChild(time);
    let divUser = document.createElement('div');
    divUser.className = 'nick-name';
    let pName = document.createElement('p');
    pName.textContent = 'Username: ';
    let span = document.createElement('span');
    span.textContent = username;
    pName.appendChild(span);

    divUser.appendChild(pName);
    divDateUser.appendChild(pTime);
    divDateUser.appendChild(divUser);
    divColumns.appendChild(divDateUser);
    anchor.appendChild(h2);
    divTopicName.appendChild(anchor);
    divTopicName.appendChild(divColumns);
    divWrapper.appendChild(divTopicName);
    topicContainer.appendChild(divWrapper);
}

function display(e){
    let main = document.querySelector('.container main');
    let id = e.target.parentElement.parentElement.id;
    let timeParam = e.target.parentElement.parentElement.children[1].children[0].children[0].children[0].textContent;
    main.innerHTML = '';

    let url = `http://localhost:3030/jsonstore/collections/myboard/posts/${id}`;
    fetch(url)
    .then(res => res.json())
    .then(data =>{
        let post = data.post;
        let name = data.username;

        main.appendChild(createHtmlContent(post,name,timeParam,id));
        main.appendChild(formCreator());
    })
}

function createHtmlContent(post,name,timeParam,id){
    let divComment = document.createElement('div');
    divComment.id = id;
    divComment.className = 'comment';
    let divHeader = document.createElement('div');
    divHeader.className = 'header';
    let img = document.createElement('img');
    img.src = './static/profile.png';
    img.alt = 'avatar';
    let pNameDate = document.createElement('p');
    let spanName = document.createElement('span');
    spanName.textContent = name + ' posted on ';
    let time = document.createElement('time');
    time.textContent = timeParam;
    pNameDate.appendChild(spanName);
    pNameDate.appendChild(time);
    let pPost = document.createElement('p');
    pPost.textContent = post;
    divHeader.appendChild(img);
    divHeader.appendChild(pNameDate);
    divHeader.appendChild(pPost);
    divComment.appendChild(divHeader);
    return divComment;
}

function formCreator() {
    let id = document.querySelector('.comment').id;
    listComments(id);
    let divAnswerComment = document.createElement('div');
    divAnswerComment.className = 'answer-comment';
    let divAnswer = document.createElement('div');
    divAnswer.className = 'answer';
    let answerForm = document.createElement('form');
    answerForm.addEventListener('submit', request);
    let postTextInput = document.createElement('textarea');
    postTextInput.name = 'postText';
    postTextInput.id = 'comment';
    postTextInput.cols = 30;
    postTextInput.rows = 10;
    answerForm.appendChild(postTextInput);
    let divContainer = document.createElement('div');
    let labelUser = document.createElement('label');
    labelUser.setAttribute('for', 'username');
    labelUser.textContent = 'Username ';
    let span = document.createElement('span');
    span.className = 'red';
    span.textContent = '*';
    labelUser.appendChild(span);
    let usernameInput = document.createElement('input');
    usernameInput.name = 'username';
    usernameInput.id = 'username';
    usernameInput.type = 'text';
    divContainer.appendChild(labelUser);
    divContainer.appendChild(usernameInput);
    answerForm.appendChild(divContainer);
    let postButton = document.createElement('button');
    postButton.textContent = 'Post';
    answerForm.appendChild(postButton);
    let spanCurrent = document.createElement('span');
    spanCurrent.textContent = 'currentUser';
    let pCurrent = document.createElement('p');
    pCurrent.appendChild(spanCurrent);
    let spanComment = document.createElement('span');
    spanComment.textContent = ' comment:';
    pCurrent.appendChild(spanComment);
    divAnswer.appendChild(answerForm)
    divAnswerComment.appendChild(pCurrent);
    divAnswerComment.appendChild(divAnswer);
    return divAnswerComment;
}

function listComments(postId) {

        fetch(`http://localhost:3030/jsonstore/collections/myboard/comments/${postId}`)
        .then(res => res.json())
        .then(data =>{
            Object.values(data).forEach(c => {
                let newNode = commentBodyCreator(c.username, c.creationDate, c.comment);
                let referenceNode = document.querySelector('.answer-comment');
                let parentNode = document.querySelector('main');
                parentNode.insertBefore(newNode, referenceNode);
            });
        })
        .catch(err =>{
            console.log(err);            
        });
    
}

function request(e) {
    e.preventDefault();
    
    let id = e.target.parentElement.parentElement.parentElement.children[0].id;
    console.log(id);
    let url = `http://localhost:3030/jsonstore/collections/myboard/posts/${id}`;

    fetch(url)
    .then(res => res.json())
    .then(data =>{
        let username = document.getElementById('username');
        let comment = document.getElementById('postText');
    
        let date = new Date();
        let creationDate = date.getFullYear() + '-' + (date.getMonth() + 1) + '-' + date.getDate() + ' ' + date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds();
        if (username == '') {
            return alert('You must provide username');
        }

        let topicName = data.title;

        let commentToCreate = {
            comment,
            username,
            creationDate,
            topicName
        };

        fetch(`http://localhost:3030/jsonstore/collections/myboard/comments/${id}`, {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(commentToCreate)
    })
    .then(res => res.json())
    .then(data =>{
        console.log(data);
        let newNode = commentBodyCreator(data.username, data.creationDate, data.comment);
        console.log(newNode);
        let referenceNode = document.querySelector('.answer-comment');
        let parentNode = document.querySelector('main');
        parentNode.insertBefore(newNode, referenceNode);
    });
    })
}

function commentBodyCreator(user, time, content) {
    let divComment = document.createElement('div');
    divComment.className = 'user-comment';
    let divTopicNameWrapper = document.createElement('div');
    divTopicNameWrapper.className = 'topic-name-wrapper';
    let divTopicName = document.createElement('div');
    divTopicName.className = 'topic-name';
    let pNameDate = document.createElement('p');
    pNameDate.innerHTML = `<p><strong>${user}</strong> commented on <time>${time}</time></p>`;
    let divContent = document.createElement('div');
    divContent.className = 'post-content';
    let pContent = document.createElement('p');
    pContent.textContent = content;
    divContent.appendChild(pContent);
    divTopicName.appendChild(pNameDate);
    divTopicName.appendChild(divContent);
    divTopicNameWrapper.appendChild(divTopicName);
    divComment.appendChild(divTopicNameWrapper);
    return divComment;
}

export {htmlPostComposer}