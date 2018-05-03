function attachEvents() {

    const conditonSymbols = {
        'Sunny': '&#x2600;',
        'Partly sunny': '&#x26C5;',
        'Overcast': '&#x2601;',
        'Rain': '&#x2614;',
        'Degrees': '&#176;'
    };

    $('#submit').on('click', function () {
        let currentLocation = $('#location').val();
        const URL = 'https://judgetests.firebaseio.com/locations.json';
        $('#location').val('');
        $.ajax({
            method: 'GET',
            url: URL
        }).then(function (res) {
            let code = res.filter(l=>l.name == currentLocation)[0];
            if (code !== undefined) {
                let todayWeatherURL = `https://judgetests.firebaseio.com/forecast/today/${code.code}.json`;
                let upcomingWeatherURL = `https://judgetests.firebaseio.com/forecast/upcoming/${code.code}.json`;
                $.ajax({
                    method: 'GET',
                    url: todayWeatherURL
                }).then(function (resToday) {
                    $('#current').empty();
                    $('#current').append(
                        $(`<span class="condition symbol">${conditonSymbols[resToday.forecast.condition]}</span>`)
                    ).append(
                        $(`<span class="condition"></span>`).append(
                            $(`<span class="forecast-data">${resToday.name}</span>`)
                        ).append(
                            $(`<span class="forecast-data">${resToday.forecast.low}${conditonSymbols['Degrees']}/${resToday.forecast.high}${conditonSymbols['Degrees']}</span>`)
                        ).append(
                            $(`<span class="forecast-data">${resToday.forecast.condition}</span>`)
                        )
                    )
                }).catch(function (err) {
                    $('#forecast').text('Error')
                });
                $.ajax({
                    method: 'GET',
                    url: upcomingWeatherURL
                }).then(function (resUpcoming) {
                    $('#upcoming').empty();
                    for (let i of resUpcoming.forecast) {
                        $('#upcoming').append(
                            $(`<span class="upcoming"></span>`).append(
                                $(`<span class="forecast-data">${conditonSymbols[i.condition]}</span>`)
                            ).append(
                                $(`<span class="forecast-data">${i.low}${conditonSymbols['Degrees']}/${i.high}${conditonSymbols['Degrees']}</span>`)
                            ).append(
                                $(`<span class="forecast-data">${i.condition}</span>`)
                            )
                        )
                    }

                }).catch(function (err) {
                    $('#forecast').text('Error')
                });
                $('#forecast').show();


            }
        }).catch(function (err) {
            $('#forecast').text('Error')
        })
    });


}