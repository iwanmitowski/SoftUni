let form = document.querySelector('form');

form.addEventListener('submit', (e)=>{
    e.preventDefault();

    let formData = new FormData(e.currentTarget);

    let name = formData.get('name');
    let img = formData.get('img'); 
    let ingredients = formData.get('ingredients').split('\n');
    let steps = formData.get('steps').split('\n');

    let data = {
        name,
        img,
        ingredients,
        steps,
    }

    fetch('http://localhost:3030/data/recipes', {
        method: 'post',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': sessionStorage.getItem('token'),
        },
        body: JSON.stringify(data)
    })
    .then(res =>{
        if (res.ok) {
            return res.json();
        }

        throw new Error(res);
    })
    .then(data =>{
        console.log(data);
        window.location.pathname = 'index.html'
    })
    .catch(err =>{
        console.log(err);
    })
});