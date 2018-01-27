function Solve(arguments){

    function Compare(a,b){
        if(a.length<b.length){
            return -1;
        }
        else if(a.length>b.length){
            return 1;
        }
        else{
            if(a<b){
                return -1;
            }else if(a>b){
                return 1;
            }else{
                return 0;
            }
        }
    }

    arguments.sort(Compare).forEach(a=>console.log(a));
}
Solve([ "Isacc",
    "Theodor",
    "Jack",
    "Harrison",
    "George"]

);