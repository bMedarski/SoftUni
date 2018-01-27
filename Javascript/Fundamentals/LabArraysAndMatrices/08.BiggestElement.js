function Solve(arguments){
    let maxNum = -100000;
    for (let i = 0; i < arguments.length; i++) {
        for (let j = 0; j < arguments[0].length; j++) {
            //console.log(arguments[i][j]);
            if(arguments[i][j]>maxNum){
                maxNum = arguments[i][j];
            }
        }
    }
    console.log(maxNum);
}

Solve([[20, 50, 10],
        [8, 33, 145]]);