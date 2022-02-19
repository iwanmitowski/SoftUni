function solve() {
    let firstNameElement = document.getElementById('fname');
    let lastNameElement = document.getElementById('lname');
    let emailElement = document.getElementById('email');
    let birthElement = document.getElementById('birth');
    let positionElement = document.getElementById('position');
    let salaryElement = document.getElementById('salary');

    let addWorkerBtn = document.getElementById('add-worker');
    let tableElement = document.querySelector('#tbody');

    addWorkerBtn.addEventListener('click', (e)=>{
        e.preventDefault();
        console.log(1);
        let fname = firstNameElement.value;
        let lname = lastNameElement.value;
        let email = emailElement.value;
        let birth = birthElement.value;
        let position = positionElement.value;
        let salary = Number(salaryElement.value);

        if (!fname ||
            !lname ||
            !email ||
            !birth ||
            !position ||
            !salary) {
            return;
        }

        let trElement = document.createElement('tr');
        let fnameTd = document.createElement('td');
        let lnameTd = document.createElement('td');
        let emailTd = document.createElement('td');
        let birthTd = document.createElement('td');
        let positionTd = document.createElement('td');
        let salaryTd = document.createElement('td');
        let actionTd = document.createElement('td');

        let firedBtn = document.createElement('button');
        let editBtn = document.createElement('button');

        firedBtn.textContent = 'Fired';
        editBtn.textContent = 'Edit';

        actionTd.appendChild(firedBtn);
        actionTd.appendChild(editBtn);

        firedBtn.classList.add('fired');
        editBtn.classList.add('edit');

        fnameTd.textContent = fname;
        lnameTd.textContent = lname;
        emailTd.textContent = email;
        birthTd.textContent = birth;
        positionTd.textContent = position;
        salaryTd.textContent = salary;

        let budgetElement = document.getElementById('sum');

        editBtn.addEventListener('click', (e)=>{
            let parentElement = e.currentTarget.parentNode.parentNode.children;

            let currentSum = Number(budgetElement.textContent);
            let subtracted = currentSum - salary;
            budgetElement.textContent = subtracted.toFixed(2);

            console.log(parentElement);
            let val1 = parentElement[0].textContent;
            let val2 = parentElement[1].textContent;
            let val3 = parentElement[2].textContent;
            let val4 = parentElement[3].textContent;
            let val5 = parentElement[4].textContent;
            let val6 = parentElement[5].textContent;

            firstNameElement.value = val1;
            lastNameElement.value = val2;
            emailElement.value = val3;
            birthElement.value = val4;
            positionElement.value = val5;
            salaryElement.value = val6;

            e.currentTarget.parentElement.remove();
        });
        

        firedBtn.addEventListener('click', (e)=>{
            let currentSum = Number(budgetElement.textContent);
            let subtracted = currentSum - salary;
            budgetElement.textContent = subtracted.toFixed(2);
            e.currentTarget.parentNode.parentNode.remove();
        });

        trElement.appendChild(fnameTd);
        trElement.appendChild(lnameTd);
        trElement.appendChild(emailTd);
        trElement.appendChild(birthTd);
        trElement.appendChild(positionTd);
        trElement.appendChild(salaryTd);
        trElement.appendChild(actionTd);

        tableElement.appendChild(trElement);

        let totalSum = Number(budgetElement.textContent) + salary;
        budgetElement.textContent = totalSum.toFixed(2);

        firstNameElement.value = '';
        lastNameElement.value = '';
        emailElement.value = '';
        birthElement.value = '';
        positionElement.value = '';
        salaryElement.value = '';
    });
}   
solve()