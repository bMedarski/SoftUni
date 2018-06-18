let validatorService = (() => {


    function isStringEqual(str1, str2) {
        return (str1 === str2)
    }

    function isLengthThan(string, length) {
        return (string.length > length)
    }

    function isOnlyLetters(string) {
        return /^[A-Za-z]$/g.test(string)
    }

    function isOnlyLettersAndNumbers(string) {
        return /^[A-Za-z\d]$/g.test(string)
    }


    function validateRegisterFields(user) {

        if (!isStringEqual(user.password, user.repeatPass)) {
            user.error = PASSWORD_MATCH;
        }
        if (!isLengthThan(user.username, USERNAME_LENGTH)) {
            user.error = USERNAME_REQUIREMENTS;
        }
        if (!isOnlyLetters(user.username)) {
            user.error = USERNAME_REQUIREMENTS;
        }

        //if (!/^[A-Za-z]{3,}$/g.test(user.username)) {
        //    user.error = `Username should be at least 3 characters long and contain only letters!`;
        //
        //}
        //if (user.password !== user.repeatPass) {
        //    user.error = 'Passwords should match!';
        //}
        //if (!/^[A-Za-z\d]{6,}$/.test(user.pass)) {
        //    user.error = 'Password should be at least 6 characters long and contain alphanumerical characters!';
        //}
        return user;
    }

    return {
        validateRegisterFields
    }
})();