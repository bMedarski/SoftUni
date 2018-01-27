function Solve(args){
    //args.sort((a,b)=>a>b);
    //console.log(`${args[0]} ${args[1]}`)
    args = args.map(Number);

    console.log(args.sort((a, b) => a - b).slice(0, 2).join(" "));
}

Solve([30, 15, 50, 5]);