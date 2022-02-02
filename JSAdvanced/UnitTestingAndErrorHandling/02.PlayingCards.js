function factory(face, suit){
    let faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];

    let suits = {
        S: '♠',
        H: '♥',
        D: '♦',
        C: '♣',
    }

    let currentFace = face.toString();

    if (currentFace != currentFace.toUpperCase() ||
        !faces.includes(face) ||
        !suits[suit]) {
        throw new Error();
    }

    let result = currentFace + suits[suit];

    return result;
}

console.log(factory('10', 'c'));