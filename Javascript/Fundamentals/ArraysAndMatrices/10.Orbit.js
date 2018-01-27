function Solve(arguments){
    let row = arguments[0];
    let col = arguments[1];
    let x = arguments[2];
    let y = arguments[3];
    var matrix = [];
    for(let i=0; i<row; i++) {
        matrix[i] = new Array(col);
    }

    for (let i = 0; i < row; i++) {
        for (let j = 0; j < col; j++) {
            if(i==x&&j==y){
                matrix[i][j]= 1;
            }else{
                matrix[i][j]= 0;
            }

        }
    }
    for (let i = 0; i < matrix[0].length; i++) {
        console.log(matrix[i].join(" "))
    }
}

Solve([4, 4, 0, 0]);