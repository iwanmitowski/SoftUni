import { html, render } from '../node_modules/lit-html/lit-html.js';

let value = null;

let table = document.querySelector('.container');
table.replaceChildren();
let users = await getData();
let studentTemplate = (students) => html`
<thead>
            <tr>
                <th>Student name</th>
                <th>Student email</th>
                <th>Student course</th>
            </tr>
        </thead>

        <tbody>
            ${students.map(x=> html`
            <tr class="${isIncluded(x)}">
                <td>${x.firstName} ${x.lastName}</td>
                <td>${x.email}</td>
                <td>${x.course}</td>
            </tr>`)}
        </tbody>

        <tfoot>
            <tr>
                <td colspan="3">
                    <input type="text" id="searchField" />
                    <button type="button" id="searchBtn">Search</button>
                </td>
            </tr>
        </tfoot>
`;
render(studentTemplate(users, ''), table);
document.querySelector("#searchBtn").addEventListener("click", onClick);


function onClick() {
    let searchField = document.getElementById('searchField');
    value = searchField.value;

    render(studentTemplate(users,value), table);
}

async function getData() {
  let request = await fetch("http://localhost:3030/jsonstore/advanced/table");
  let data = await request.json();

  let currentUsers = Object.values(data);

  return currentUsers;
}

function isIncluded(user){
    let isTrue =  user.firstName.includes(value) ||
    user.lastName.includes(value) ||
    user.email.includes(value) ||
    user.course.includes(value)
    return isTrue ? 'select' : '';
}