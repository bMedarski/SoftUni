function loadCommits() {
    $("#commits").empty();
    const USERNAME = $('#username').val();
    const REPOSITORY = $('#repo').val();
    const URL = `https://api.github.com/repos/${USERNAME}/${REPOSITORY}/commits`;

    $.ajax({
        method: 'GET',
        url: URL
    }).then(function (res) {
        for (let i of res) {
            $('#commits').append(
                $(`<li>${i.commit.author.name}: ${i.commit.message}</li>`)
            )
        }

    }).catch(function (err) {
        $('#commits').append(
                       $(`<li>Error: ${err.status} (${err.statusText})</li>`)
                   )
    })
}