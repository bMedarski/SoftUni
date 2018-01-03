function Solve(args){

    let inverseSum = 0;
    for(let i = 0; i<args.length;i++){
        inverseSum += 1/args[i];
    }
    console.log(args.reduce((a, b) => a + b, 0));
    console.log(inverseSum);
    console.log(args.join(""))
}
Solve([1, 2]);
Solve([1, 2, 3]);
Solve([2, 4, 8, 16]);