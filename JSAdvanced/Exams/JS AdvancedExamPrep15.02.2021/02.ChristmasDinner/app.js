class ChristmasDinner{
    constructor(budget){
        if (budget < 0) {
            throw new Error('The budget cannot be a negative number');
        }
        this.budget = budget;
        this.dishes = [];
        this.products = [];
        this.guests = {};
    }

    shopping(productInput){
        let [type, priceVal] = [...productInput];

        let price = Number(priceVal);

        if (this.budget < price) {
            throw new Error('Not enough money to buy this product');
        }

        this.products.push(type);
        this.budget -= price;

        return `You have successfully bought ${type}`
    }

    recipes(recipe){
        let {recipeName, productsList} = recipe;

        let areAllContained = productsList.every(p => this.products.includes(p));

        if (areAllContained) {
            this.dishes.push(recipe);

            return `${recipeName} has been successfully cooked!`
        }

        throw new Error(`We do not have this product`);
    }

    inviteGuests(name, dish){
        if (!this.dishes.find(x=>x.recipeName == dish)) {
            throw new Error('We do not have this dish');
        }

        if (this.guests[name]) {
            throw new Error('This guest has already been invited');
        }

        this.guests[name] = dish;

        return `You have successfully invited ${name}!`
    }

    showAttendance(){
        let result = [];
 
        for (let guestsKey in this.guests) {
            let name = guestsKey;
            let dish = this.guests[guestsKey];
            let products = this.dishes.find(x => x.recipeName === dish).productsList;
 
            result.push(`${name} will eat ${dish}, which consists of ${products.join(', ')}`);
        }
 
        return result.join('\n');
    }
}

let dinner = new ChristmasDinner(300);

dinner.shopping(['Salt', 1]);
dinner.shopping(['Beans', 3]);
dinner.shopping(['Cabbage', 4]);
dinner.shopping(['Rice', 2]);
dinner.shopping(['Savory', 1]);
dinner.shopping(['Peppers', 1]);
dinner.shopping(['Fruits', 40]);
dinner.shopping(['Honey', 10]);
dinner.recipes({
     recipeName: 'Oshav',
     productsList: ['Fruits', 'Honey']
});
console.log(dinner.recipes({
    recipeName: 'Folded cabbage leaves filled with rice',
    productsList: ['Cabbage', 'Rice', 'Salt', 'Savory']
})); ;
console.log(dinner.recipes({
    recipeName: 'Peppers filled with beans',
    productsList: ['Beans', 'Peppers', 'Salt']
})); ;

dinner.inviteGuests('Ivan', 'Oshav');
dinner.inviteGuests('Petar', 'Folded cabbage leaves filled with rice');
dinner.inviteGuests('Georgi', 'Peppers filled with beans');
let actual = dinner.showAttendance();
console.log(actual);