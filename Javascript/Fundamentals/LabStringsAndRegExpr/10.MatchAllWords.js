function Solve(input){

    console.log(input.split(/\W+/).filter(w => w!="").join("|"));
}
Solve('A Regular Expression needs to have the global flag in order to match all occurrences in the text');