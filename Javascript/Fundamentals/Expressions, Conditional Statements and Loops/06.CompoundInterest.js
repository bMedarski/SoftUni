function Solve(args){
    let p = args[0];
    let i = args[1];
    let n = args[2];
    let t = args[3];
    let a = (p* Math.pow((1 + (i/n)), (n*t)));
    console.log(a)
}

Solve([1500, 4.3, 3, 6]);
Solve([100000, 5, 12, 25]);