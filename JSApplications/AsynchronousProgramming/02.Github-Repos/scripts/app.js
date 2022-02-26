function loadRepos() {
	let loadBtn = document.querySelector('body > button:nth-child(3)');
	let repos = document.getElementById('repos');

	loadBtn.addEventListener('click', ()=>{
		let name = document.getElementById('username').value;
		const url = `https://api.github.com/users/${name}/repos`
		fetch(url)
			.then(response => response.json())
			.then(data =>{
				repos.innerHTML = '';
				
				Object.values(data).forEach(repo =>{
					let {full_name, html_url} = repo;

					let li = document.createElement('li');
					let a = document.createElement('a');
					
					a.textContent = full_name;
					a.href = html_url;

					li.appendChild(a);
					repos.appendChild(li);
				});
				
			})
			.catch(err => console.log(err));
	});
}