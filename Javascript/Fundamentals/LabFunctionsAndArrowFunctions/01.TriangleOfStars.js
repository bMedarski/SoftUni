function Solve(n){

    for(let i = 1; i<=n;i++){
        console.log("*".repeat(i));
    }
    for(let i = n-1; i>=1;i--){
        console.log("*".repeat(i));
    }
}


//Solve(1);
//Solve(2);
//Solve(3);
Solve(4);