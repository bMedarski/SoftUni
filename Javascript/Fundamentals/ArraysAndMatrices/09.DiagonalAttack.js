function Solve(arguments){
    Array.prototype.clean = function(deleteValue) {
        for (var i = 0; i < this.length; i++) {
            if (this[i] == deleteValue) {
                this.splice(i, 1);
                i--;
            }
        }
        return this;
    };
    let first = 0;
    let second = 0;

   // console.log(arguments);
    for (let i = 0; i < arguments.length; i++) {
        arguments[i] = arguments[i].trim().split(" ").clean('');
    }
    //console.log(arguments);
    //arguments = arguments.split(" ").map(Number);

    for (let i = 0; i < arguments.length; i++) {
        for (let j = 0; j < arguments[0].length; j++) {
            if(i==j){
                first+=Number(arguments[i][j]);
                //console.log(first)
            }
            if(j==arguments.length-i-1 || i==arguments[0].length-j-1){
                second+=arguments[i][j]*1;
            }

        }
    }
    if(first!=second){
        for (let i = 0; i < arguments[0].length; i++) {
            console.log(arguments[i].join(" "))
        }
    }else{
        for (let i = 0; i < arguments.length; i++) {
            for (let j = 0; j < arguments[0].length; j++) {
                if(i==j||(j==arguments.length-i-1 || i==arguments[0].length-j-1)){
                    continue;
                }else{
                    arguments[i][j]=first;
                }
            }
        }
        for (let i = 0; i < arguments[0].length; i++) {
            console.log(arguments[i].join(" "))
        }
    }
}

Solve([' 5   3  12 3  1',
        '11  4  23 2  5',
        '101 12 3  21 10',
        '1   4  5  2  2',
        '5   22 33 11 1']
);

Solve(['1 1 1',
        '1 1 1',
        '1 1 0']
);
