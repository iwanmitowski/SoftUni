function focused() {
    let divElements = document.querySelectorAll('div input');

    let divs = Array.from(divElements);

    divs.forEach(el=>
        {
            el.addEventListener('focus', function(e){
                e.target.parentNode.classList.add('focused');
        })
            el.addEventListener('blur', function(e){
                e.target.parentNode.classList.remove('focused');
        })
    })
}