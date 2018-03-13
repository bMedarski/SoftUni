function solve(){
    class Melon {
        constructor(weight, melonSort) {
            //if (new.target == Melon) {
            //    throw new TypeError('Abstract class cannot be instantiated directly');
            //}
            this.melonSort = melonSort;
            this.weight = weight;
        }

        get elementIndex() {
            return this.weight * this.melonSort.length;
        }

        toString() {
            let result = `Sort: ${this.melonSort}\nElement Index: ${this.elementIndex}`;
            return result;
        }
    }

    class Watermelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
            this.element = "Water";
        }

        toString(){
            let baseStr=super.toString();
            return `Element: ${this.element}\n`+baseStr;
        }

    }

    class Firemelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
            this.element = "Fire";
        }

        toString(){
            let baseStr=super.toString();
            return `Element: ${this.element}\n`+baseStr;
        }
    }

    class Earthmelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
            this.element = "Earth";
        }

        toString(){
            let baseStr=super.toString();
            return `Element: ${this.element}\n`+baseStr;
        }
    }

    class Airmelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
            this.element = "Air";
        }

        toString(){
            let baseStr=super.toString();
            return `Element: ${this.element}\n`+baseStr;
        }
    }

    class Melolemonmelon extends Watermelon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
        }

        morph() {
            if (this.element == "Water") {
                this.element = "Fire";
            } else if (this.element == "Fire") {
                this.element = "Earth";
            } else if (this.element == "Earth") {
                this.element = "Air";
            } else {
                this.element = "Water";
            }
        }
    }

    return{Melon,Watermelon,Airmelon,Earthmelon,Firemelon,Melolemonmelon};
}