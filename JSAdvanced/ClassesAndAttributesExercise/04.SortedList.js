class List{
    #list;
    
    constructor(){
        this.#list = [];
        this.size = this.#list.length;
    }

    add(element){
        this.#list.push(element);
        this.#list.sort((a, b) => a - b);
        this.size++;
    }
    remove(index){
        if (index < 0 || index >= this.size) {
            return;
        }
        this.#list.splice(index,1);
        this.#list.sort((a, b) => a - b);
        this.size--;
    }
    get(index){
        if (index < 0 || index >= this.size) {
            return;
        }
        return this.#list[index];
    }
}

let list = new List();
console.log(list);
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1)); 
console.log(list.size);
