function Solve(word, text){
    let count = 0;

    let startPoint = 0;
    let index = text.indexOf(word);
    while(index>0){
        index = text.indexOf(word,startPoint);
        if(index>0){
            count++;
            startPoint =  index+1;
        }
    }
    console.log(count)

}

Solve('ma', 'Marine mammal training is the training and caring for marine life such as, dolphins, killer whales, sea lions, walruses, and other marine mammals. It is also a duty of the trainer to do mental and physical exercises to keep the animal healthy and happy.');