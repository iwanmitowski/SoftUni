function solve(input){
    let juice = {};
    let bottles = {};

    input.forEach(element => {
        let juiceElements = element.split(' => ');
        let juiceName = juiceElements[0];
        let juceQuantity = Number(juiceElements[1]);

        if (!juice[juiceName]) {
            juice[juiceName] = 0;
        }

        juice[juiceName] += juceQuantity;

        if (juice[juiceName] - 1000 >= 0) {
            if (!bottles[juiceName]) {
                bottles[juiceName] = 0;
            }

            while(juice[juiceName] >= 1000){
                let currentBottles = Math.floor(juice[juiceName] / 1000)

                bottles[juiceName]+= currentBottles;
                juice[juiceName] -= currentBottles * 1000; 
            }
        }

    });

    Object.keys(bottles).filter(x=>x != undefined).forEach(bottle => {
        console.log(`${bottle} => ${bottles[bottle]}`);
    });
}

solve(['Kiwi => 234',
'Pear => 2345',
'Watermelon => 3456',
'Kiwi => 4567',
'Pear => 5678',
'Watermelon => 6789']

);