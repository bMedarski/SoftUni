class SortedList {
    constructor() {
        this.elements = [];
        this.size=0;
    }

    add(element) {
        this.elements.push(element);
        this.elements.sort((a, b) => a - b);
        this.size++;
        return this.elements;
    }

    remove(index) {
        if (index >= 0 && index < this.elements.length) {
            this.elements.splice(index, 1);
            this.elements.sort((a, b) => a - b);
            this.size--;
            return this.elements;
        }
    }

    get(index) {
        if (index >= 0 && index < this.elements.length) {
            return this.elements[index];
        }
    }
}