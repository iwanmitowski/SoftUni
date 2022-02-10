(function(){
    Array.prototype.last = function(){
        return this[this.length-1];
    }
    
    Array.prototype.skip = function(n){
        return this.splice(n);
    }
    
    Array.prototype.take = function(n){
        return this.slice(0, n);
    }
    
    Array.prototype.sum = function(){
        return this.reduce((a,b) => a+b, 0);
    }
    
    myArr.average = function(){
        return this.sum() / myArr.length;
    }
}());

let myArr = [1,2,3];



console.log(myArr.average());