function solve(...arguments){
    let appearance = {};

    arguments.forEach(e => {

        let type = typeof(e);

            console.log(`${type}: ${e}`);
            if (!appearance[type]) {
                appearance[type] = 0
            }
            
            appearance[type]++;
    });

    Object.keys(appearance)
        .sort((a, b) => appearance[b] - appearance[a])
        .forEach(key => console.log(`${key} = ${appearance[key]}`));
}

solve({ name: 'bob'}, 'cat', 42, function () { console.log('Hello world!'); });