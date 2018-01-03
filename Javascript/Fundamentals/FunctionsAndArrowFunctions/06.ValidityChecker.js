function Solve(input){

    function Distance(num1,num2,num3,num4){

        let result = Math.sqrt((num1-num3)*(num1-num3)+(num2-num4)*(num2-num4));
        if (result === parseInt(result, 10)){
            return true;
        }
        else {
            return false;
        }
    }

    if(Distance(input[0],input[1],0,0)){
        //{3, 0} to {0, 0} is valid
        console.log("{"+input[0]+", "+input[1]+"} to {0, 0} is valid")
    }else {
        console.log("{"+input[0]+", "+input[1]+"} to {0, 0} is invalid")
    }
    if(Distance(input[2],input[3],0,0)){
        //{3, 0} to {0, 0} is valid
        console.log("{"+input[2]+", "+input[3]+"} to {0, 0} is valid")
    }else {
        console.log("{"+input[2]+", "+input[3]+"} to {0, 0} is invalid")
    }
    if(Distance(input[0],input[1],input[2],input[3])){
        //{3, 0} to {0, 0} is valid
        console.log("{"+input[0]+", "+input[1]+"} to {"+input[2]+", "+input[3]+"} is valid")
    }else {
        console.log("{"+input[0]+", "+input[1]+"} to {"+input[2]+", "+input[3]+"} is invalid")
    }
}
Solve([3, 0, 0, 4]);
Solve([2, 1, 1, 1]);