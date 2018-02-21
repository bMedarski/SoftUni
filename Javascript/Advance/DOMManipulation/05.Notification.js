function notify(message) {

    let notif = document.querySelector("#notification");
    notif.style.display="block";
    notif.innerHTML = message;

    setTimeout(function(){
        notif.style.display="none";
    },2000);

}
