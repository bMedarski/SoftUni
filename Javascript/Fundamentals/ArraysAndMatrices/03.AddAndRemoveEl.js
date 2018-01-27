function Solve(arguments){

    let counter = 0;
    let numbers = [];
    for (let i = 0; i < arguments.length; i++) {
        if(arguments[i]=="add"){
            counter++;
            numbers.push(counter);
        }else if(arguments[i]=="remove"){
            counter++;
            numbers.pop();
        }
    }
    if(numbers.length==0){
        console.log("Empty");
    }else{
        for (let i = 0; i < numbers.length; i++) {
            console.log(numbers[i]);
        }
    }



}
//Solve(["add","add","add","add"]);
Solve(["add","add","remove","add","add"]);

Solve(["remove","remove","remove"]);
