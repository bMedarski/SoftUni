function increment(input) {
    let parent = $(input);
    let textArea = $("<textarea>").addClass("counter").val(0).attr("disabled",true);
    let btn1 = $("<button>").addClass("btn").attr('id', 'incrementBtn').text("Increment").on('click',AddOne);
    let btn2 = $("<button>").addClass("btn").attr('id', 'addBtn').text("Add").on("click",AddLi);
    let ul = $("<ul>").addClass("results");


    parent.append(textArea);
    parent.append(btn1);
    parent.append(btn2);
    parent.append(ul);


    function AddOne(){
        let count = Number(textArea.val());

        textArea.val(null);
        textArea.val(count+1);
    }

    function AddLi(){
        let text = textArea.val();
        let li = $("<li>").text(text);
        ul.append(li);
    }
}
