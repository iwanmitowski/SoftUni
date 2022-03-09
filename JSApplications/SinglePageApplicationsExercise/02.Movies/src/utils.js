let views = [...document.querySelectorAll('.view-section')]


function hideAll(){
    views.forEach(v => v.style.display = 'none');
}

export function showView(section){
    hideAll();
    
    section.style.display = 'block';
}

export function updateNav(){
    let user = JSON.parse(localStorage.getItem('user'));
    let msgContainer = document.querySelector('#msg');
    
    if (user) {
        console.log('logged');
        document.querySelectorAll('.user').forEach(x=>x.style.display = 'inline-block');
        document.querySelectorAll('.guest').forEach(x=>x.style.display = 'none');
        msgContainer.textContent = `Welcome, ${user.email}`
    }
    else{
        document.querySelectorAll('.user').forEach(x=>x.style.display = 'none');
        document.querySelectorAll('.guest').forEach(x=>x.style.display = 'inline-block');
        msgContainer.textContent = ``
    }
}