function loadCommits() {
    let btn = document.querySelector('body > button:nth-child(4)');

    btn.addEventListener('click', ()=>{

        let username = document.getElementById('username').value;
        let repo = document.getElementById('repo').value;
        let commits = document.getElementById('commits');

        let url = `https://api.github.com/repos/${username}/${repo}/commits`

        fetch(url)
            .then(res => {
                if (res.ok) {
                    console.log(1);
                    return res.json();
                }
                
                throw res;
            })
            .then(res => {
                Object.values(res).forEach(commitData =>{
                    let {commit} = commitData;

                    let author = commit.author.name;
                    let message =  commit.message;
                    let li = document.createElement('li');
                    li.textContent = `${author}: ${message}`

                    commits.appendChild(li);
                });
            })
            .catch(err =>{
                let li = document.createElement('li');
                li.textContent = `Error: ${err.status} (${err.statusText})`;
                commits.appendChild(li);
            })
           
    });
}