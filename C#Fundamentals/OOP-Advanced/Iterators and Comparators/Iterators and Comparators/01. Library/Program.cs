using System;

class Program
{
	public static void Main()
	{
		Book bookOne = new Book("Animal Farm", 2003, "George Orwell");
		Book bookTwo = new Book("The 1 in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
		Book bookThree = new Book("The 2 in the Case", 1930);
		Book five = new Book("The 3 in the Case", 1930);
		Book four = new Book("The 4 in the Case", 1930);
		Book sic = new Book("The 5 in the Case", 1930);
		Library libraryOne = new Library();
		Library libraryTwo = new Library(bookOne, bookTwo, bookThree,four,five,sic);


		foreach (var book in libraryTwo)
		{
			Console.WriteLine(book);
		}
	}

}

