class Person{
    constructor(firstName, lastName){
        this.firstName = firstName;
        this.lastName = lastName;
        Object.defineProperty(this, 'fullName', {
            get(){
                return `${this.firstName} ${this.lastName}`;
            },

            set(value){
                let names = value.split(' ');

                if (names[0] && names[1]) {
                    this.firstName = names[0];
                    this.lastName = names[1];
                }
            }
        })
    }
}

let person = new Person("Peter", "Ivanov");
console.log(person.fullName); //Peter Ivanov
person.firstName = "George";
console.log(person.fullName); //George Ivanov
person.lastName = "Peterson";
console.log(person.fullName); //George Peterson
person.fullName = "Nikola Tesla";
console.log(person.firstName); //Nikola
console.log(person.lastName); //Tesla
