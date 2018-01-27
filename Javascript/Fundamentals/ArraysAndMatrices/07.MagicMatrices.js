function Solve(arguments){
    let sum = 0;

    for (let i = 0; i < arguments.length; i++) {
        sum+=arguments[i][0];
    }
    for (let i = 0; i < arguments.length; i++) {
        let current = 0;
        for (let j = 0; j < arguments[0].length; j++) {
            current+=arguments[i][j];
        }
        if(sum!=current){
            return false
        }
    }
    for (let i = 0; i < arguments[0].length; i++) {
        let current = 0;
        for (let j = 0; j < arguments.length; j++) {
            current+=arguments[i][j];
        }
        if(sum!=current){
            return false
        }
    }
    return true;
    //console.log("t")
}



Solve([[4, 5, 6],
        [6, 5, 4],
        [5, 5, 5]]
);

Solve([[11, 32, 45],
        [21, 0, 1],
        [21, 1, 1]]
);