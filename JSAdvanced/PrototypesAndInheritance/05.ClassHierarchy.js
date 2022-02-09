class Figure{
    #allowedUnits = ['m', 'cm', 'mm'];
    units = '';

    constructor(){
        this.units = 'cm';
    }

    get area(){
    }

    changeUnits(value){
        if (this.#allowedUnits.includes(value)) {
            this.units = value;
        }
    }

    convertUnits(value) {

        if (this.units == 'm') {

            return value /= 100;

        } else if (this.units == 'mm') {

            return value *= 10;

        }

        return value;

    }
    
    toString(){
        return `Figures units: ${this.units}`
    }
}

class Circle extends Figure{
    constructor(radius){
        super();
        this.radius = radius;
    }

    get area(){
        this.radius = this.convertUnits(this.radius);
        return Math.PI * (this.radius ** 2) ;
    }

    toString(){
        return `Figures units: ${this.units} Area: ${this.area} - radius: ${this.radius}`
    }
}

class Rectangle extends Figure{
    constructor(width, height, units){
        super();
        this.width = width;
        this.height = height;
        this.changeUnits(units);
    }

    get area(){
        this.width = this.convertUnits(this.width);
        this.height = this.convertUnits(this.height);

        return this.width * this.height;
    }

    toString(){
        return `Figures units: ${this.units} Area: ${this.area} - width: ${this.width}, height: ${this.height}`;
    }
}

let c = new Circle(5);
console.log(c.area); // 78.53981633974483
console.log(c.toString()); // Figures units: cm Area: 78.53981633974483 - radius: 5

let r = new Rectangle(3, 4, 'mm');
console.log(r.area); // 1200 
console.log(r.toString()); //Figures units: mm Area: 1200 - width: 30, height: 40

r.changeUnits('cm');
console.log(r.area); // 12
console.log(r.toString()); // Figures units: cm Area: 12 - width: 3, height: 4

c.changeUnits('mm');
console.log(c.area); // 7853.981633974483
console.log(c.toString()) // Figures units: mm Area: 7853.981633974483 - radius: 50

