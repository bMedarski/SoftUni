function Solve(input) {
    function reverseString(str) {
        var splitString = str.split("");
        var reverseArray = splitString.reverse();
        var joinArray = reverseArray.join("");
        return joinArray;
    }
    if(input==reverseString(input)){
        return true;
    }else{
        return false;
    }
}
