function Solve(input){
    let days = ["Monday","Tuesday","Wednesday","Thursday","Friday","Saturday","Sunday"];
    if(days.indexOf(input)==-1){
        console.log("error")
    }else{
        console.log(days.indexOf(input)+1)
    }
}


//Solve(1);
//Solve(2);
//Solve(3);
Solve("Friday");