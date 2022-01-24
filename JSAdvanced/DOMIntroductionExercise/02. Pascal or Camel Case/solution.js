function solve() {
  let text = document.getElementById('text').value;
  
  let words = text.split(' ')
                  .map(w => w.toLowerCase());
                  
  let convention = document.getElementById('naming-convention').value;

  let result;

  switch (convention) {
    case 'Camel Case':
      result = words.map((w, i) => (i == 0 ? w.slice(0,1) : w.slice(0,1).toUpperCase()) + w.slice(1)).join('');
      break;
    case 'Pascal Case':
      result = words.map(w => w.slice(0,1).toUpperCase() + w.slice(1)).join('');
      break;
    default:
      result = 'Error!';
      break;
  }

  let resultElement = document.getElementById('result');

  resultElement.innerHTML = result;
}