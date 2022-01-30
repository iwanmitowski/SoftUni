function solution(){
    let start = '';

    return{
        append(string){
            start+=string;
        },
        removeStart(n){
            start = start.substring(n);
        },
        removeEnd(n){
            start = start.substring(0, start.length - n);
        },
        print(){
            console.log(start);
        }
    }
}

let secondZeroTest = solution();

secondZeroTest.append('123');
secondZeroTest.append('45');
secondZeroTest.removeStart(2);
secondZeroTest.removeEnd(1);
secondZeroTest.print();
