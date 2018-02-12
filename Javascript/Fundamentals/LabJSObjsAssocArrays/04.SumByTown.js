function Solve(input){
    let towns = {};
    for (let i = 0; i < input.length; i=i+2) {

        if(towns.hasOwnProperty(input[i])){
            towns[input[i]] += Number(input[i+1]);
        }else{
            towns[input[i]] = Number(input[i+1]);
        }

    }

    var sortable = [];

    for (var town in towns) {
        sortable.push(town);
        sortable.push(towns[town]);
        //sortable.push([town, towns[town]]);
    }

    sortable.sort(function(a, b) {
        return b[1] -a[1];
    });
    let result = {};
    for (let i = 0; i < sortable.length; i=i+2) {
        result[sortable[i]] = sortable[i+1];
    }
    console.log(JSON.stringify(result));
}

Solve([
    'Sofia',
    '20',
    'Varna',
    '3',
    'Sofia',
    '5',
    'Varna',
    '4'
]);