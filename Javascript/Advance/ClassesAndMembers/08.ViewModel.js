class Textbox {
    constructor(selector, invalRgx) {
        this._elements = $(selector);
        this.value = $(this._elements[0]).val();
        this._invalidSymbols = invalRgx;
        this.onInput();
    }

    //=> do not create contest and this is for class not for function!!!
    onInput() {
        this.elements.on('input', (event) => {
            let text = $(event.target).val();
            this.value = text;
        });
        /*other way for get correct context
         create fn onInput(){
         let that=this;
         this.elements.on('input',function(){
         let text=$(this).val();
         that.value=text;
         })
         }

         */
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