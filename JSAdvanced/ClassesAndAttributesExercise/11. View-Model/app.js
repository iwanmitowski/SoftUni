class Textbox {
    _elements;
    _invalidSymbols;
    _value;

    constructor(selector, regex){
        this._elements = document.querySelectorAll(selector);
        this._invalidSymbols = regex;
    }

    get value(){
        return this._value;
    }

    set value(val){
        this._value = val;

        for (const element of this._elements) {
            element.value = this._value;
        }
    }

    get elements(){
        return this._elements;
    }

    isValid(){
        let isValid =  !this._invalidSymbols.test(this._value);

        return isValid;
    }
}

let textbox = new Textbox(".textbox",/[^a-zA-Z0-9]/);
let inputs = document.getElementsByClassName('.textbox');
console.log(inputs);
inputs.addEventListener('click',function(){console.log(textbox.value);});
