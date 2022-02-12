window.addEventListener('load', solve);

function solve() {
    let genreElement = document.getElementById('genre');
    let nameElement = document.getElementById('name');
    let authorElement = document.getElementById('author');
    let dateElement = document.getElementById('date');
    let addButton = document.getElementById('add-btn');
    let allHitsElement = document.querySelector('.all-hits-container');
    let likesElement = document.querySelector('.likes p');
    let savedHits = document.querySelector('.saved-container');

    addButton.addEventListener('click', (e)=>{
        e.preventDefault();

        let genre = genreElement.value;
        let name = nameElement.value;
        let author = authorElement.value;
        let date = dateElement.value;

        if (!genre ||
            !name ||
            !author ||
            !date) {
            return;
        }

        let divParentElement = document.createElement('div');
        let imgElement = document.createElement('img');
        let genreH2 = document.createElement('h2');
        let nameH2 = document.createElement('h2');
        let authorH2 = document.createElement('h2');
        let dateH3 = document.createElement('h3');
        let saveBtn = document.createElement('button');
        let likeBtn = document.createElement('button');
        let deleteBtn = document.createElement('button');

        divParentElement.classList.add('hits-info');

        imgElement.src = './static/img/img.png';
        divParentElement.appendChild(imgElement);

        genreH2.textContent = `Genre: ${genre}`;
        nameH2.textContent = `Name: ${name}`;
        authorH2.textContent = `Author: ${author}`;
        dateH3.textContent = `Date: ${date}`;

        divParentElement.appendChild(genreH2);
        divParentElement.appendChild(nameH2);
        divParentElement.appendChild(authorH2);
        divParentElement.appendChild(dateH3);
        
        deleteBtn.textContent = 'Delete';
        deleteBtn.classList.add('delete-btn');
        deleteBtn.addEventListener('click', (e)=>{
            e.currentTarget.parentElement.remove();
        });

        saveBtn.textContent = 'Save song';
        saveBtn.classList.add('save-btn');
        saveBtn.addEventListener('click', (e)=>{
            let hitElement = document.createElement('div');
            hitElement.classList.add('hits-info');
            
            hitImgElement = document.createElement('img');
            hitGenreElement = document.createElement('h2');
            hitNameElement = document.createElement('h2')
            hitAuthorElement = document.createElement('h2');
            hitDateElement = document.createElement('h3');
            hitDeleteBtn = document.createElement('button');

            hitGenreElement.textContent = `Genre: ${genre}`;
            hitNameElement.textContent = `Name: ${name}`;
            hitAuthorElement.textContent = `Author: ${author}`;
            hitDateElement.textContent = `Date: ${date}`;
            hitDeleteBtn.addEventListener('click', (e) => {
                e.currentTarget.parentElement.remove();
            });

            hitImgElement.src = './static/img/img.png';

            hitElement.appendChild(imgElement);
            hitElement.appendChild(genreH2);
            hitElement.appendChild(nameH2);
            hitElement.appendChild(authorH2);
            hitElement.appendChild(dateH3);
            hitElement.appendChild(deleteBtn);

            savedHits.appendChild(hitElement);
            divParentElement.remove();
        });

        likeBtn.textContent = 'Like song';
        likeBtn.classList.add('like-btn');
        likeBtn.addEventListener('click', (e)=>{
            let likeValues = likesElement.textContent.split(' ');
            let currentLikes = Number(likeValues[2]);
            currentLikes++;

            likeValues[2] = currentLikes;
            likesElement.textContent = likeValues.join(' ');
            e.currentTarget.disabled = true;
        })

        divParentElement.appendChild(saveBtn);
        divParentElement.appendChild(likeBtn);
        divParentElement.appendChild(deleteBtn);

        genreElement.value = '';
        nameElement.value = '';
        authorElement.value = '';
        dateElement.value = '';
        allHitsElement.appendChild(divParentElement);
    });
}