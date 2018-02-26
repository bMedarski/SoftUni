function search() {

    //let towns = $("#towns li").toArray().map(li => li.textContent);
    //let searchText = $("#searchText").val();
    //let count = $("#result");
    //
    //
    //let result = [];
    //if(searchText!=''){
    //    for (let i of towns) {
    //        if(i.startsWith(searchText)){
    //            result.push(i);
    //        }
    //    }
    //    count.htmlText = `"${result.length} matches found.`;
    //}
    //
    //
    //console.log(result)

    let searchText = $('#searchText').val();
    let matches = 0;
    $("#towns li").each((index, item) => {
        if (item.textContent.includes(searchText)) {
            $(item).css("font-weight", "bold");
            matches++;
        } else
            $(item).css("font-weight", "");
    });
    $('#result').text(matches + " matches found.");

}
