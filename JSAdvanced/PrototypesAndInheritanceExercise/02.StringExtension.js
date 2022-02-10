(function(){
    String.prototype.ensureStart = function(str){
        if (!this.toString().startsWith(str)) {
            return str + this;
        }

        return this.toString();
    }

    String.prototype.ensureEnd = function(str){
        if (!this.toString().endsWith(str)) {
            return this + str;
        }

        return this.toString();
    }

    String.prototype.isEmpty = function(){
        return this.length === 0;
    }

    String.prototype.truncate = function(n){
        
        if (n < 4) {
            return '.'.repeat(n);
        }
        
        if (this.length <= n) {
           return this.toString();
        }

        let lastWhitespace = this.toString().substring(0, n - 2).lastIndexOf(" ");

        return lastWhitespace !== -1 
            ? `${this.toString().substring(0, lastWhitespace)}...` 
            : `${this.toString().substring(0, n - 3)}...`;
    }

    String.format = function(str, ...params){
        
        for (let i = 0; i < params.length; i++) {
            str = str.replace(`{${i}}`, params[i]);
        }

    return str;        
    }
})();

let str = 'my string';
str = str.ensureStart('my');
str = str.ensureStart('hello ');
str = str.truncate(16);
console.log(str);
str = str.truncate(14);
console.log(str);
str = str.truncate(8);
console.log(str);
str = str.truncate(4);
console.log(str);
str = str.truncate(2);
console.log(str);
str = String.format('The {0} {1} fox',
  'quick', 'brown');
str = String.format('jumps {0} {1}',
  'dog');


