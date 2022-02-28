function solution() {
    let mainElement = document.getElementById('main');

    const url = `http://localhost:3030/jsonstore/advanced/articles/list`;

    fetch(url)
        .then(res => res.json())
        .then(data =>{
            
        let articles = Object.values(data);
        
        articles.forEach(a => {
            const accTemplate = ` <div class="accordion">
            <div class="head">
                <span>${a.title}</span>
                <button class="button" id="${a._id}">More</button>
            </div>
            <div class="extra">
            <p></p>
            </div>
        </div>`;
        mainElement.innerHTML += accTemplate;
        });
    })
    .finally(()=>{
        let buttons = Array.from(document.getElementsByTagName('button'));

        buttons.forEach(b=>{
            let url = `http://localhost:3030/jsonstore/advanced/articles/details/${b.id}`;
            
            b.addEventListener('click',(e)=>{
                if (b.textContent == 'More') {
                    let extraElement = e.currentTarget.parentNode.parentNode.children[1];
                    fetch(url)
                        .then(res => res.json())
                        .then(data =>{
                            let {content} = data;
                            console.log(content);
                            extraElement.textContent = content;
                    });
                    b.textContent = 'Less'
                    extraElement.classList.remove('extra');
                }
                else{
                    let extraElement = e.currentTarget.parentNode.parentNode.children[1];
                    b.textContent = 'More'
                    extraElement.classList.add('extra');
                }
               
            });
        })
    });
}

solution();