function extensibleObject() { 
    
    let prototype = Object.getPrototypeOf(this);

    this.extend = function(template){

        for (const key in template) {
            if (typeof template[key] == 'function') {
                prototype[key] = template[key];
            }
            else{
                this[key] = template[key];
            }
        }
    }

    return this;
} 
    