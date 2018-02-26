function extractText() {
    let items = $("#items li");
    let list = [];
    for (let i of items) {
        list.push(i.textContent)
    }
    let result = list.join(", ");
    $("#result").text(result);
}
