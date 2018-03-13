let result = (function () {

    class Textbox {

        constructor(selector, invalRgx) {
            this._elements = $(selector);
            this.value = $(this._elements[0]).val();
            this._invalidSymbols = invalRgx;
            this.onInput();
        }

        onInput() {
            this.elements.on('input', (event) => {
                let text = $(event.target).val();
                this.value = text;
            });

        }

        get elements() {
            return this._elements;
        }

        get value() {
            return this._value;
        }
        set value(value) {
            this._value = value;
            for (let el of this.elements) {
                $(el).val(value);
            }
        }
        isValid() {
            return !this._invalidSymbols.test(this.value);
        }
    }

    class Form {

        constructor() {
            this._element = $('<div>').addClass('form');
            this.textboxes = arguments;
        }
        get textboxes() {
            return this._textboxes;
        }
        set textboxes(args) {
            if (args.some(b => !(b instanceof Textbox))) {
                throw new Error('Not type of textbox');
            }

            this._textboxes = args;
            for (let textbox of this._textboxes) {
                for (let item of textbox._elements) {
                    this._element.append($(item));
                }
            }
        }

        submit() {
            let allValid = true;
            for (let box of this._textboxes) {
                if (textbox.isValid()) {
                    for (let el of box._elements) {
                        $(el).css('border', '2px solid green');
                    }
                } else {
                    for (let el of box._elements) {
                        $(el).css('border', '2px solid red');
                    }

                    allValid = false;
                }
            }
            return allValid;
        }

        attach(selector) {
            $(selector).append($(this._element));
        }
    }

    return {
        Textbox: Textbox,
        Form: Form
    };
}());