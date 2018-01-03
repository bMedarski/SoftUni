function Solve(args)
{
    function OnTuvalu(x1,x2){

        if(x1>=1&&x1<=3&&x2>=1&&x2<=3){
            return true;
        }else{
            return false;
        }
    }
    function OnTokelau(x1,x2){
        if(x1>=8&&x1<=9&&x2>=0&&x2<=1){
            return true;
        }else{
            return false;
        }
    }
    function OnSamoa(x1,x2){
        if(x1>=5&&x1<=7&&x2>=3&&x2<=6){
            return true;
        }else{
            return false;
        }
    }
    function OnTonga(x1,x2){
        if(x1>=0&&x1<=2&&x2>=6&&x2<=8){
            return true;
        }else{
            return false;
        }
    }
    function OnCook(x1,x2){
        if(x1>=4&&x1<=9&&x2>=7&&x2<=8){
            return true;
        }else{
            return false;
        }
    }
    let length = args.length;
    for(let i=0;i<length;i+=2){

        if(OnCook(args[i],args[i+1])){
            console.log("Cook")
        }
        else if(OnTokelau(args[i],args[i+1])){
            console.log("Tokelau")
        }
        else if(OnTonga(args[i],args[i+1])){
            console.log("Tonga")
        }
        else if(OnTuvalu(args[i],args[i+1])){
            console.log("Tuvalu")
        }
        else if(OnSamoa(args[i],args[i+1])){
            console.log("Samoa")
        }else {
            console.log("On the bottom of the ocean")
        }
    }
}
Solve([4, 2, 1.5, 6.5, 1, 3]);
Solve([6, 4]);
