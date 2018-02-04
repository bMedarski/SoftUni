function Solve(str){
    const regex = /-*\d+\s*\*\s*-*\d.\d+/gm;
    let m;

    while ((m = regex.exec(str)) !== null) {
        // This is necessary to avoid infinite loops with zero-width matches
        if (m.index === regex.lastIndex) {
            regex.lastIndex++;
        }

        // The result can be accessed through the `m`-variable.
        m.forEach((match, groupIndex) => {
            let nums = match.split('*').map(g=>g.trim());
            //console.log(nums[0]);
            //console.log(nums[1]);
            let sum = 1*nums[0]*nums[1];
            str = str.replace(match,sum);

            //console.log(`Found match, group ${groupIndex}: ${match}`);
        });
    }
    console.log(str);
}

//Solve('My bill: 2*2.50 (beer); 2* 1.20 (kepab); -2  * 0.5 (deposit).');
Solve('My bill is: 4 * 2.50 (beer); 12* 1.50 (kepab); 1  *4.50 (salad); 2  * -0.5 (deposit).');