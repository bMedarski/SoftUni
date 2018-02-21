function addItem() {

    let text = document.querySelector("#newItemText");
    let value = document.querySelector("#newItemValue");

    let newOption = document.createElement("option");

    newOption.textContent = text.value;
    newOption.value = value.value;
    text.value = "";
    value.value = "";
    let menu = document.querySelector("#menu");
    menu.appendChild(newOption);

}
