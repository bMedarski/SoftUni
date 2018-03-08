let myModule = (function () {
    let Suits = {
        SPADES: '?',
        HEARTS: '?',
        DIAMONDS: '?',
        CLUBS: '?'
    };
    let Faces = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];

    class Card {
        constructor(face, suit) {
            this.face = face;
            this.suit = suit;
        }

        get face() {
            return this._face;
        }

        set face(value) {
            if (!Faces.includes(value)) {
                throw new Error('Invalid card face:' + value);
            }
            this._face = value;
        }

        get suit() {
            return this._suit;
        }

        set suit(value) {
            if (!Object.keys(Suits).map(k => Suits[k]).includes(value)) {
                throw new Error('Invalid card suit:' + suit);
            }
            this._suit = value;
        }

        toString() {
            return this.face + this.suit;
        }
    }

    return { Suits, Card };
}());