import { towns } from './towns.js'
import { html, render } from '../node_modules/lit-html/lit-html.js';

let searchText = document.getElementById('searchText');
let townsDiv = document.getElementById('towns');
let resultDiv = document.getElementById('result');
let btn = document.querySelector('button');
let matches = 0;

btn.addEventListener('click', search);
let townsTemplate = (input) => html`
<ul>
   ${input.map(town => 
      html`<li class="${isSearched(town)}">${town}</li>`
   )}
</ul>
`;

render(townsTemplate(towns), townsDiv);

function search() {
   matches = 0;
   render(townsTemplate(towns), townsDiv);
   resultDiv.textContent = matches ? `Matches: ${matches}` : '';
}

function isSearched(town){
   let input = searchText.value.toLowerCase();
   let res;
   if (input) {
      res = town.toLowerCase().includes(input); 
   }
   if (res) {
      matches++;
   }
   return res ? 'active' : '';
}
