/*
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace Day3_Day4_Tasks

{
    public class Book
    {
        public int BookId { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public int AuthorId { get; set; }
    }

    
    public class Author
    {
        public int AuthorId { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
    }
    
    class Program
    {
        static void Main()
        {
            
            List<Book> books = new List<Book>
            {
                new Book { BookId = 1, Title = "Book A", Genre = "Fiction", AuthorId = 1 },
                new Book { BookId = 2, Title = "Book B", Genre = "Science", AuthorId = 2 },
                new Book { BookId = 3, Title = "Book C", Genre = "History", AuthorId = 3 },
                new Book { BookId = 4, Title = "Book D", Genre = "Romance", AuthorId = 4 },
                new Book { BookId = 5, Title = "Book E", Genre = "Mystery", AuthorId = 5 }
            };

            List<Author> authors = new List<Author>
            {
                new Author { AuthorId = 1, Name = "Author A", Country = "Country A" },
                new Author { AuthorId = 2, Name = "Author B", Country = "Country B" },
                new Author { AuthorId = 3, Name = "Author C", Country = "Country C" },
                new Author { AuthorId = 4, Name = "Author D", Country = "Country D" },
                new Author { AuthorId = 5, Name = "Author E", Country = "Country E" }
            };

            // Serialize to JSON and save to file
            string bookJsonFile = "books.json";
            string authorJsonFile = "authors.json";

            File.WriteAllText(bookJsonFile, JsonSerializer.Serialize(books));
            File.WriteAllText(authorJsonFile, JsonSerializer.Serialize(authors));

            // Serialize to XML and save to file
            string bookXmlFile = "books.xml";
            string authorXmlFile = "authors.xml";

            XmlSerializer bookXmlSerializer = new XmlSerializer(typeof(List<Book>));
            XmlSerializer authorXmlSerializer = new XmlSerializer(typeof(List<Author>));

            using (FileStream fs = new FileStream(bookXmlFile, FileMode.Create))
            {
                bookXmlSerializer.Serialize(fs, books);
            }

            using (FileStream fs = new FileStream(authorXmlFile, FileMode.Create))
            {
                authorXmlSerializer.Serialize(fs, authors);
            }

            // Read JSON data
            Console.WriteLine("JSON Data:");
            string bookJsonData = File.ReadAllText(bookJsonFile);
            List<Book> deserializedBooksFromJson = JsonSerializer.Deserialize<List<Book>>(bookJsonData);
            foreach (var book in deserializedBooksFromJson)
            {
                Console.WriteLine($"BookId: {book.BookId}, Title: {book.Title}, Genre: {book.Genre}, AuthorId: {book.AuthorId}");
            }

            string authorJsonData = File.ReadAllText(authorJsonFile);
            List<Author> deserializedAuthorsFromJson = JsonSerializer.Deserialize<List<Author>>(authorJsonData);
            foreach (var author in deserializedAuthorsFromJson)
            {
                Console.WriteLine($"AuthorId: {author.AuthorId}, Name: {author.Name}, Country: {author.Country}");
            }

            // Read XML data
            Console.WriteLine("\nXML Data:");
            using (FileStream fs = new FileStream(bookXmlFile, FileMode.Open))
            {
                List<Book> deserializedBooksFromXml = (List<Book>)bookXmlSerializer.Deserialize(fs);
                foreach (var book in deserializedBooksFromXml)
                {
                    Console.WriteLine($"BookId: {book.BookId}, Title: {book.Title}, Genre: {book.Genre}, AuthorId: {book.AuthorId}");
                }
            }

            using (FileStream fs = new FileStream(authorXmlFile, FileMode.Open))
            {
                List<Author> deserializedAuthorsFromXml = (List<Author>)authorXmlSerializer.Deserialize(fs);
                foreach (var author in deserializedAuthorsFromXml)
                {
                    Console.WriteLine($"AuthorId: {author.AuthorId}, Name: {author.Name}, Country: {author.Country}");
                }
            }
        }
    }
}
    */
