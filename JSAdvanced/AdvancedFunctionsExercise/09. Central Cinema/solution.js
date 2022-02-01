function solve() {
    let inputElements = document.querySelectorAll('#container input');

    let onScreenButton = document.querySelector('#container button');
    onScreenButton.addEventListener('click', addMovie)

    let moviesSectionUlElement = document.querySelector('#movies ul');
    let archiveSectionUlElement = document.querySelector('#archive ul');

    let clearButton = document.querySelector('#archive button')
    clearButton.addEventListener('click', clear);

    function addMovie(e){
        e.preventDefault();

        let name = inputElements[0].value;
        let hall = inputElements[1].value;
        let price = Number(inputElements[2].value);
    
        if ((name.length == 0 || hall.length == 0 || inputElements[2].value.length == 0 || !price)) {
        inputElements.forEach(x => x.value = '');
            
            return;
        }

        let liElement = document.createElement('li');

        let nameSpan = document.createElement('span');
        nameSpan.textContent = name;
        liElement.appendChild(nameSpan);

        let hallStrong = document.createElement('strong');
        hallStrong.textContent = `Hall: ${hall}`;
        liElement.appendChild(hallStrong);

        let ticketsDiv = document.createElement('div');
        
        let priceStrong = document.createElement('strong');
        priceStrong.textContent = price.toFixed(2);
        ticketsDiv.appendChild(priceStrong);

        let ticketsInput = document.createElement('input');
        ticketsInput.placeholder = 'Tickets';
        ticketsDiv.appendChild(ticketsInput);

        let archiveButton = document.createElement('button');
        archiveButton.textContent = 'Archive';
        archiveButton.addEventListener('click', archive);

        ticketsDiv.appendChild(archiveButton);

        liElement.appendChild(ticketsDiv);

        moviesSectionUlElement.appendChild(liElement);

        inputElements.forEach(x => x.value = '');
    }

    function archive(e){
        e.preventDefault();
        
        let parentElements = e.currentTarget.parentNode.children;

        let price = Number(parentElements[0].textContent);
        let count = Number(parentElements[1].value);

        let totalSum = price * count;

        let liElement = document.createElement('li');

        let nameSpan = document.createElement('span');
        nameSpan.textContent = e.currentTarget.parentNode.parentNode.children[0].textContent;
        liElement.appendChild(nameSpan);
        
        let totalPriceStrong = document.createElement('strong');
        totalPriceStrong.textContent = `Total amount: ${totalSum.toFixed(2)}`;
        liElement.appendChild(totalPriceStrong);

        let deleteButton = document.createElement('button');
        deleteButton.textContent = 'Delete';
        deleteButton.addEventListener('click', deleteMovie);
        liElement.appendChild(deleteButton);

        archiveSectionUlElement.appendChild(liElement);

        parentElements = e.currentTarget.parentNode.parentNode.remove();
    }

    function deleteMovie(e){
        e.preventDefault();
        e.currentTarget.parentNode.remove();
    }

    function clear(){
        let archiveItems = Array.from(archiveSectionUlElement.children);
        archiveItems.forEach(x => x.remove());
    }
}