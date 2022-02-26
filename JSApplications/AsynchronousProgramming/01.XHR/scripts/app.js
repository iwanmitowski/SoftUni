function loadRepos() {

        let btn = document.getElementById('btn');
        let article = document.getElementById('res');
        
        btn.addEventListener('click', ()=>{
            console.log(1);
            let xhr = new XMLHttpRequest();

            xhr.addEventListener('readystatechange', ()=>{
            if (xhr.readyState == 4 && xhr.status === 200) {
                article.textContent = xhr.responseText;
            }
            
        })
        xhr.open('GET', 'https://api.github.com/users/testnakov/repos')
        xhr.send();
        });
}