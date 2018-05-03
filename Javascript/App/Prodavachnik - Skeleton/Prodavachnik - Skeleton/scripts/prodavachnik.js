const BASE_URL = 'https://baas.kinvey.com/';
const APP_KEY = 'kid_r122UegsM';
const APP_SECRET = '13286b5479594d6b99b444960b230b80';
const AUTH_HEADERS = {'Authorization': "Basic " + btoa(APP_KEY + ":" + APP_SECRET)};
const BOOKS_PER_PAGE = 10;

function startApp() {
    showHideMenuLinks();
    showView('viewHome');
    attachEvents();
}
function attachEvents() {
    $('#linkHome').on('click', showHomeView);
    $('#linkLogin').on('click', showLoginView);
    $('#linkRegister').on('click', showRegisterView);
    $('#linkListAds').on('click', ListAdds);
    $('#linkCreateAd').on('click', CreateAdd);
    $('#linkLogout').on('click', logoutUser);
    $('#buttonLoginUser').on('click', Login);
    $('#buttonRegisterUser').on('click', Register);
    $('#buttonCreateAd').on('click', Create);
}
function Create() {
    let title = $('#formCreateAd input[name="title"]').val();
    let description = $('#formCreateAd textarea[name="description"]').val();
    let date = $('#formCreateAd input[name="datePublished"]').val();
    let price = $('#formCreateAd input[name="price"]').val();
    let publisher = sessionStorage.getItem('username');
    let user = {'Authorization': "Kinvey " + sessionStorage.getItem('authToken')};
    $.ajax({
        method: 'POST',
        url: BASE_URL + 'appdata/' + APP_KEY + '/products',
        headers: user,
        data: {title, description, date, price, publisher}
    }).then(function () {
        showInfo('Book created.');
        ListAdds();
    }).catch(function (err) {
        handleAjaxError(err)
    })
}
function ListAdds() {

    let user = {'Authorization': "Kinvey " + sessionStorage.getItem('authToken')};
    $.ajax({
        method: 'GET',
        url: BASE_URL + 'appdata/' + APP_KEY + '/products',
        headers: user
    }).then(function (res) {
        let rows = $('#ads>table>tbody').children();
        for (let row = 0; row < rows.length; row++) {
            if (row > 0) {
                $(rows[row]).remove();
            }
        }
        let products = res.reverse();
        if (products.length === 0) {
            $('h1.viewAds').hide();
            $('#ads').hide();
            $('#viewAds').append(
                $('<p>Advertisements</p>')
            ).append(
                $('<p>No advertisements available</p>')
            )
        } else {
            let table = $('#ads>table>tbody');
            for (let p of products) {
                let r = $('<tr>').attr('id', p._id);
                let title = $(`<td>${p.title}</td>`);
                let desc = $(`<td>${p.description}</td>`);
                let publisher = $(`<td>${p.publisher}</td>`);
                let date = $(`<td>${p.date}</td>`);
                let price = $(`<td>${p.price}</td>`);
                let buttons = $(`<td>$`).append(
                    $('<a href="#">[Delete]</a>').on('click', function(){
                        deleteProduct(p._id)
                    })
                ).append(
                    $('<a href="#">[Edit]</a>').on('click', function(){
                        editProduct(p);
                    })
                );
                r.append(title);
                r.append(publisher);
                r.append(desc);
                r.append(date);
                r.append(price);
                if (p._acl.creator == sessionStorage.getItem('id')) {
                    r.append(buttons);
                }
                table.append(r);
            }
            showView('viewAds');
        }
    }).catch(function (err) {
        handleAjaxError(err)
    })
}
function editProduct(p) {
    showView('viewEditAd');
    let user = {'Authorization': "Kinvey " + sessionStorage.getItem('authToken')};

   console.log(p);

    $.ajax({
            method: 'PUT',
            url: BASE_URL + 'appdata/' + APP_KEY + '/products/' + p._id,
            headers: user
        }).then(function () {
            showInfo('Book deleted.');
            ListAdds();
        }).catch(function (err) {
            handleAjaxError(err);
        });


}
function deleteProduct(id) {
    let user = {'Authorization': "Kinvey " + sessionStorage.getItem('authToken')};
    $.ajax({
        method: 'DELETE',
        url: BASE_URL + 'appdata/' + APP_KEY + '/products/' + id,
        headers: user
    }).then(function () {
        showInfo('Book deleted.');
        ListAdds();
    }).catch(function (err) {
        handleAjaxError(err);
    });
}
function CreateAdd() {
    $('#formCreateAd').trigger('reset');
    showView('viewCreateAd');
}
function showView(viewName) {
    $('main > section').hide();
    $('#' + viewName).show();
}
function showHomeView() {
    showView('viewHome');
}
function showLoginView() {
    $('#formLogin').trigger('reset');
    showView('viewLogin');
}
function showRegisterView() {
    $('#formRegister').trigger('reset');
    showView('viewRegister');
}
function showHideMenuLinks() {
    $("#linkHome").show();
    if (sessionStorage.getItem('authToken') === null) {
        $("#linkLogin").show();
        $("#linkRegister").show();
        $("#linkListAds").hide();
        $("#linkCreateAd").hide();
        $("#linkLogout").hide();
    } else {
        $("#linkLogin").hide();
        $("#linkRegister").hide();
        $("#linkListAds").show();
        $("#linkCreateAd").show();
        $("#linkLogout").show();
        $('#loggedInUser').text("Welcome, " + sessionStorage.getItem('username') + "!").show();

    }
}
function handleAjaxError(response) {
    let errorMsg = JSON.stringify(response);
    if (response.readyState === 0)
        errorMsg = "Cannot connect due to network error.";
    if (response.responseJSON && response.responseJSON.description)
        errorMsg = response.responseJSON.description;
    showError(errorMsg)
}
function showError(errorMsg) {
    let errorBox = $('#errorBox');
    errorBox.text("Error: " + errorMsg);
    errorBox.show();
}
function Login() {
    let username = $('#formLogin input[name=username]').val();
    let password = $('#formLogin input[name=passwd]').val();
    $.ajax({
        method: 'POST',
        url: BASE_URL + 'user/' + APP_KEY + '/login',
        headers: AUTH_HEADERS,
        data: {username, password}
    }).then(function (res) {
        signInUser(res, 'Login successful.');
    }).catch(function (err) {
        handleAjaxError(err)
    });
}
function showInfo(message) {
    let infoBox = $('#infoBox');
    infoBox.text(message);
    infoBox.show();
    setTimeout(function () {
        $('#infoBox').fadeOut()
    }, 3000)
}
function Register() {
    let username = $('#formRegister input[name=username]').val();
    let password = $('#formRegister input[name=passwd]').val();
    $.ajax({
        method: 'POST',
        url: BASE_URL + 'user/' + APP_KEY + '/',
        headers: AUTH_HEADERS,
        data: {username, password}
    }).then(function (res) {
        signInUser(res, 'Registration successful.');
    }).catch(function (err) {
        handleAjaxError(err)
    });
}
function signInUser(res, message) {
    showInfo(message);
    sessionStorage.setItem('id', res._id);
    sessionStorage.setItem('authToken', res._kmd.authtoken);
    sessionStorage.setItem('username', res.username);

    showHideMenuLinks();
    showHomeView();
}
function logoutUser() {
    sessionStorage.clear();
    $('#loggedInUser').text("");
    showHideMenuLinks();
    showHomeView();
}
$(document).on({
    ajaxStart: function () {
        $("#loadingBox").show()
    },
    ajaxStop: function () {
        $("#loadingBox").hide()
    }
});
