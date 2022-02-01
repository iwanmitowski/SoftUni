function calculator() {
    let n1;
    let n2;
    let result;

    let calculate ={
        init(n1Element, n2Element, resultElement){
            n1 = document.querySelector(n1Element);
            n2 = document.querySelector(n2Element);
            result = document.querySelector(resultElement);
        },
        add(){
            let num1 = Number(n1.value);
            let num2 = Number(n2.value);

            result.value = num1 + num2;
        },
        subtract(){
            let num1 = Number(n1.value);
            let num2 = Number(n2.value);

            result.value = num1 - num2;
        }

    }
    
    return calculate;
}
