function Solve(args){
    let even = [];
    for(let i = 0; i<args.length;i++){
        if(i%2==0){
            even.push(args[i])
        }
    }
    console.log(even.join(" "));
}

Solve(['20', '30', '40']);