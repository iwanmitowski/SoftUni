window.addEventListener('load', ()=>{
    let main = document.querySelector('main');
    main.innerHTML = '';
    loadRecipes();

})

async function loadRecipes(){
    let main = document.querySelector('main');

    fetch(' http://localhost:3030/jsonstore/cookbook/recipes')
    .then(res => res.json())
    .then(data =>{
        let recipes = Object.values(data);

        recipes.forEach(r=>{
            let articlePreview = document.createElement('article');
            articlePreview.classList.add('preview');
            
            let titleDiv = document.createElement('div');
            titleDiv.classList.add('title');
           
            let titleH2 = document.createElement('h2');
            titleH2.textContent = r.name;
            
            titleDiv.appendChild(titleH2);

            let smallDiv = document.createElement('div');
            smallDiv.classList.add('small');

            let img = document.createElement('img');
            img.src = r.img;
            
            smallDiv.appendChild(img);

            articlePreview.appendChild(titleDiv);
            articlePreview.appendChild(smallDiv);

            main.appendChild(articlePreview);

            articlePreview.addEventListener('click', toggleCard);

            function toggleCard(e){
                
                if (!e.currentTarget.classList) {
                    e.currentTarget.replaceWith(articlePreview);
                    return;
                }

                fetch(`http://localhost:3030/jsonstore/cookbook/details/${r._id}`)
                .then(res => res.json())
                .then(data => {
                    let recipe = data;

                    let article = document.createElement('article');

                    let nameH2 = document.createElement('h2');
                    nameH2.textContent = recipe.name;
                    article.appendChild(nameH2);

                    let divBand = document.createElement('div');
                    divBand.classList.add('band');

                    divThumb = document.createElement('div');
                    divThumb.classList.add('thumb');
                    divBand.appendChild(divThumb);

                    let imgEl = document.createElement('img');
                    imgEl.src = recipe.img;
                    
                    divThumb.appendChild(imgEl);

                    let ingredientsDiv = document.createElement('div');
                    ingredientsDiv.classList.add('ingredients');
                    let ingredientsH3 = document.createElement('h3');
                    ingredientsH3.textContent = 'Ingredients:';

                    ingredientsDiv.appendChild(ingredientsH3)
                    let ingredientsUl = document.createElement('ul');
                    ingredientsDiv.appendChild(ingredientsUl);
                    
                    recipe.ingredients.forEach(i =>{
                        let currIngr = document.createElement('li');
                        currIngr.textContent = i;

                        ingredientsUl.appendChild(currIngr);
                    });
                   
                    divBand.appendChild(ingredientsDiv);
                    article.appendChild(divBand);

                    descriptionDiv = document.createElement('div');
                    descriptionDiv.classList.add('description');

                    presentationH3 = document.createElement('h3');
                    presentationH3.textContent = 'Preparation:';

                    descriptionDiv.appendChild(presentationH3);

                    recipe.steps.forEach(s =>{
                        let currStepP = document.createElement('p');
                        currStepP.textContent = s;

                        descriptionDiv.appendChild(currStepP);
                    })
                    article.appendChild(descriptionDiv);
                    article.addEventListener('click', toggleCard);

                    articlePreview.replaceWith(article);
                });

            }
        })
    })
    .catch();
}

