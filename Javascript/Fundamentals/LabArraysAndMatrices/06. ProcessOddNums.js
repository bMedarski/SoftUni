function Solve(args){

    let result = [];
    for (let i = 0; i < args.length; i++) {
        if(i%2!=0){
            result.unshift(args[i]*2);
        }
    }
    console.log(result.join(" "))
}

Solve([10, 15, 20, 25]);