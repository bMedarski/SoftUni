function sortedList() {
    let list = (() => {
        let elements = [];
        let sorting = (a, b) => a - b;
        let add = function (element) {
            elements.push(element);
            elements.sort(sorting);
            this.size++;
            return elements;
        };
        let remove = function (index) {
            if (index >= 0 && index < elements.length) {
                elements.splice(index, 1);
                elements.sort(sorting);
                this.size--;
                return elements;
            }
        };
        let get = function (index) {
            if (index >= 0 && index < elements.length) {
                return elements[index];
            }
        };

        let size = 0;
        return { add, remove, get, size };
    })();

    return list;
}