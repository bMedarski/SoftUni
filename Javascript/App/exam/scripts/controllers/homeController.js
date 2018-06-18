let homeController = (() => {

    function showIndexPage(ctx) {

        ctx.isAuth = AuthService.isAuth();
        ctx.author = sessionStorage.getItem('username');
        if (!AuthService.isAuth()) {
            ctx.loadPartials({
                login: './templates/partials/login.hbs',
                register: './templates/partials/register.hbs',
                header: './templates/partials/header.hbs',
                footer: './templates/partials/footer.hbs',
                navigation: './templates/partials/navigation.hbs',

            }).then(function () {
                this.partial('./templates/home.hbs');
            })
        } else {
            ctx.redirect('#/activeReceipt');
        }
    }

    return {
        showIndexPage
    }
})();