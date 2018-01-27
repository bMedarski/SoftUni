function Solve(arguments){

    let neighbours = 0;
    for (let i = 0; i < arguments.length; i++) {
        for (let j = 0; j < arguments[0].length-1; j++) {
            if(arguments[i][j]==arguments[i][j+1]){
                neighbours++;
            }
        }
    }
    for (let i = 0; i < arguments[0].length; i++) {
        for (let j = 0; j < arguments.length-1; j++) {
            if(arguments[j][i]==arguments[j+1][i]){
                neighbours++;
            }
        }
    }
    //console.log(arguments[0].length)
    console.log(neighbours)
}

Solve([['2', '3', '4', '7', '0'],
        ['4', '0', '5', '3', '4'],
        ['2', '3', '5', '4', '2'],
        ['9', '8', '7', '5', '4']]
);

Solve([['test', 'yes', 'yo', 'ho'],
        ['well', 'done', 'yo', '6'],
        ['not', 'done', 'yet', '5']]
);