function Solve(str){
    const regex = /\b[0-9]{1,2}-[A-Z]{1}[a-z]{2}-[0-9]{4}\b/g;
    for (let i = 0; i < str.length; i++) {
        let m;
        while ((m = regex.exec(str[i])) !== null) {
            if (m.index === regex.lastIndex) {
                regex.lastIndex++;
            }
            let date = m[0].split('-');
            console.log(`${m[0]} (Day: ${date[0]}, Month: ${date[1]}, Year: ${date[2]})`);
        }
    }
}

Solve(['I am born on 30-Dec-1994.','This is not date: 512-Jan-1996.','My father is born on the 29-Jul-1955.']);