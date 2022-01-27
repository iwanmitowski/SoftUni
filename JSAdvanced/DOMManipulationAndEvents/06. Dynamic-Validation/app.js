function validate() {
    let inputElement = document.getElementById('email');
    let regex = /^[a-z_]+@[a-z_]+\.[a-z]+$/;

    

    inputElement.addEventListener('change', function(e){
        if (regex.test(inputElement.value)) {
            e.currentTarget.classList.remove('error')
        }
        else{
            e.currentTarget.classList.add('error');
        }
    })
}