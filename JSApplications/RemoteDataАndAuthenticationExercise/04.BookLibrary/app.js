let loadBtn = document.getElementById('loadBooks');
let body = document.querySelector('body > table:nth-child(2) > tbody:nth-child(2)');
let form = document.querySelector('form');
let titleInput = document.querySelector('body > form:nth-child(3) > input:nth-child(3)');
let authorInput = document.querySelector('body > form:nth-child(3) > input:nth-child(5)');

let submitBtn = document.querySelector('body > form:nth-child(3) > button:nth-child(6)')

let url = `http://localhost:3030/jsonstore/collections/books`;

submitBtn.addEventListener('click', (e)=>{
    e.preventDefault();
    let title = titleInput.value
    let author = authorInput.value

    if (!title || !author) {
        return;
    }

    let data = {
        title,
        author,
    }

    fetch(url, {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data),
    })
    .then(res=>{
        console.log(res);
    })
    .catch(err=>{
        console.log(err);
    })
})

loadBtn.addEventListener('click', (e)=>{
    e.preventDefault();

    fetch(url)
    .then(res=>res.json())
    .then(data =>{
        Object.keys(data).forEach(k=>{
            let tr = document.createElement('tr');
            let nameTd = document.createElement('td');
            let authorTd = document.createElement('td');
            let buttonsTd = document.createElement('td');

            nameTd.textContent = data[k].title;
            authorTd.textContent = data[k].author;
            console.log(data[k].title);
            let editBtn = document.createElement('button');
            editBtn.textContent = 'Edit';
            editBtn.addEventListener('click', (e)=>{
                e.preventDefault();
                console.log(1);
                let formTitle = form.querySelector('h3');
                console.log(formTitle.textContent);
                if (!formTitle.textContent.startsWith('Edit')) {
                    formTitle.textContent = `Edit ${formTitle.textContent}`;
                }

                titleInput.value = data[k].title;
                authorInput.value = data[k].author;
            });

            let deleteBtn = document.createElement('button');
            deleteBtn.textContent = 'Delete';
            deleteBtn.addEventListener('click', (e)=>{
                e.preventDefault();
                
                let deleteUrl = `${url}/${k}`;

                fetch(deleteUrl,{
                    method: 'delete'
                })
                .then(data =>{
                    console.log(data);
                    console.log(123);
                    e.currentTarget.parentNode.parentNode.remove();
                })
                .catch(err=>{

                })
            });

            tr.appendChild(nameTd);
            tr.appendChild(authorTd);
            tr.appendChild(buttonsTd);
            buttonsTd.appendChild(editBtn);
            buttonsTd.appendChild(deleteBtn);
            body.appendChild(tr);
        });
    })
})