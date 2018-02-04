function Solve(input){

    let result = input.split(/[\s\'()\.,;]+/g);
    for (let i = 0; i < result.length; i++) {
        console.log(result[i]);
    }
}

Solve('let sum = 4 * 4,b = "wow";');
Solve('let sum = 1 + 2;if(sum > 2){\tconsole.log(sum);}');