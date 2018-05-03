function attachEvents() {
    const URL = `https://baas.kinvey.com/appdata/kid_SJjXfk2cz/`;
    const USERNAME = 'peter';
    const PASSWORD = 'p';
    const BASE_64 = btoa(USERNAME + ':' + PASSWORD);
    const AUTH = {'Authorization': 'Basic ' + BASE_64};

    $('#btnLoadPosts').on('click', function () {

        $('#posts').empty();
        $.ajax({
            method: 'GET',
            url: URL + 'posts',
            headers: AUTH
        }).then(function (res) {
            for (let i of res) {
                $('#posts').append(
                    $(`<option value="${i._id}">${i.title}</option>`)
                )
            }
        }).catch(function (err) {
            console.log(err);
        })
    });

    $('#btnViewPost').on('click', function () {
        let title = $('#post-title');
        let body = $('#post-body');
        let commentList = $('#post-comments');
        let selectedPost = $('#posts').find(":selected").attr('value');

        console.log(selectedPost);
        $.ajax({
                    method: 'GET',
                    url: URL + 'posts/'+selectedPost,
                    headers: AUTH
                }).then(function (res) {
                    body.text(res.body)
                }).catch(function (err) {
                    console.log(err);
                });
        $.ajax({
            method: 'GET',
            url: URL + `comments/?query={"post_id":"${selectedPost}"}`,
            headers: AUTH
        }).then(function (res) {
            title.text($('#posts').find(":selected").text());
            console.log(res)
            for (let i of res) {
                commentList.append(
                    $(`<li>${i.text}</li>`)
                )
            }
        }).catch(function (err) {
            console.log(err);
        })

    })
}