let form = document.querySelector('form');

form.addEventListener('submit', (e)=>{
    e.preventDefault();
    
    let formData = new FormData(e.currentTarget);
    
    let email = formData.get('email');
    let password = formData.get('password');
    let rePass = formData.get('rePass');

    if (password !== rePass) {
        alert('Pass not match');
    }

    let data = {
        email,
        password,
        rePass,
    }

    fetch('http://localhost:3030/users/register', {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data),
    })
    .then(res =>{
        if (res.ok){
            return res.json()
        }
        
        throw new Error(res);
    })
    .then(data =>{
        console.log(data);
        sessionStorage.setItem('token', data.accessToken);
        window.location.pathname = 'index.html'
        console.log(3);
    })
    .catch(err =>{
        console.log(err);
    });
});