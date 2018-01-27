function Solve(args){
    let result = [];

    for(let i = 0; i<args.length;i++){
        if(args[i]<0){
            result.unshift(args[i]);
        }else{
            result.push(args[i]);
        }
    }

    for(let i = 0; i<args.length;i++){
        console.log(result[i])
    }
}

Solve([7, -2, 8, 9]);