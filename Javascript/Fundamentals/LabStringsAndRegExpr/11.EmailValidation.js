function Solve(input){

    const regex = /^[a-zA-Z0-9]+@{1}[a-zA-Z]+\.[a-zA-Z]+$/g;

    if(regex.test(input)){
        console.log("Valid");
    }else{
        console.log("Invalid");
    }
}

Solve('invalid@emai1.bg1');