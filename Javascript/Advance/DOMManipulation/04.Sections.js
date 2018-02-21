function create(sentences) {


    let content = document.querySelector("#content");
    for(let item of sentences){

        let p = document.createElement('p');
        p.innerHTML = item;
        p.style.display = "none";
        let div = document.createElement('div');
        div.addEventListener('click',Show);
        div.appendChild(p);

        content.appendChild(div);

        function Show(e){
            let child = e.target.firstChild;
            child.style.display="block";
        }
    }
}