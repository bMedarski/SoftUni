function toggle() {

    let button = document.querySelectorAll(".button")[0];
    let text = document.querySelector("#extra");

    if(text.style.display==""||text.style.display=="none"){
        text.style.display = "block";
        button.textContent  = "Less";
    }else{
        text.style.display = "none";
        button.textContent  = "More";
    }
}