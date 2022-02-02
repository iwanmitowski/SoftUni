function printDeckOfCards(cards) {
    function createCard (face, suit){
        
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
                throw new Error(face+''+suit);
            }
        
            let result = currentFace + suits[suit];
        
            return result;
    }
    
      try {
            let newCards = [];
            cards.forEach(card => card = newCards.push(createCard(card.substring(0, card.length-1),card.charAt(card.length - 1))));
            console.log(newCards.join(' '));
        } catch (e) {
          console.log('Invalid card: ' + e.message);
      }
  }
  

  printDeckOfCards(['5S', '3D', 'QD', '1C']);