function attachEvents() {
    let submitBtn = document.getElementById('submit');
    let refreshBtn = document.getElementById('refresh');

    let nameInput = document.querySelector('#controls > input:nth-child(2)');
    let messageInput = document.querySelector('#controls > input:nth-child(5)');

    let messages = document.getElementById('messages');

    let url = `http://localhost:3030/jsonstore/messenger`;

    submitBtn.addEventListener('click', (e)=>{
        e.preventDefault();

        let data = {
            author: nameInput.value,
            headers:{
                'Content-type': 'application/json'
            },
		    content: messageInput.value
        }

        fetch(url, {
            method: 'post',
            body: JSON.stringify(data),
        })
        .then(res=>{
            console.log(res);
        })
        .catch(err =>{
            console.log(err);
        })
    })

    refreshBtn.addEventListener('click', (e)=>{
        e.preventDefault();

        messages.textContent = '';

        fetch(url)
        .then(res => res.json())
        .then(data =>{
            Object.values(data).forEach(m=>{
                messages.textContent += `${m.author}: ${m.content}\n`
            })
        })
    })
}

attachEvents();