let form = document.getElementById('form');

let submitBtn = document.getElementById('submit');
let notification = document.querySelector('.notification');

let tableBody = document.querySelector('#results tbody');

const url = `http://localhost:3030/jsonstore/collections/students`;

function getStudents(){
    fetch(url)
        .then(res=>res.json())
        .then(data =>{
            let students = Object.values(data);

            students.forEach(s=>{
                let row = document.createElement('tr');
                let fN = document.createElement('td');
                let lN = document.createElement('td');
                let facN = document.createElement('td');
                let grd = document.createElement('td');

                fN.textContent = s.firstName;
                lN.textContent = s.lastName;
                facN.textContent = s.facultyNumber;
                grd.textContent = s.gradeNumber;

                row.appendChild(fN);
                row.appendChild(lN);
                row.appendChild(facN);
                row.appendChild(grd);

        tableBody.appendChild(row);
            });
        });
}

getStudents();

submitBtn.addEventListener('click', (e)=>{
    e.preventDefault();

    let formData = new FormData(form);

    let firstName = formData.get('firstName');
    let lastName = formData.get('lastName');
    let facultyNumber = formData.get('facultyNumber');
    let gradeNumber = formData.get('grade');

    if (!firstName ||
        !lastName ||
        !facultyNumber ||
        !gradeNumber
        ) {
        notification.textContent = 'Invalid input';
        return;
    }

    notification.textContent = '';

    let data = {
        firstName,
        lastName,
        facultyNumber,
        gradeNumber,
    }

    fetch(url, {
        method: 'post',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(data)
    })
    .then(data =>{
        tableBody.innerHTML = '';
        getStudents();
    })
    .catch(err =>{
        notification.textContent = err.message;
    })
})