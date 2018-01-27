function Solve(args){
    let count = args.splice(0,1)[0];

    let first = args.slice(0,count);
    args.reverse();
    let last = args.slice(0,count).reverse();
    console.log(first);
    console.log(last);
}

Solve([2, 7, 8, 9]);
Solve([3, 6, 7, 8, 9]);