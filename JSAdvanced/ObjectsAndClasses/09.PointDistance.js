class Point{
    constructor(x, y){
        this.x = Number(x);
        this.y = Number(y);
    }

    static distance(p1, p2){
        let xDiff = Math.pow(p1.x - p2.x, 2);
        let yDiff = Math.pow(p1.y - p2.y, 2);

        return Math.sqrt(xDiff + yDiff);
    }
}

let p1 = new Point(5, 5);
let p2 = new Point(9, 8);
console.log(Point.distance(p1, p2));
