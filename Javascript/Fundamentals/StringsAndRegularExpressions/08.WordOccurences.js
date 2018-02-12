function Solve(text,word){
        text = text.toLowerCase();
        const regex = new RegExp("\\b" + word + "\\b", "g");
        let count = 0;
        let m;
        while ((m = regex.exec(text)) !== null) {

            if (m.index === regex.lastIndex) {
                regex.lastIndex++;
            }
            m.forEach((match) => {
                count++;
            });
        }
        console.log(count);
}
Solve('The waterfall was so high, that the child couldn’t see its peak.0','the');
Solve('How do you plan on achieving that? How? How can you even think of that?','how');