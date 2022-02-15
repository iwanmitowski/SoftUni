window.addEventListener('load', solution);

function solution() {
    let nameElement = document.getElementById('fname');
    let emailElement = document.getElementById('email');
    let phoneElement = document.getElementById('phone');
    let addressElement = document.getElementById('address');
    let codeElement = document.getElementById('code');
    let submitBtn = document.getElementById('submitBTN');
    let editBtn = document.getElementById('editBTN');
    let continueBtn = document.getElementById('continueBTN');

    let infoPreviewElement = document.getElementById('infoPreview');
    let blockElement = document.getElementById('block');

    submitBtn.addEventListener('click', (e)=>{
      let name = nameElement.value;
      let email = emailElement.value;
      let phone = phoneElement.value;
      let address = addressElement.value;
      let code = codeElement.value;

      if (!name ||
          !email) {
        return;
      }

      e.currentTarget.setAttribute('disabled', true);

      let nameLi = document.createElement('li');
      let emailLi = document.createElement('li');
      let phoneLi = document.createElement('li');
      let addressLi = document.createElement('li');
      let codeLi = document.createElement('li');

      nameLi.textContent = `Full Name: ${name}`;
      emailLi.textContent = `Email: ${email}`;
      phoneLi.textContent = `Phone Number: ${phone}`;
      addressLi.textContent = `Address: ${address}`;
      codeLi.textContent = `Postal Code: ${code}`;

      infoPreviewElement.appendChild(nameLi);
      infoPreviewElement.appendChild(emailLi);
      infoPreviewElement.appendChild(phoneLi);
      infoPreviewElement.appendChild(addressLi);
      infoPreviewElement.appendChild(codeLi);

      editBtn.removeAttribute('disabled');
      continueBtn.removeAttribute('disabled');

      nameElement.value = '';
      emailElement.value = '';
      phoneElement.value = '';
      addressElement.value = '';
      codeElement.value = '';

      editBtn.addEventListener('click', (e)=>{
        nameElement.value = name;
        emailElement.value = email;
        phoneElement.value = phone;
        addressElement.value = address;
        codeElement.value = code;

        Array.from(infoPreviewElement.children).forEach(e => e.remove());

        submitBtn.removeAttribute('disabled');
        e.currentTarget.setAttribute('disabled', true);
        continueBtn.setAttribute('disabled', true);
      });

      continueBtn.addEventListener('click', ()=>{
        let h3Element = document.createElement('h3');

        h3Element.textContent = 'Thank you for your reservation!';
        
        blockElement.innerHTML = "";
        blockElement.appendChild(h3Element);
      });
    });

}
