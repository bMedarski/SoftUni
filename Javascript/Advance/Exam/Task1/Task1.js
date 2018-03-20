Sfao1113
document.body.innerHTML = `
    <div id="amazon"></div>

    <div id="ebay"></div>

    <div id="walmart"></div>`;

let templateTable = title => {
    return ('<table><caption>' + title + ' Payment Manager</caption><thead><tr>' +
        '<th class="name">Name</th>' +
        '<th class="category">Category</th>' +
        '<th class="price">Price</th>' +
        '<th>Actions</th></tr></thead>' +
        '<tbody class="payments"></tbody><tfoot class="input-data"><tr>' +
        '<td><input name="name" type="text"></td><td><input name="category" type="text"></td>' +
        '<td><input name="price" type="number"></td>' +
        '<td><button>Add</button></td></tr></tfoot></table>')
}

let paymentMangersData = [
    ['amazon', 'Amazon'],
    ['ebay', 'eBay'],
    ['walmart', 'Walmart']
]

let allManagersObj = {}

for (let [target, title] of paymentMangersData) {
    let proc;
    expect(() => proc = new result(),
        "Instance creation failed, make sure you have submitted a class").to.not.throw();

    let paymentManager = new result(title)

    checkClassFunctionality(paymentManager)

    allManagersObj[target] = {
        manager: paymentManager,
        paymentsCount: 0
    }

    let targetDiv = $('#' + target)

    // Test if table is visualized before calling .render() function
    expect(targetDiv.html()).to.be.empty

    paymentManager.render(target)

    let userTableTitle = targetDiv.find('caption').text()
    expect(userTableTitle).to.equal(title + " Payment Manager",
        "The title of " + title + "'s table is displayed wrong.")

    // Test initializing the table
    let userTableStr = targetDiv.html().toString().split('\n').map(e => e.trim()).join('')
    let templateTableStr = templateTable(title).split('\n').map(e => e.trim()).join('')

    let checkTemplateTable = userTableStr === templateTableStr
    expect(checkTemplateTable).to
        .equal(true, "You did not initialize correctly the " + title + " table.")
}

function checkClassFunctionality(manager) {
    let neededClassMethods = [ 'render' ]

    for (let prop of neededClassMethods) {
        expect(Object.getPrototypeOf(manager).hasOwnProperty(prop)).to
            .equal(true, "Missing " + prop + " class method.")
    }
}

function testAddingPayments(nameValue, categoryValue, priceValue, targetId) {
    let managerDataObj = allManagersObj[targetId]
    let stringsArr = [ 'name', 'category', 'price']
    let paymentValues = [ nameValue, categoryValue, priceValue ]

    let divTargetBoody = $('#' + targetId)
    let inputs = divTargetBoody.find('input')
    inputs.each((i,e) => { $(e).val(paymentValues[i]) })

    // Add payment
    divTargetBoody.find('tfoot button').trigger('click')

    let targetBody = divTargetBoody.find('tbody')
    let paymentRows = targetBody.find('tr')

    let checkTablePayments = () => {
        expect(paymentRows.length).to
            .equal(managerDataObj.paymentsCount, "The number of payments is wrong.");
    }

    if (paymentValues.every(e => e)) {
        managerDataObj.paymentsCount++

        checkTablePayments()

        // Parse to check if price is a number
        paymentValues[2] = Number(priceValue).toString()

        // Test if the added new payment is correct
        let paymentInfo = paymentRows.last().find('td')
        for (let i = 0; i < paymentValues.length; i++) {
            expect(paymentInfo[i].textContent).to
                .equal(paymentValues[i], "Added payment's " + stringsArr[i] + " is wrong.");
        }

        // Test if the input fields are empty after adding paymetns
        inputs.each((i,e) => { expect($(e).val()).to.be.empty })

        // Test if the payment is added to other tables
        checkOtherTables(targetId, 'added')
    } else {
        checkTablePayments()

        // Test witch inputs are empty
        let inputFieldsCheck = (inputValue, paymentValue, type) => {
            if (!inputValue) {
                expect(inputValue).to.be.empty
            } else {
                expect(inputValue).to
                    .contains(paymentValue, "Payment's input " + type + " should not be empty.")
            }
        }

        for (let i = 0; i < inputs.length; i++) {
            let currentInputColValue = $(inputs[i]).val()

            inputFieldsCheck(currentInputColValue, paymentValues[i], stringsArr[i])
        }
    }
}

function testDeletingPayments (targetId, rowIndex) {
    let managerDataObj = allManagersObj[targetId]

    let targetMain = $('#' + targetId)
    let tableBody = targetMain.find('tbody')

    let paymentToDelete = tableBody.find('tr').eq(rowIndex)
    let deletedRowInnerHtml = paymentToDelete.html()

    // Deleting row
    paymentToDelete.find('button').trigger('click')

    managerDataObj.paymentsCount -= 1

    let tablePaymentRows = tableBody.find('tr')

    expect(tablePaymentRows.length).to
        .equal(managerDataObj.paymentsCount, "You did not delete the payment in the table.")

    tablePaymentRows.each((i,e) => {
        let isDeletedRowWrong = $(e).html() === deletedRowInnerHtml
        expect(isDeletedRowWrong).to.not.equal(true, "You have deleted the wrong row.")
    })

    // Test if (the payment) there is deleted rows in other tables
    checkOtherTables(targetId, 'deleted')
}

function checkOtherTables (targetId, cmd) {
    let mainIDsArr = $('div').toArray()
        .map(e => $(e).attr('id'))
        .filter(id => id !== targetId)

    for (let mainId of mainIDsArr) {
        let otherManager = allManagersObj[mainId]
        let otherTableRows = $('#' + mainId).find('tbody').find('tr')

        expect(otherTableRows.length).to
            .equal(otherManager.paymentsCount,
                "You have " + cmd + " a payment in the wrong table.")
    }
}

// Test full functionality with multiple tables
let commandsData = [
    [ 'add', 'amazon', null, "Logitech MX Master", "Mouses", "149.99000" ],
    [ 'add', 'amazon', null, "MX Master", "Smt", "54.5" ],
    [ 'add', 'amazon', null, "Dell XPS 13", "Computers", "999.99" ],
    [ 'add', 'amazon', null, "XPS 13", "Computers", "" ],
    [ 'add', 'amazon', null, "", "Keyboards", "80" ],
    [ 'add', 'amazon', null, "Smt", "", "20" ],
    [ 'add', 'ebay', null, "V60 Cherry Dolch", "Keyboards", "105" ],
    [ 'add', 'ebay', null, "", "", "" ],
    [ 'delete', 'amazon', 0 ],
    [ 'add', 'ebay', null, "Asus Zenbook 13", "Computers", "1035.34235" ],
    [ 'add', 'ebay', null, "", "Computers", "543.35" ],
    [ 'add', 'walmart', null, "V60 Cherry Dolch", "Keyboards", "105" ],
    [ 'add', 'ebay', null, "Lenovo Smt", "Computers", "" ],
    [ 'delete', 'walmart', 0 ]
]

for (let [cmd, target, index, name, category, price ] of commandsData) {
    if (cmd === 'add') {
        testAddingPayments(name, category, price, target)
    } else if (cmd === 'delete') {
        testDeletingPayments(target, index)
    }
}