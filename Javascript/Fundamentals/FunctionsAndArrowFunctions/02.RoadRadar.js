function Solve(input){

    let speed = input[0];
    let area = input[1] ;

    function GetMaxSpeed(area){
        if(area=="motorway"){
            return 130;
        }else if(area=="interstate"){
            return 90;
        }else if(area=="city"){
            return 50;
        }else if(area=="residential"){
            return 20
        }
    }
    let limit = GetMaxSpeed(area);
//console.log(speed);
   // console.log(limit);
    function isSpeeding(speed,limit){
            if(speed<=limit){
                return "";
            }else if(speed<=limit+20){
                return "speeding";
            }
            else if(speed<=limit+40){
                return "excessive speeding";
            }else{
                return "reckless driving";
            }
    }
    return isSpeeding(speed,limit);
}
//console.log(Solve([40, 'city']));
console.log(Solve([21, 'residential']));
console.log(Solve([120, 'interstate']));
console.log(Solve([200, 'motorway']));