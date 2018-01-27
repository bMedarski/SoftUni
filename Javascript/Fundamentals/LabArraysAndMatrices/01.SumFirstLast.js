function Solve(args){
    let sum = 0;
    sum+=args[0]*1+args[args.length-1]*1;
    return sum;
}

console.log(Solve(['20', '30', '40']));