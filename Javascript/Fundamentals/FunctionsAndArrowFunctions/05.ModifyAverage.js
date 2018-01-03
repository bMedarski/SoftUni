function Solve(input){


    function digitSum(string){
        let sum = 0;
        for(let i=0;i<inputString.length;i++){
            sum+=inputString[i]*1;
        }
        return sum;
    }
    let inputString = ""+input;

    //console.log(sum);
    while(true){
        let length = inputString.length;
        let sum = digitSum(inputString);
        if(sum/length>5){
            break
        }else{
            inputString+=9;

        }
    }
    console.log(inputString);
}

Solve(101);
//Solve(5468);