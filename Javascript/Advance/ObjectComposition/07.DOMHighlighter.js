function domTraversal(selector) {
    let target = $(selector).children();
    if (target.length == 0) {
        $(selector).addClass("highlight");
        return;
    }
    let next = target;

    while (next.length) {
        target = next;
        next = next.children();
    }

    target.first().addClass("highlight");
    target.first().parentsUntil($(selector).parent()).addClass('highlight');

}

// get all elements without children $('*:not(:has(*))')
function domTraversalBojo(selector) {
    let deepestPath = 0;
    let deepestElement;
    let allLeaves = $(`${selector} *:not(:has(*))`);
    allLeaves.each(function (index, element) {
        let currentDeepnessLevel = 0;
        let leaf=element;
        while (element) {
            currentDeepnessLevel++;
            element = $(element).parent()[0];

        }

        if(currentDeepnessLevel>deepestPath){
            deepestPath=currentDeepnessLevel;
            deepestElement=leaf;
        }
    });

    let selectedElement=$(selector)[0];

    while(deepestElement && deepestElement!==selectedElement){
        $(deepestElement).addClass('highlight');
        deepestElement=$(deepestElement).parent()[0];
    }
    $(selector).addClass('highlight');
}