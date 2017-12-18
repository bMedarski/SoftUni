function Solve(args){

    let sum = 0;

    for (let i=0;i<args.length*1;i+=1) {
        sum+=args[i];
    }
    console.log("sum = " + sum);
    console.log("VAT = " + sum*0.2);
    console.log("total = " + sum*1.2);
}
Solve([1.20, 2.60, 3.50]);