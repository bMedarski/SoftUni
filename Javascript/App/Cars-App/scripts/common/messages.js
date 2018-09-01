const USERNAME_REQUIREMENTS = `Username should be at least ${USERNAME_LENGTH} characters long and contain only letters!`;
const PASSWORD_MATCH = 'Passwords should match!';
const PASSWORD_REQUIREMENTS = `Password should be at least ${PASSWORD_LENGTH} characters long and contain only letters! and digits`;

const SUCCESSFUL_LOGIN = 'Login successful.';
const SUCCESSFUL_REGISTRATION = 'User registration successful.';
const SUCCESSFUL_LOGOUT = 'Logout successful.';


const TITLE_REQUIREMENTS = `Title must be no more then ${CAR_TITLE_LENGTH} symbols length`;
const DESCRIPTION_REQUIREMENTS = `Description must be no more then ${DESCRIPTION_TITLE_LENGTH_MAX} symbols length and less then ${DESCRIPTION_TITLE_LENGTH_MIN}`;

const BRAND_REQUIREMENTS = `Brand must be at most ${BRAND_LENGTH_MAX} long`;
const FUEL_REQUIREMENTS = `Fuel must be at most ${FUEL_LEGTH_MAX} long`;
const MODEL_REQUIREMENTS = `Model must be at most ${MODEL_LENGTH_MAX} long and at least ${MODEL_LENGTH_MIN} long`;
const YEAR_REQUIREMENTS = `Year must be at most ${YEAR_LENGTH_MAX} long`;
const PRICE_REQUIREMENTS = `Price must be at most ${PRICE_MAX}$`;
const IMAGEURL_REQIREMENTS = 'ImageUrl must start with http';