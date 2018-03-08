function solve(obj){

    if(obj.handsShaking){
        obj.handsShaking = false;
        obj.bloodAlcoholLevel = obj.bloodAlcoholLevel+(0.1*obj.experience*obj.weight);
    }

    return obj;
}
let worker = solve({ weight: 120,
        experience: 20,
        bloodAlcoholLevel: 200,
        handsShaking: true }
);

console.log(worker);