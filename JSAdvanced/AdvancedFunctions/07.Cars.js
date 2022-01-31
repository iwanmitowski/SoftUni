function solve(input){

    let cars = {};

    commands = {
        create(name){
            cars[name] = {};
        },
        set(name, key, value){
            cars[name][key] = value;
        },
        inherit(name, parentName){
            cars[name] = {};
            cars[name] = Object.create(cars[parentName]);
        },
        print(name){
            let currentCar = cars[name];
             
            let result = '';
            for (const car in currentCar) {
                result += `${car}:${currentCar[car]},`
            }
            console.log(result.slice(0, result.length - 1));
        }
    }

    input.forEach(element => {
        let splitted = element.split(' ');

        let command = element.includes('inherit') ? 'inherit' : splitted[0];

        switch (command) {
            case 'set':
                commands.set(splitted[1], splitted[2], splitted[3]);
                break;
            case 'inherit':
                commands.inherit(splitted[1], splitted[3]);
                break;
            case 'create':
                commands.create(splitted[1]);
                    break;
            case 'print':
                commands.print(splitted[1]);
                break;
        }
    });

}

solve(['create c1',
'create c2 inherit c1',
'set c1 color red',
'set c2 model new',
'print c1',
'print c2']
)