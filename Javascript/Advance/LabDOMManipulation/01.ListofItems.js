function addItem() {
    console.log("in");
    let liElement = document.createElement("li");
    let val = document.getElementById("newText").value;

    liElement.innerHTML = val+" ";
    let span = document.createElement('span');
    span.innerHTML = "<a href='#'>[Delete]</a>";
    span.firstChild.addEventListener('click', deleteItem);
    liElement.appendChild(span);
    document.getElementById("items").appendChild(liElement);
    document.getElementById('newText').value = '';
    function deleteItem(e){
        let li = e.target.parentNode.parentNode;

        li.parentNode.removeChild(li)
    }
}