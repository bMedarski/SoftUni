function Solve(username,email,phoneNumber,form){

    const regexU = /<![a-zA-Z]+!>/gm;
    const regexE = /<@[a-zA-Z]+@>/gm;
    const regexP = /<\+[a-zA-Z]+\+>/gm;


    for (let i = 0; i < form.length; i++) {

        form[i] = form[i].replace(regexU,username).replace(regexE,email).replace(regexP,phoneNumber);
        console.log(form[i]);
    }
}

Solve('Pesho',
    'pesho@softuni.bg',
    '90-60-90',
    ['Hello, <!username!>!',
        'Welcome to your Personal profile.',
        'Here you can modify your profile freely.',
        'Your current username is: <!fdsfs!>. Would you like to change that? (Y/N)',
        'Your current email is: <@DasEmail@>. Would you like to change that? (Y/N)',
        'Your current phone number is: <+number+>. Would you like to change that? (Y/N)']
);