function Solve(input){

    for (let i = 0; i < input.length; i++) {
        const regex = /[\W]+/g;
        let wordsArgs = input[i].split(regex).filter(w=>w!=="");
        let words = {};
        for (let j = 0; j < wordsArgs.length; j++) {
            if(words.hasOwnProperty(wordsArgs[j])){
                words[wordsArgs[j]] += 1;
            }else{
                words[wordsArgs[j]] =1;
            }
        }
        console.log(JSON.stringify(words));
    }
}
Solve(["Far too slow, you're far too slow."]);