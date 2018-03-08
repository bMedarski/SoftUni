function printDeckOfCards(cards) {

    function makeCard(face, suit) {
        const validFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
        const validSuits = ['S', 'H', 'D', 'C'];
        let suitAsChar = {
            'S': '\u2660',
            'H': '\u2665',
            'D': '\u2666',
            'C': '\u2663',
        };

        if (!validFaces.includes(face)) throw Error('Invalid face!');
        if (!validSuits.includes(suit)) throw Error('Invalid suit!');

        let card = {
            face: face,
            suit: suit,
            toString: () => {
                return `${card.face}${suitAsChar[card.suit]}`;
            }

        };

        return card;
    }

    let result = [];
    for (let cardInfo of cards) {

        let suit = cardInfo[cardInfo.length - 1];
        let face = cardInfo.substring(0, cardInfo.length - 1);
        try {
            result.push(makeCard(face, suit));

        } catch (error) {
            console.log(`Invalid card: ${cardInfo}`);
            return;
        }
    }

    console.log(result.join(' '));
}
