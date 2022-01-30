function processor(input) {

    let list = [];

    listProcessor = {
        add(value){
            list.push(value);
        },
        remove(value){
            list = list.filter(x=> x != value);
        },
        print(){
            console.log(list.join(','));
        }
    }

    input.forEach(element => {
        let [command, value] = element.split(' ');

        switch (command) {
            case 'add':
                listProcessor.add(value);
                break;
            case 'remove':
                listProcessor.remove(value);
                break;
            case 'print':
                listProcessor.print();
                break;
        }
    });
}

processor(['add hello', 'add again', 'remove hello', 'add again', 'print']);
