(() => {
    let counter = 0;
    return class Extensible {

        constructor() {
            this.id = counter;
            counter++;
        }

        extend(template) {
            for (let parentProp of Object.keys(template)) {
                if (typeof (template[parentProp]) == "function") {
                    Object.getPrototypeOf(this)[parentProp] = template[parentProp];
                } else {
                    this[parentProp] = template[parentProp];
                }
            }
        }

    }
})();

let extensible=(function () {
    let id = 0;

    return class Extensible {
        constructor() {
            this.id = id++;
        }

        extend(template) {
            for (let prop of template) {
                if (typeof template[prop] === "function") {
                    Extensible.prototype[prop] = template[prop];
                } else {
                    this[prop] = template[prop];
                }
            }
        }
    };
})();
