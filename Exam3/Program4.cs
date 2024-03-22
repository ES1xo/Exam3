using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int PublicationYear { get; set; }
    public string ISBN { get; set; }
}

public class Program
{
    public static List<Book> ReadBooksFromJson(string filePath)
    {
        string jsonString = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<Book>>(jsonString);
    }

    public static List<Book> FilterBooksStartingWithThe(List<Book> books)
    {
        List<Book> filteredBooks = new List<Book>();

        foreach (var book in books)
        {
            if (book.Title.StartsWith("The"))
            {
                filteredBooks.Add(book);
            }
        }

        return filteredBooks;
    }

    public static List<Book> FilterBooksByAuthorsWithTInName(List<Book> books)
    {
        List<Book> filteredBooks = new List<Book>();

        foreach (var book in books)
        {
            if (ContainsTInName(book.Author))
            {
                filteredBooks.Add(book);
            }
        }

        return filteredBooks;
    }

    public static bool ContainsTInName(string authorName)
    {
        foreach (char c in authorName.ToLower())
        {
            if (c == 't')
            {
                return true;
            }
        }
        return false;
    }

    public static int CountBooksWrittenAfterYear(List<Book> books, int year)
    {
        int count = 0;

        foreach (var book in books)
        {
            if (book.PublicationYear > year)
            {
                count++;
            }
        }

        return count;
    }

    public static int CountBooksWrittenBeforeYear(List<Book> books, int year)
    {
        int count = 0;

        foreach (var book in books)
        {
            if (book.PublicationYear < year)
            {
                count++;
            }
        }

        return count;
    }

    public static List<string> GetISBNsByAuthor(List<Book> books, string author)
    {
        List<string> isbns = new List<string>();

        foreach (var book in books)
        {
            if (book.Author == author)
            {
                isbns.Add(book.ISBN);
            }
        }

        return isbns;
    }
    
    public static List<Book> ListBooksAlphabetically(List<Book> books, bool ascending = true)
    {
        books.Sort((b1, b2) => ascending ? string.Compare(b1.Title, b2.Title) : string.Compare(b2.Title, b1.Title));
        return books;
    }

    public static List<Book> ListBooksChronologically(List<Book> books, bool ascending = true)
    {
        books.Sort((b1, b2) => ascending ? b1.PublicationYear.CompareTo(b2.PublicationYear) : b2.PublicationYear.CompareTo(b1.PublicationYear));
        return books;
    }

    public static Dictionary<string, List<Book>> GroupBooksByAuthorLastName(List<Book> books)
    {
        Dictionary<string, List<Book>> groupedBooks = new Dictionary<string, List<Book>>();
        foreach (var book in books)
        {
            string[] authorNames = book.Author.Split(' ');
            string lastName = authorNames[authorNames.Length - 1];

            if (!groupedBooks.ContainsKey(lastName))
            {
                groupedBooks[lastName] = new List<Book>();
            }

            groupedBooks[lastName].Add(book);
        }
        return groupedBooks;
    }

    public static Dictionary<string, List<Book>> GroupBooksByAuthorFirstName(List<Book> books)
    {
        Dictionary<string, List<Book>> groupedBooks = new Dictionary<string, List<Book>>();
        foreach (var book in books)
        {
            string[] authorNames = book.Author.Split(' ');
            string firstName = authorNames[0];

            if (!groupedBooks.ContainsKey(firstName))
            {
                groupedBooks[firstName] = new List<Book>();
            }

            groupedBooks[firstName].Add(book);
        }
        return groupedBooks;
    }
    public static void Main(string[] args)
    {
        List<Book> books = ReadBooksFromJson("books.json");

        if (books != null)
        {
            var booksAlphabeticallyAscending = ListBooksAlphabetically(new List<Book>(books));

            var booksAlphabeticallyDescending = ListBooksAlphabetically(new List<Book>(books), false);

            var booksChronologicallyAscending = ListBooksChronologically(new List<Book>(books));

            var booksChronologicallyDescending = ListBooksChronologically(new List<Book>(books), false);

            var booksGroupedByAuthorLastName = GroupBooksByAuthorLastName(new List<Book>(books));

            var booksGroupedByAuthorFirstName = GroupBooksByAuthorFirstName(new List<Book>(books));

        }
        else
        {
            Console.WriteLine("Failed to read books from JSON file.");
        }
    }
}    
