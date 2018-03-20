class PaymentManager {
    constructor(title) {
        this.title = title;
    }

    render(id) {
        let selector = $('#' + id);

        let table = $('<table>');
        let title = this.title + " Payment Manager";
        let caption = $('<caption>').text(title);
        let thead = $('<thead>');
        let tbody = $('<tbody>').addClass('payments');
        let tfoot = $('<tfoot>').addClass('input-data');

        let headRow = $('<tr>');
        let nameHeader = $('<th>').addClass('name').text('Name');
        let categoryHeader = $('<th>').addClass('category').text('Category');
        let priceHeader = $('<th>').addClass('price').text('Price');
        let actionHeader = $('<th>').text('Actions');

        headRow.append(nameHeader);
        headRow.append(categoryHeader);
        headRow.append(priceHeader);
        headRow.append(actionHeader);
        thead.append(headRow);

        let bottomRow = $('<tr>');
        let tdName = $('<td>');
        let inputName = $('<input>').attr('name', 'name').attr('type', 'text');
        let tdCategory = $('<td>');
        let inputCategory = $('<input>').attr('name', 'category').attr('type', 'text');
        let tdPrice = $('<td>');
        let inputPrice = $('<input>').attr('name', 'price').attr('type', 'number');
        let tdAction = $('<td>');
        let actionButton = $('<button>').text("Add");

        actionButton.on('click', function (event) {

            let par = $(event.target).parent().parent().parent().parent();

            let name = $(event.target).parent().parent().find(':input[name="name"]').val();
            let category = $(event.target).parent().parent().find(':input[name="category"]').val();
            let price = Number($(event.target).parent().parent().find(':input[name="price"]').val());

            if (name === '' || category === ''||price===''||price===0) {
                //$(event.target).parent().parent().find(':input[name="name"]').val('');
                //$(event.target).parent().parent().find(':input[name="category"]').val('');
                //$(event.target).parent().parent().find(':input[name="price"]').val('');
                return this;
            }
            let manager = par.find('tbody');

            let newNameTd = $('<td>').text(name);
            let newCategoryTd = $('<td>').text(category);
            let newPriceTd = $('<td>').text(price);
            let newTdBtn = $('<td>');
            let newBtnDel = $('<button>').text('Delete');
            newBtnDel.on('click', function (e) {
                $(e.target).parent().parent().remove();
            });
            let newRow = $('<tr>');

            newTdBtn.append(newBtnDel);
            newRow.append(newNameTd);
            newRow.append(newCategoryTd);
            newRow.append(newPriceTd);
            newRow.append(newTdBtn);

            manager.append(newRow);

            $(event.target).parent().parent().find(':input[name="name"]').val('');
            $(event.target).parent().parent().find(':input[name="category"]').val('');
            $(event.target).parent().parent().find(':input[name="price"]').val('');
        });


        tdAction.append(actionButton);
        tdCategory.append(inputCategory);
        tdName.append(inputName);
        tdPrice.append(inputPrice);
        bottomRow.append(tdName);
        bottomRow.append(tdCategory);
        bottomRow.append(tdPrice);
        bottomRow.append(tdAction);
        tfoot.append(bottomRow);

        table.append(caption);
        table.append(thead);
        table.append(tbody);
        table.append(tfoot);

        selector.append(table);
        return this;
    }
}