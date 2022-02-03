function validate() {
    let usernameElement = document.getElementById('username');
    let emailElement = document.getElementById('email');
    let passwordElement = document.getElementById('password');
    let confrimPasswordElement = document.getElementById('confirm-password');
    let isCompanyElement = document.getElementById('company');
    let companyNumberElement = document.getElementById('companyNumber');
    let submitButton = document.getElementById('submit');

    submitButton.addEventListener('click', validation);

    submitButton.type = 'button';

    let companyInfoElement = document.getElementById('companyInfo');

    let isValidUsername = false;
    let isValidEmail = false;
    let isValidPassword = false;

    isCompanyElement.addEventListener('change', isChanged);
    submitButton.addEventListener('click', validation);
    
    function isChanged(){
        if (isCompanyElement.checked) {
            companyInfoElement.style.display = 'block';
        }
        else{
            companyInfoElement.style.display = 'none';
        }
    }

    function validation(e){

        let isValid = [];

        isValidUsername = /[A-Za-z0-9]{3,20}/.exec(usernameElement.value);
        isValidEmail = /^[\w\d]+@.+\..+$/.exec(emailElement.value);
        isValidPassword = passwordElement.value === confrimPasswordElement.value && /[\w]{5,15}/.exec(passwordElement.value) && /[\w]{5,15}/.exec(confrimPasswordElement.value);

        if (isValidUsername) {
            usernameElement.style.borderColor = '';
        }
        else{
            usernameElement.style.borderColor = 'red';
            isValid.push(false);
        }

        if (isValidEmail) {
            emailElement.style.borderColor = '';
        }
        else{
            emailElement.style.borderColor = 'red';
            isValid.push(false);
        }

        if (isValidPassword) {
            passwordElement.style.borderColor = '';
            confrimPasswordElement.style.borderColor = '';
        }
        else{
            passwordElement.style.borderColor = 'red';
            confrimPasswordElement.style.borderColor = 'red';
            isValid.push(false);
        }

        let isValidCompanyNumber = Number(companyNumberElement.value) < 1000 || Number(companyNumberElement.value) > 9999;
        
        if (isCompanyElement.checked) {
            if (isValidCompanyNumber) {
                companyNumberElement.style.borderColor = 'red';
                isValid.push(false);
            }
            else{
                companyNumberElement.style.borderColor = ''
            }
        }
        
        let isValidForm = !isValid.includes(false);
        
        let validElement = document.getElementById('valid')
       
        if (isValidForm) {
            validElement.style.display= 'block';
        }
        else{
            validElement.style.display = 'none'
        }
    }
}
