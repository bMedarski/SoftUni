let validatorService = (() => {


    function isStringEqual(str1, str2) {
        return (str1 === str2)
    }

    function isLengthThan(string, length) {
        return (string.length >= length)
    }
    function isLengthLess(string, length) {
        return (string.length <= length)
    }

    function isOnlyLetters(string) {
        return /^[A-Za-z]+$/g.test(string)
    }

    function isOnlyLettersAndNumbers(string) {
        return /^[A-Za-z\d]+$/g.test(string)
    }

    function validateCreateCar(car) {

        if (!isLengthLess(car.title, CAR_TITLE_LENGTH)||car.title===undefined) {
            car.error = TITLE_REQUIREMENTS;
        }
        if (!isLengthLess(car.description, DESCRIPTION_TITLE_LENGTH_MAX)||car.description===undefined) {
                    car.error = DESCRIPTION_REQUIREMENTS;
        }
        if (!isLengthThan(car.description, DESCRIPTION_TITLE_LENGTH_MIN)||car.description===undefined) {
            car.error = DESCRIPTION_REQUIREMENTS;
        }
        if (!isLengthLess(car.model, MODEL_LENGTH_MAX)||car.model===undefined) {
            car.error = MODEL_REQUIREMENTS;
        }
        if (!isLengthThan(car.model, MODEL_LENGTH_MIN)||car.model===undefined) {
            car.error = MODEL_REQUIREMENTS;
        }
        if (!isLengthLess(car.fuel, FUEL_LEGTH_MAX)||car.fuel===undefined) {
            car.error = FUEL_REQUIREMENTS;
        }
        if (!isLengthLess(car.brand, BRAND_LENGTH_MAX)||car.brand===undefined) {
            car.error = BRAND_REQUIREMENTS;
        }
        if (!isLengthLess(car.year, YEAR_LENGTH_MAX)||car.year===undefined) {
            car.error = YEAR_REQUIREMENTS;
        }
        if (!isLengthLess(car.price, PRICE_MAX)||car.price===undefined) {
            car.error = PRICE_REQUIREMENTS;
        }
        if (!car.imageUrl.startsWith('http')) {
            car.error = IMAGEURL_REQIREMENTS;
        }

        return car
    }
    function validateRegisterFields(user) {

        if (!isStringEqual(user.password, user.repeatPass)) {
            user.error = PASSWORD_MATCH;
        }
        if (!isLengthThan(user.username, USERNAME_LENGTH)) {
            user.error = USERNAME_REQUIREMENTS;
        }
        if (!isLengthThan(user.password, PASSWORD_LENGTH)) {
            user.error = PASSWORD_REQUIREMENTS;
        }
        if (!isOnlyLetters(user.username)) {
            user.error = USERNAME_REQUIREMENTS;
        }
        if (!isOnlyLettersAndNumbers(user.password))
        {
            user.error = PASSWORD_REQUIREMENTS;
        }
        return user;
    }

    return {
        validateRegisterFields,
        validateCreateCar
    }
})();