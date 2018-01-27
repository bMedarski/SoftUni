function Solve(arguments){

        let result = [];
        let first = 0;
        let second = 0;

    for (let i = 0; i < arguments.length; i++) {
        for (let j = 0; j < arguments[0].length; j++) {
            if(i==j){
                first+=arguments[i][j];
            }
            if(j==arguments.length-i-1 || i==arguments[0].length-j-1){
                //console.log(arguments[i][j])
                second+=arguments[i][j];
            }

        }
    }
    result.push(first);
    result.push(second);
    console.log(result.join(" "));
}

Solve([[20, 40],
        [10, 60]]);