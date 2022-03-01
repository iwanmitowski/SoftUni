function attachEvents() {
    let postSelect = document.getElementById('posts');
    let loadPostsBtn = document.getElementById('btnLoadPosts');
    let viewBtn = document.getElementById('btnViewPost');
    let postTitleElement = document.getElementById('post-title');
    let postBodyUl = document.getElementById('post-body');
    let commentsUl = document.getElementById('post-comments');

    const postsUrl = `http://localhost:3030/jsonstore/blog/posts`

    loadPostsBtn.addEventListener('click', ()=>{
        fetch(postsUrl)
        .then(res => res.json())
        .then(data =>{
            Object.values(data).forEach(p=>{
                let option = document.createElement('option');
                
                option.value = p.id;
                option.textContent = p.title;
            
                postSelect.appendChild(option);
            });
        });
    });

    viewBtn.addEventListener('click', (e)=>{
        let postId = postSelect.value;
        console.log(postId);
        const commentsUrl = `http://localhost:3030/jsonstore/blog/comments`;

        fetch(postsUrl)
        .then(res => res.json())
        .then(data =>{
            commentsUl.innerHTML = '';

            postTitleElement.textContent = data[postId].title.toUpperCase();
            postBodyUl.textContent = data[postId].body;

            fetch(commentsUrl)
            .then(res=>res.json())
            .then(data => {

                let comments = Object.values(data).filter(x=>x.postId == postId);
                
                comments.forEach(c=>{
                    let li = document.createElement('li');

                    li.id = c.id
                    li.textContent = c.text

                    commentsUl.appendChild(li);
                })
            })
        });

    });
}

attachEvents();