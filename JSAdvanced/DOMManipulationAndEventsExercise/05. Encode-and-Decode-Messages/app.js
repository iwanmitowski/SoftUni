function encodeAndDecodeMessages() {
    let textAreaElements = document.querySelectorAll('textarea');

    let encodeTextarea = textAreaElements[0];
    let decodeTextarea = textAreaElements[1];

    let buttonElements = document.querySelectorAll('button')

    let encodeButton = buttonElements[0];
    let decodeButton = buttonElements[1];

    encodeButton.addEventListener('click', encode);
    decodeButton.addEventListener('click', decode);

    function encode(){
        let textToEncode = encodeTextarea.value;

        let newValues = [];

        for (let i = 0; i < textToEncode.length; i++) {
            let char = textToEncode.charCodeAt(i) + 1;
            newValues.push(char);
        }
        
        encodeTextarea.value = '';
        decodeTextarea.value = String.fromCharCode(...newValues);
    }

    function decode(){
        let textToEncode = decodeTextarea.value;

        let newValues = [];

        for (let i = 0; i < textToEncode.length; i++) {
            let char = textToEncode.charCodeAt(i) - 1;
            newValues.push(char);
        }
        
        decodeTextarea.value = String.fromCharCode(...newValues);
    }
}