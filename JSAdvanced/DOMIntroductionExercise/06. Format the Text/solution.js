function solve() {
  let text = document.getElementById('input').value;
  let sentences = text.split('.').filter(x=>x != '' && x != '\n');

  let output = document.getElementById('output');
  while (sentences.length > 0) {
    let currentSentence = sentences.splice(0,3).join('.');

    if (currentSentence.length !== '' &&
        currentSentence[currentSentence.length - 1] !== '.') {
        currentSentence += '.';
    }

    let p = document.createElement("p");
    
    p.textContent = currentSentence;
    
    output.appendChild(p);
  }
}