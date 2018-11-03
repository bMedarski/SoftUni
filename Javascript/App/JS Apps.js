

САМО ПРОДУКТИТЕ които са в активната сметка за съответният user
САМО АКТИВНИ ПРОДУКТИ






password -- Texp3804
	Подготвен скелет
	
	AuthService
	KinveyService
	NotifyService 
	
	да променя APP_KEY / APP_PASSWORD
	да се добави ако трябва валидация
	
	
	app.js със обект Sammy
	да се добави get.use('Handlebars','hbs')
	да се внимава името на контейнера
	допълнителен route за home
	темплейти
	
	в html да се внимава за неработещи routove
	
	<a href='/#drdr'>
	
	при формите ако липсва action=link-a и method=post
	
	да не се забравят partial templetes
	
	{{> header}}
	
	навигация само при регистриран
	да се проверява при рег името с logout горе
	
	да се зареждат
	
	ctx.loadPartials({
                        header: './Core/Views/partials/header.hbs',
                        menu: './Core/Views/partials/menu.hbs',
                        footer: './Core/Views/partials/footer.hbs',
                        singlePost: './Core/Views/Post/partials/singlePost.hbs',
                    })
					
	да се види в заданието края на заявките
	
	
	да се добавя message при операциите
	
	да се добавя за грешка
	
	да се редирекне
	
	id-то може да се сложи в input type=hidden поле