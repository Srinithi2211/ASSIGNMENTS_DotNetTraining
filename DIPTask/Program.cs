using DIPTask;

public class Program
{
    public static void Main()
    {
        LibrarySystem librarySystem = new LibrarySystem();

        IUserActions student = new Student();
        IUserActions teacher = new Teacher();
        IUserActions librarian = new Librarian();

        librarySystem.PerformBorrowBook(student, "Introduction to C#");
        librarySystem.PerformReturnBook(teacher, "Data Structures");
        librarySystem.PerformReserveBook(teacher, "Artificial Intelligence");
        librarySystem.PerformAddBook(librarian, "New Book on Machine Learning");
        librarySystem.PerformRemoveBook(librarian, "Outdated Book on Java");
    }
}

