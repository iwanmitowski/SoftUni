class Circle{
    #currentDiameter;
    
    constructor(radius){
        this.radius = Number(radius);
        this.#currentDiameter = Number(radius * 2);
    }

    set diameter(value){
        this.#currentDiameter = Number(value);
        this.radius = this.#currentDiameter / 2;
    }

    get diameter(){
        return this.#currentDiameter;
    }

    get area(){
        return Math.PI * this.radius * this.radius;
    }
}

let c = new Circle(2);
console.log(`Radius: ${c.radius}`);
console.log(`Diameter: ${c.diameter}`);
console.log(`Area: ${c.area}`);
c.diameter = 1.6;
console.log(`Radius: ${c.radius}`);
console.log(`Diameter: ${c.diameter}`);
console.log(`Area: ${c.area}`);
