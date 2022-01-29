function lockedProfile() {
    let buttonElements = document.getElementsByTagName('button');

    let buttons = Array.from(buttonElements);

    buttons.forEach(btn =>
        btn.addEventListener('click', showMore))

    function showMore(e){
        let isLocked = e.currentTarget.parentElement.children[2].checked;
        let childrenCount = e.currentTarget.parentElement.children.length;
        let fieldsContainer = e.currentTarget.parentElement.children[childrenCount - 2];
        
        if(isLocked){
            return;
        }

        if (e.currentTarget.textContent === 'Hide it') {
            fieldsContainer.style.display = 'none';
            e.currentTarget.textContent = 'Show more'
        }
        else{
            fieldsContainer.style.display = 'block';
            console.log(fieldsContainer);
    
            e.currentTarget.textContent = 'Hide it'
        }
        
    }
}