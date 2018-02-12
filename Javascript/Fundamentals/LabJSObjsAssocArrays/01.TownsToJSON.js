function Solve(input){

    let result = [];
    let keys = input[0].split(/\s*\|\s*/).filter(i=>i!=="");

    for (let i = 1; i < input.length; i++) {
        let [town,lat,long] = input[i].split(/\s*\|\s*/).filter(i=>i!=="");
        let obj = {};
        obj[keys[0]] = town;
        obj[keys[1]] = Number(lat);
        obj[keys[2]] = Number(long);
        result.push(obj);
    }
    console.log(JSON.stringify(result));
}