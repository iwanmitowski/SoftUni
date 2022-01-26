function generateReport() {
    let columnElements = document.querySelectorAll('tr th');
    let checkedColumnElements = document.querySelectorAll('input[type="checkbox"]:checked');

    let allHeaders = Array.from(columnElements).map(el => el.textContent.toLowerCase());
    console.log(allHeaders);

    let checkedHeaders = Array.from(checkedColumnElements).map(el => el.parentElement.textContent.trim().toLowerCase());
    console.log(checkedHeaders);

    let result = [];

    let bodyTrElements = document.querySelectorAll('tbody tr');
    
    for (let i = 0; i < bodyTrElements.length; i++) {
        let currentRowValues = Array.from(bodyTrElements[i].children).map(x=>x.textContent);
        
        let currentObject = {};
        
        for (let i = 0; i < columnElements.length; i++) {
            let currentColumn = allHeaders[i].trim();
    
            if (checkedHeaders.includes(currentColumn)) {
                currentObject[currentColumn] = currentRowValues[i];
            }
    
        }
        
        result.push(currentObject);
    }

    result = JSON.stringify(result);

    let textareaElement = document.getElementById('output');

    textareaElement.value = result;
}