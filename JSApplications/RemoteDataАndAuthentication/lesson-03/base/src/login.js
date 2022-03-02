let form = document.querySelector('form');

form.addEventListener('submit', (e)=>{
    e.preventDefault();

    let formData = new FormData(e.currentTarget);

    let email = formData.get('email');
    let password = formData.get('password');

    let data = {
        email,
        password
    }

    fetch('http://localhost:3030/users/login',{
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data),
    })
    .then(res =>{
        if (res.ok){
            console.log(1);
            return res.json()
        }
        console.log(2);

        throw new Error(res);
    })
    .then(data =>{
        sessionStorage.setItem('token', data.accessToken);
        window.location.pathname = 'index.html';
    })
    .catch(err =>{
        console.log(4);

        console.log(err);
    })
});