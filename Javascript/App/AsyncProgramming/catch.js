function attachEvents() {
    const USERNAME = 'Pesho';
    const PASSWORD = '12345';
    const BASE_64 = btoa(USERNAME + ':' + PASSWORD);
    const AUTH = {'Authorization': 'Basic ' + BASE_64};
    const URL = `https://baas.kinvey.com/appdata/kid_rJApBQ0qM/biggestCatches`;
    $('button.add').on('click', function () {

        let angler = $('#addForm>input.angler').val();
        let weight = $('#addForm>input.weight').val();
        let species = $('#addForm>input.species').val();
        let location = $('#addForm>input.location').val();
        let bait = $('#addForm>input.bait').val();
        let captureTime = $('#addForm>input.captureTime').val();

        let body = {
            "angler": angler,
            "weight": weight,
            "species": species,
            "location": location,
            "bait": bait,
            "captureTime": captureTime
        };

        $.ajax({
            method: 'POST',
            url: URL,
            headers: AUTH,
            data: body
        }).then(function (res) {
            $('#addForm>input.angler').val('');
            $('#addForm>input.weight').val('');
            $('#addForm>input.species').val('');
            $('#addForm>input.location').val('');
            $('#addForm>input.bait').val('');
            $('#addForm>input.captureTime').val('');
            loadCatches();
        }).catch(function (err) {
            console.log(err);
        })
    });
    $('button.load').on('click', loadCatches);
    function loadCatches(){
        $('#main').empty();
        $('#main').append($('<legend>Catches</legend>'));
        $.ajax({
                    method: 'GET',
                    url: URL,
                    headers: AUTH
                }).then(function (res) {
                    let fieldSet = $('#main');
                    let mainDiv = $('<div id="catches"></div>');
                    for (let c of res) {
                        let div = $(`<div class="catch" data-id="${c._id}"></div>`)
                            .append($('<label>Angler</label>'))
                            .append($(`<input type="text" class="angler" value="${c.angler}"/>`))
                            .append($('<label>Weight</label>'))
                            .append($(`<input type="number" class="weight" value="${c.weight}"/>`))
                            .append($('<label>Species</label>'))
                            .append($(`<input type="text" class="species" value="${c.species}"/>`))
                            .append($('<label>Location</label>'))
                            .append($(`<input type="text" class="location" value="${c.location}"/>`))
                            .append($('<label>Bait</label>'))
                            .append($(`<input type="text" class="bait" value="${c.bait}"/>`))
                            .append($('<label>Capture Time</label>'))
                            .append($(`<input type="number" class="captureTime" value="${c.captureTime}"/>`))
                            .append($('<button class="update">Update</button>'))
                            .append($('<button class="delete">Delete</button>'));
                        fieldSet.append(mainDiv);
                        mainDiv.append(div);


                    }
                    $('div.catch>button.update').on('click', updateCatch);
                    $('div.catch>button.delete').on('click', deleteCatch);

                }).catch(function (err) {
                    console.log(err);
                })
    }
    function deleteCatch(e) {
        let id = $(e.target).parent().attr('data-id');

        $.ajax({
            method: 'DELETE',
            url: URL+'/'+id,
            headers: AUTH
        }).then(function (res) {
            loadCatches();
        }).catch(function (err) {
            console.log(err);
        })

    }

    function updateCatch(e) {
        let id = $(e.target).parent().attr('data-id');
        let parent = $(e.target).parent();
        let angler = parent.find('.angler').val();
        let weight = parent.find('.weight').val();
        let species = parent.find('.species').val();
        let location = parent.find('.location').val();
        let bait = parent.find('.bait').val();
        let captureTime = parent.find('.captureTime').val();

        let body = {
            "angler": angler,
            "weight": weight,
            "species": species,
            "location": location,
            "bait": bait,
            "captureTime": captureTime
        };
        $.ajax({
            method: 'PUT',
            url: URL + '/' + id,
            headers: AUTH,
            data: body
        }).then(function (res) {
            loadCatches();
        }).catch(function (err) {
            console.log(err);
        })
    }
}