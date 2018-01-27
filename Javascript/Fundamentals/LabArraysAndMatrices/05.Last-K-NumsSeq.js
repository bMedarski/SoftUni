function Solve(n,k){

    let result = [1];

    while(result.length<n){
        let size = Math.min(result.length,k);
        let sum = 0;
        if(result.length<=k){
            for(let i= size-1;i>=0;i--){
                sum += result[i];
            }
        }else{
            for(let i=result.length-k;i<result.length;i++){
                sum += result[i];
            }
        }
        result.push(sum);
    }
    console.log(result)
}

Solve(6,3);
Solve(8,2);