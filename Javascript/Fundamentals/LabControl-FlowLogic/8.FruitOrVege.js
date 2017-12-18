function Solve(item) {

    let fruits = new Array("banana", "apple", "kiwi", "cherry", "lemon", "grapes", "peach");
    let vegetables = new Array("tomato", "cucumber", "pepper", "onion", "garlic", "parsley");

    if(fruits.indexOf(item)!=-1){
        return "fruit"
    }else if(vegetables.indexOf(item)!=-1){
        return "vegetable"
    }else{
        return "unknown"
    }
}
console.log(Solve("banana"));
