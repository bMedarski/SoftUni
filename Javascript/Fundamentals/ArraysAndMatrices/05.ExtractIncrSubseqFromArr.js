function Solve(arguments){
    function Compare(a,b){
        return a<b;
    }
    function Compare2(a,b){
        return b-a<0
    }
    let result = arguments.filter(Compare2);
    result.forEach(a=>console.log(a));
    result = arguments.filter(Compare2);
    //result.forEach(a=>console.log(a))
}

//function Solve (arr) {
//    let biggestNum=Number(arr[0]);
//    for (let i = 0; i < arr.length; i++) {
//        if(arr[i]>=biggestNum){
//            console.log(arr[i]);
//        }
//        biggestNum=Number(arr[i]);
//    }
//}




Solve([1,
    3,
    8,
    4,
    10,
    12,
    3,
    2,
    24
]);