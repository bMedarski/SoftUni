let carsController = (() => {

    async function listAllCars(ctx) {
        ctx.isAuth = AuthService.isAuth();
        ctx.username = sessionStorage.getItem('username');
        let id = sessionStorage.getItem('userId');
        await carsService.listAllCars()
            .then((cars)=>{
                ctx.cars = cars;
                if(cars.length ===0){
                    ctx.noCars = true;
                }
                for(let i = 0; i<cars.length;i++){
                    ctx.cars[i].id = cars[i]._id;
                    if(cars[i]._acl.creator===id){
                        ctx.cars[i].creator = true
                    }
                }
            });
            ctx.loadPartials({
                footer: './templates/partials/footer.hbs',
                nav: './templates/partials/nav.hbs',
            }).then(function () {
                this.partial('./templates/cars/list-all.hbs');
            })
    }
    async function listMyCars(ctx) {
            ctx.isAuth = AuthService.isAuth();
            ctx.username = sessionStorage.getItem('username');
            let id = sessionStorage.getItem('userId');
            await carsService.listMyCars(id)
                .then((cars)=>{
                    ctx.cars = cars;
                    if(cars.length ===0){
                        ctx.noCars = true;
                    }
                    for(let i = 0; i<cars.length;i++){
                        ctx.cars[i].id = cars[i]._id;
                    }
            });
            ctx.loadPartials({
                footer: './templates/partials/footer.hbs',
                nav: './templates/partials/nav.hbs',
            }).then(function () {
                this.partial('./templates/cars/list-my.hbs');
            })
    }
    async function detailsGet(ctx) {
        ctx.isAuth = AuthService.isAuth();
        ctx.username = sessionStorage.getItem('username');
        let id = sessionStorage.getItem('userId');
        let carId = ctx.params.id;
        await carsService.getCar(carId).then((car)=>{
            ctx.title = car.title;
            ctx.brand = car.brand;
            ctx.model = car.model;
            ctx.description = car.description;
            ctx.fuel = car.fuel;
            ctx.year = car.year;
            ctx.price = car.price;
            ctx.imageUrl = car.imageUrl;
            ctx.id = carId;
            if(car._acl.creator===id){
                ctx.creator = true
            }
        });
        ctx.loadPartials({
            footer: './templates/partials/footer.hbs',
            nav: './templates/partials/nav.hbs',
        }).then(function () {
            this.partial('./templates/cars/details.hbs');
        })
    }
    function createGet(ctx) {
        ctx.isAuth = AuthService.isAuth();
        ctx.username = sessionStorage.getItem('username');
        ctx.loadPartials({
            footer: './templates/partials/footer.hbs',
            nav: './templates/partials/nav.hbs',
        }).then(function () {
            this.partial('./templates/cars/create.hbs');
        })
    }
    function createPost(ctx) {
            ctx.isAuth = AuthService.isAuth();
            ctx.username = sessionStorage.getItem('username');
            carsService.createCar(ctx.params).then(()=>{
                ctx.redirect('#/list-all');
            })
        }
    async function editGet(ctx) {
            ctx.isAuth = AuthService.isAuth();
            ctx.username = sessionStorage.getItem('username');
            let carId = ctx.params.id;
        await carsService.getCar(carId).then((car)=>{
            ctx.title = car.title;
            ctx.brand = car.brand;
            ctx.model = car.model;
            ctx.description = car.description;
            ctx.fuel = car.fuel;
            ctx.year = car.year;
            ctx.price = car.price;
            ctx.imageUrl = car.imageUrl;
            ctx.id = carId;
        });
        ctx.loadPartials({
            footer: './templates/partials/footer.hbs',
            nav: './templates/partials/nav.hbs',
        }).then(function () {
            this.partial('./templates/cars/edit.hbs');
        })
    }
    function editPost(ctx) {
        ctx.isAuth = AuthService.isAuth();
        ctx.username = sessionStorage.getItem('username');
        carsService.editCar(ctx.params).then(()=>{
            ctx.redirect('#/list-all');
        })
    }
    function deleteGet(ctx) {
            ctx.isAuth = AuthService.isAuth();
            ctx.username = sessionStorage.getItem('username');
            let carId = ctx.params.id;
            carsService.deleteCar(carId).then(()=>{
                ctx.redirect('#/list-all');
            })
        }
    return {
        listAllCars,
        listMyCars,
        detailsGet,
        createGet,
        createPost,
        editGet,
        editPost,
        deleteGet
    }
})
();