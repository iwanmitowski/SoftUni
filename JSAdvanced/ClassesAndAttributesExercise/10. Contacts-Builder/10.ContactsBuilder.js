class Contact{
    #online;

    constructor(firstName, lastName, phone, email){

        this.divTitleTextContent = `${firstName} ${lastName}`;
        this.phoneTextContent = `\u260E ${phone}`;
        this.emailTextContent = `\u2709 ${email}`;
        this.divTitleElement = document.createElement('div');
        this.#online = false;
    }
    
    set online(val){

        this.#online = val;

        if (val) {
            this.divTitleElement.classList.add('online');
        }
        else{
            this.divTitleElement.classList.remove('online');
        }
    }

    render(id){
        let parentElement = document.getElementById(id);

        let articleElement = document.createElement('article');

        this.divTitleElement.textContent = this.divTitleTextContent;
        this.divTitleElement.classList.add('title');

        let btnElement = document.createElement('button');
        btnElement.textContent = `\u2139`;

        btnElement.addEventListener('click', showHideInfo);

        this.divTitleElement.appendChild(btnElement);
        articleElement.append(this.divTitleElement);

        let divInfoElement = document.createElement('div');
        divInfoElement.classList.add('info');
        divInfoElement.style.display = 'none';

        let spanPhoneElement = document.createElement('span');
        spanPhoneElement.textContent = this.phoneTextContent;
        
        let spanEmailElement = document.createElement('span');
        spanEmailElement.textContent = this.emailTextContent;

        divInfoElement.appendChild(spanPhoneElement);
        divInfoElement.appendChild(spanEmailElement);

        articleElement.appendChild(divInfoElement);
        parentElement.appendChild(articleElement);

        function showHideInfo(){
            if (divInfoElement.style.display == 'block') {
                divInfoElement.style.display = 'none';
            }
            else{
                divInfoElement.style.display = 'block';
            }
        }
    }
}

let contacts = [
    new Contact("Ivan", "Ivanov", "0888 123 456", "i.ivanov@gmail.com"),
    new Contact("Maria", "Petrova", "0899 987 654", "mar4eto@abv.bg"),
    new Contact("Jordan", "Kirov", "0988 456 789", "jordk@gmail.com")
  ];
  contacts.forEach(c => c.render('main'));
  
  // After 1 second, change the online status to true
  setTimeout(() => contacts[1].online = true, 2000);
  