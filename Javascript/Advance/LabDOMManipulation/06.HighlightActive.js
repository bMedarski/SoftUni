function focus() {

    let inputFields = document.querySelectorAll("input");
    console.log(inputFields);
    for (let field of inputFields) {

        field.addEventListener("focus", function( event ) {
            event.target.parentNode.classList = "focused";
        }, true);
        field.addEventListener("blur", function( event ) {
            event.target.parentNode.classList = "";
        }, true);

}
}