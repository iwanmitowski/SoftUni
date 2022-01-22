function extractText() {
    let liElements = document.querySelectorAll('#items li');
    
    let textareaElement = document.getElementById('result');
    textareaElement.value = Array.from(liElements)
                                 .map(x=>x.textContent)
                                 .join('\n');

}