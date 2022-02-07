class Stringer{
    constructor(string, length){
        this.innerString = string;
        this.innerLength = Number(length) < 0 ? 0 : Number(length);
    }

    increase(length){
        this.innerLength += Number(length);
    }
    decrease(length){
        this.innerLength -= Number(length);
        if (this.innerLength < 0) {
            this.innerLength = 0;
        }
    }

    toString(){
        let dots = this.innerLength >= this.innerString.length -1 ? '' : '...'
        return this.innerString.substring(0, Math.max(this.innerLength, 0)) + dots;
    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4); 
console.log(test.toString()); // Test
