function Solve(input){

    let num = input[0];

    for(let i = 1; i<input.length;i++){
        switch (input[i]){
            case "chop":
                num /= 2;
                break;
            case "dice":
                num = Math.sqrt(num);
                break;
            case "spice":
                num++;
                break;
            case "bake":
                num*=3;
                break;
            case "fillet":
                num-=num*0.2;
                break;
        }
    console.log(num);
    }
}

Solve([32, 'chop','chop','chop','chop','chop' ]);
Solve([9, 'dice', 'spice', 'chop', 'bake', 'fillet']);