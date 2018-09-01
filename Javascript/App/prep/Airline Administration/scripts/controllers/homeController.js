let homeController = (() => {
    function showIndexPage(ctx) {
        ctx.isAuth = AuthService.isAuth();
        ctx.username = sessionStorage.getItem('username');
        ctx.loadPartials({
            footer: './templates/common/footer.hbs',
            nav: './templates/common/nav.hbs',
        }).then(function () {
            this.partial('./templates/home.hbs');
        })
    }
    return {
      showIndexPage
    }
})();