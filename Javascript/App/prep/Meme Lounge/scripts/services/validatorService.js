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
    function validateMeme(meme) {
            if (!isLengthLess(meme.title, MEME_TITLE)||meme.title===undefined) {
                meme.error = TITLE_REQUIREMENTS;
            }
            if (!isLengthLess(meme.description, MEME_DESCRIPTION_MAX)||meme.description===undefined) {
                meme.error = DESCRIPTION_REQUIREMENTS;
            }
            if (!isLengthThan(meme.description, MEME_DESCRIPTION_MIN)||meme.description===undefined) {
                meme.error = DESCRIPTION_REQUIREMENTS;
            }
            if (!meme.imageUrl.startsWith('http')||meme.imageUrl.length===0) {
                meme.error = IMAGE_URL_REQIREMENTS;
            }
            if (meme.title.length===0){
                meme.error = TITLE_REQUIREMENTS;
            }

        return meme;
    }
    function validateUser(user) {
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
    function validateRegisterFields(user) {
        let currentUser  = validateUser(user);
        if (!isStringEqual(currentUser.password, currentUser.repeatPass)) {
            currentUser.error = PASSWORD_MATCH;
        }
        return currentUser;
    }

    return {
        validateRegisterFields,
        validateMeme,
        validateUser
    }
})();