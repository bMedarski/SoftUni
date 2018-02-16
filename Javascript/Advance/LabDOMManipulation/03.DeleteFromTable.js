function deleteByEmail(){
    let rows = document.querySelectorAll("tr");
    let input = document.querySelector("input").value;
    let result = document.getElementById("result");
    for (let row of rows){
        if(row.children[1].innerHTML==input){
            result.innerHTML = "Deleted.";
            let parent = row.parentNode;
            console.log(parent);
            parent.removeChild(row);
            break;
        }else{
            result.innerHTML = "Not found.";
        }
    }


}