function attachEvents() {
    let loadBtn = document.getElementById('btnLoad');
    let phonebook = document.getElementById('phonebook');
    
    let personInput = document.getElementById('person');
    let phoneInput = document.getElementById('phone');

    let btnCreate = document.getElementById('btnCreate');

    let url = `http://localhost:3030/jsonstore/phonebook`;

    loadBtn.addEventListener('click', (e)=>{
        e.preventDefault();
        
        phonebook.innerHTML = '';

        fetch(url)
        .then(res => res.json())
        .then(data =>{
            Object.values(data).forEach(p=>{
                let li = document.createElement('li');
                let deleteBtn = document.createElement('button');

                li.textContent = `${p.person}: ${p.phone}`
                deleteBtn.textContent = 'Delete';
                deleteBtn.id = p._id;

                li.appendChild(deleteBtn);

                phonebook.appendChild(li);

                deleteBtn.addEventListener('click', (e)=>{
                    let currentId = e.currentTarget.id;

                    fetch(`${url}/${currentId}`, {
                        method: 'delete',

                    })

                    e.currentTarget.parentNode.remove();
                })
            })
        })
        .catch(err =>{
            console.log(err);
        })
    });

    const nameRegex = new RegExp(/[A-Z][-]?[a-z]+/g);
    const phoneRegex = new RegExp(/^\+359[\s]?[0-9]{9}$/g)

    btnCreate.addEventListener('click', (e)=>{
        e.preventDefault();

        let person = personInput.value;
        let phone = phoneInput.value;

        let isInvalidName = !nameRegex.test(person);
        let isInvalidPhone = !phoneRegex.test(phone);

        console.log(isInvalidName);
        console.log(isInvalidPhone);

        console.log(person);
        console.log(phone);

        if (isInvalidName || isInvalidPhone) {
            return;
        }
        
        let data = {
            person,
            phone,
        }
        console.log(data);
        fetch(url, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        })
        .then(res =>{
            personInput.value = ''
            phoneInput.value = ''
        })
        .catch(err =>{
            console.log(err);
        })

        loadBtn.click();
    });
}

attachEvents();