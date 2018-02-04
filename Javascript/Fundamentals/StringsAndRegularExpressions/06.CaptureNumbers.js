function Solve(input){
    let nums = [];
    const regex = /\d+/gm;
    for (let i = 0; i < input.length; i++) {
        let m;
        while ((m = regex.exec(input[i])) !== null) {
            // This is necessary to avoid infinite loops with zero-width matches
            if (m.index === regex.lastIndex) {
                regex.lastIndex++;
            }

            // The result can be accessed through the `m`-variable.
            m.forEach((match, groupIndex) => {
                nums.push(match);
            });
        }
    }
    console.log(nums.join(" "));
}

Solve(['The300',
    'What is that?',
    'I think it’s the 3rd movie.',
    'Lets watch it at 22:45']);


