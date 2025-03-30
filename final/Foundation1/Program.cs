using System;
using System.Collections.Generic;

// Abstract Class for Book
public abstract class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }

    public Book(string title, string author, string genre)
    {
        Title = title;
        Author = author;
        Genre = genre;
    }

    // Abstract method to get details
    public abstract void GetDetails();
}

// Concrete class implementing Book
public class LibraryBook : Book
{
    public LibraryBook(string title, string author, string genre)
        : base(title, author, genre) { }

    // Implementing the abstract method
    public override void GetDetails()
    {
        Console.WriteLine($"Title: {Title}, Author: {Author}, Genre: {Genre}");
    }
}

// Library Class to manage a collection of books
public class Library
{
    private List<Book> books;

    public Library()
    {
        books = new List<Book>();
    }

    // Method to add a book
    public void AddBook(Book book)
    {
        books.Add(book);
    }

    // Method to remove a book
    public void RemoveBook(Book book)
    {
        books.Remove(book);
    }

    // Method to get the list of books
    public List<Book> GetBooks()
    {
        return books;
    }

    // Method to display all books in the library
    public void DisplayBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No books available in the library.");
            return;
        }
        foreach (var book in books)
        {
            book.GetDetails();
        }
    }
}

// Main Program
public class Program
{
    public static void Main(string[] args)
    {
        Library library = new Library();

        while (true)
        {
            Console.WriteLine("\nLibrary System:");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Remove Book");
            Console.WriteLine("3. Display Books");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                // Add Book
                Console.Write("Enter Book Title: ");
                string title = Console.ReadLine();
                Console.Write("Enter Book Author: ");
                string author = Console.ReadLine();
                Console.Write("Enter Book Genre: ");
                string genre = Console.ReadLine();

                Book newBook = new LibraryBook(title, author, genre);
                library.AddBook(newBook);
                Console.WriteLine("Book added successfully.");
            }
            else if (choice == 2)
            {
                // Remove Book
                Console.Write("Enter Book Title to Remove: ");
                string titleToRemove = Console.ReadLine();

                Book bookToRemove = null;
                foreach (var book in library.GetBooks()) // Accessing books through a method
                {
                    if (book.Title.Equals(titleToRemove, StringComparison.OrdinalIgnoreCase))
                    {
                        bookToRemove = book;
                        break;
                    }
                }

                if (bookToRemove != null)
                {
                    library.RemoveBook(bookToRemove);
                    Console.WriteLine("Book removed successfully.");
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
            }
            else if (choice == 3)
            {
                // Display Books
                library.DisplayBooks();
            }
            else if (choice == 4)
            {
                // Exit
                break;
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
            }
        }
    }
}
