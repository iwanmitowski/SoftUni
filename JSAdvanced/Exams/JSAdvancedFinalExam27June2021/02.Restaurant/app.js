class Restaurant{
    constructor(budgetMoney){
        this.budgetMoney = budgetMoney;
        this.menu = {};
        this.stockProducts = {};
        this.history = [];
    }

    loadProducts(products){
        products.forEach(productInput => {
            let [productName, productQuantity, productTotalPriceVal] = productInput.split(' ');
            let productTotalPrice = Number(productTotalPriceVal);
            
            if (productTotalPrice <= this.budgetMoney) {
                if (!this.stockProducts[productName]) {
                    this.stockProducts[productName] = 0;
                }
                this.stockProducts[productName] +=  Number(productQuantity);

                this.budgetMoney -= productTotalPrice

                this.history.push(`Successfully loaded ${productQuantity} ${productName}`);
            }
            else{
                this.history.push(`There was not enough money to load ${productQuantity} ${productName}`);
            }
        });

        return this.history.join('\n'); 
    }

    addToMenu(meal, neededProducts, price){
        if (this.menu[meal]) {
            return `The ${meal} is already in the our menu, try something different.`
        }
        
        let products = [];

        neededProducts.forEach(productInput =>{
            let [productName, productQuantityVal] = productInput.split(' ');
            
            let quanity = Number(productQuantityVal);

            products.push([productName, quanity]);
        })

        this.menu[meal] ={
            products,
            price,
        }

        let menuItems = Object.keys(this.menu).length;

        if (menuItems == 1) {
            return `Great idea! Now with the ${meal} we have 1 meal in the menu, other ideas?`
        }
        
        return `Great idea! Now with the ${meal} we have ${menuItems} meals in the menu, other ideas?`
    }

    showTheMenu(){
        let result = [];
        
        Object.keys(this.menu).forEach(key =>{
            result.push(`${key} - $ ${this.menu[key].price}`);
        })

        if (result.length == 0) {
            result.push("Our menu is not ready yet, please come later...");
        }

        return result.join('\n');
    }

    makeTheOrder(meal){
        let currentMeal = this.menu[meal];

        if (!currentMeal) {
            return `There is not ${meal} yet in our menu, do you want to order something else?`
        }

        let areAllContained = currentMeal.products.every(([product, quanity]) => this.stockProducts.hasOwnProperty(product) && this.stockProducts[product] >= quanity);

        if (areAllContained) {

            currentMeal.products.forEach(([product, quantity]) => {
                this.stockProducts[product] - quantity;
            });
            
            this.budgetMoney += currentMeal.price;

            return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${currentMeal.price}.`
        }
    }
}

let kitchen = new Restaurant(1000);
console.log(kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99));
console.log(kitchen.addToMenu('Pizza', ['Flour 0.5', 'Oil 0.2', 'Yeast 0.5', 'Salt 0.1', 'Sugar 0.1', 'Tomato sauce 0.5', 'Pepperoni 1', 'Cheese 1.5'], 15.55));

console.log(kitchen.showTheMenu());
kitchen.loadProducts(['Yogurt 30 3', 'Honey 50 4', 'Strawberries 20 10', 'Banana 5 1']);
kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99);
console.log(kitchen.makeTheOrder('frozenYogurt'));
