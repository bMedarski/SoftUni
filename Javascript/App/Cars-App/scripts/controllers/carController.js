let carController = (() => {
    async function listAll(ctx) {
        await carsService.getAll().then(function (cars) {
            ctx.cars = cars;
            let seller = sessionStorage.getItem('userId');
            for (i = 0; i < cars.length; i++) {
                if(cars[i]._acl.creator===seller){
                    cars[i].isSeller = true;
                }else{
                    cars[i].isSeller = false;
                }
            }
            ctx.isAuth = AuthService.isAuth();
            ctx.username = sessionStorage.getItem('username');
            if (cars.length===0){
                ctx.noCars = true;
            }
            ctx.loadPartials({
                footer: './templates/partials/footer.hbs',
                navigation: './templates/partials/navigation.hbs',
            }).then(function () {
                this.partial('./templates/cars/list-all.hbs');
            })
                // .catch(NotifyService.handleError)
        });

    }
    function createPost(ctx) {
        carsService.create(ctx.params)
            .then(() => {
                NotifyService.showInfo("Car Created");
                ctx.redirect('#/cars/list');
            })
            .catch(NotifyService.handleError)

    }
    function registerPost(ctx) {
                AuthService.register(ctx.params)
                    .then((userInfo) => {
                        AuthService.saveSession(userInfo);
                        NotifyService.showInfo(SUCCESSFUL_REGISTRATION);
                        ctx.redirect('#/cars/list');
                    })
            // .catch(NotifyService.handleError)
            }
    function createGet(ctx) {
        ctx.isAuth = AuthService.isAuth();
        ctx.username = sessionStorage.getItem('username');
        if (!AuthService.isAuth()) {
            ctx.loadPartials({
                footer: './templates/partials/footer.hbs',
                navigation: './templates/partials/navigation.hbs',
            }).then(function () {
                this.partial('./templates/home.hbs');
            })
            // .catch(NotifyService.handleError)
        } else {
            ctx.loadPartials({
                footer: './templates/partials/footer.hbs',
                navigation: './templates/partials/navigation.hbs',
            }).then(function () {
                this.partial('./templates/cars/create.hbs');
            })
            // .catch(NotifyService.handleError
        }
    }function editGet(ctx) {
            ctx.isAuth = AuthService.isAuth();
            ctx.username = sessionStorage.getItem('username');
            if (!AuthService.isAuth()) {
                ctx.loadPartials({
                    footer: './templates/partials/footer.hbs',
                    navigation: './templates/partials/navigation.hbs',
                }).then(function () {
                    this.partial('./templates/home.hbs');
                })
                // .catch(NotifyService.handleError)
            } else {
                ctx.loadPartials({
                    footer: './templates/partials/footer.hbs',
                    navigation: './templates/partials/navigation.hbs',
                }).then(function () {
                    this.partial('./templates/cars/edit.hbs');
                })
                // .catch(NotifyService.handleError)
            }
        }
    function editPost(ctx) {
        let brand = ctx.brand;
        let description = ctx.description;
        let fuel = ctx.fuel;
        let imageUrl = ctx.imageUrl;
        let isAuthor = true;
        let model = ctx.model;
        let price = ctx.price;
        let seller = sessionStorage.getItem('username');
        let title = ctx.title;
        let year = ctx.year;
        carsService.edit(brand,description,fuel,imageUrl,isAuthor,model,price,seller,title,year)
        }
    function remove(ctx) {
        let id = ctx.params.id;
        carsService.remove(id).then(() => {
                notify.showInfo('Car deleted.');
                ctx.redirect('#/home');
              })
              .catch(NotifyService.handleError);
    }
    async function listMy(ctx) {
        await carsService.getMy().then(function (cars) {
            ctx.cars = cars;
            let seller = sessionStorage.getItem('userId');
            for (i = 0; i < cars.length; i++) {
                if(cars[i]._acl.creator===seller){
                    cars[i].isSeller = true;
                }else{
                    cars[i].isSeller = false;
                }
            }
            ctx.isAuth = AuthService.isAuth();
            ctx.username = sessionStorage.getItem('username');
            if (cars.length===0){
                ctx.noCars = true;
            }
            ctx.loadPartials({
                footer: './templates/partials/footer.hbs',
                navigation: './templates/partials/navigation.hbs',
            }).then(function () {
                this.partial('./templates/cars/list-my.hbs');
            })
                        // .catch(NotifyService.handleError)
        });
    }
    function details(ctx) {
        let id = ctx.params.id;
        carsService.details(id).then((car)=>{
            ctx.brand = car.brand;
            ctx.description = car.description;
            ctx.imageUrl = car.imageUrl;
            ctx.fuelType = car.fuelType;
            ctx.year = car.brand;
            ctx.model = car.model;
            ctx.title = car.title;
            ctx.price = car.price;
            ctx.loadPartials({
                        footer: './templates/partials/footer.hbs',
                        navigation: './templates/partials/navigation.hbs',
                    }).then(function () {
                        this.partial('./templates/cars/details.hbs');
                    })
                        .catch(NotifyService.handleError)
        });

    }
    return {
        listAll,
        createGet,
        createPost,
        editGet,
        editPost,
        remove,
        listMy,
        details
    }
})();