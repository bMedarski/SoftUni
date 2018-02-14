function extractText() {
    let list = document.querySelectorAll("#items>li");
    let textArea = document.getElementById("result");

    for(let item of list){
        textArea.innerHTML+=item.innerHTML+"\n";
    }
}