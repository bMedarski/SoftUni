function solve(args){

    let num = args[0].toString();
    let reverse = "";
    for (let i = num.length-1; i>=0; i-=1){

        reverse+=num[i];
    }
    console.log(reverse);

}