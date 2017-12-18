function Solve(n){

    let color = "black";

    console.log("<div class=\"chessboard\">");
    for(let i = 1;i<=n;i++){
        console.log("<div>");
        for(let j = 1;j<=n;j++){

            if(color=="black"){
                console.log("    <span class=\"black\"></span>");
                color = "white";
            }
            else if(color=="white"){
                console.log("    <span class=\"white\"></span>");
                color = "black";
            }

        }
        if(n%2==0){
            if(i%2==0){
                color = "black";
            }else{
                color = "white";
            }

        }
        console.log("</div>");
    }
    console.log("</div>");
}
//Solve(2);
//Solve(3);
Solve(4);