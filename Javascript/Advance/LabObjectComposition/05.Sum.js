function getModel() {
    let selectorOne;
    let selectorTwo;
    let selectorResult;

    function init(selector1, selector2, resultSelector) {
        selectorOne = $(selector1);
        selectorTwo = $(selector2);
        selectorResult = $(resultSelector);
    }

    function add() {
        selectorResult.val(Number(selectorOne.val()) + Number(selectorTwo.val()));
    }

    function subtract() {
        selectorResult.val(Number(selectorOne.val()) - Number(selectorTwo.val()));
    }

    return {
        init,
        add,
        subtract
    };
}