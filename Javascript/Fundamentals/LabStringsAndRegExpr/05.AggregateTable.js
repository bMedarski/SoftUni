function Solve(arguments){

    let sum = 0;
    let cities = [];

    for (let i = 0; i < arguments.length; i++) {
        let line = arguments[i].trim().split('|');
        sum+= Number(line[2]);
        cities.push(line[1]);
    }
    cities = cities.map(c=>c.trim());
    console.log(cities.join(", "));
    console.log(sum);
}

Solve(['| Sofia           | 300',
        '| Veliko Tarnovo  | 500',
        '| Yambol          | 275']
);