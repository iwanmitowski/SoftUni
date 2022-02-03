function validate() {
    regex = /[a-z]+@[a-z]+\.[a-z]+/;

    let emailElement = document.getElementById('email');

    emailElement.addEventListener('change', validate);
    console.log(regex.test('a@a.bg'));
    function validate(){
        let email = emailElement.value;

        if (!regex.test(email)) {
            emailElement.classList.add('error');
        }
        else{
            emailElement.classList.remove('error');
        }
    }
}