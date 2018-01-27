function Solve(number){
    let seq = ["AT","CG","TT","AG","GG"];
    for(let i = 0; i<number; i++){
        if(i%4==0){
            console.log("**"+seq[i%5][0]+seq[i%5][1]+"**")
        }else if(i%4==1){
            console.log("*"+seq[i%5][0]+"--"+seq[i%5][1]+"*")
        }else if(i%4==2){
            console.log(seq[i%5][0]+"----"+seq[i%5][1])
        }else{
            console.log("*"+seq[i%5][0]+"--"+seq[i%5][1]+"*")
        }
    }
}

Solve(10);