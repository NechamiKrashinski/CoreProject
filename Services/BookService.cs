using Microsoft.AspNetCore.Mvc;
using project.Models;

namespace project.Services;

public static class BookService 
{
    private static List<Book> listBooks;

    static BookService()
    {
        listBooks = new List<Book>{
            new Book {Id=1, Name = "איסתרק", Auther = "מיה קינן", Price = 70, Date= DateOnly.FromDateTime(DateTime.Now.AddYears(-2)) },
            new Book {Id=2, Name = "מהלהלל", Auther = "מיה קינן", Price = 70 , Date= DateOnly.FromDateTime(DateTime.Now.AddYears(-2)) }
        };
    }

    public static List<Book> Get(){
        return listBooks;
    }

     public static Book Get(int id){
        var book= listBooks.FirstOrDefault(b=> b.Id==id);
        return book;
    }

    public static int Insert(Book newBook)
    {
        if(newBook == null ||  String.IsNullOrWhiteSpace(newBook.Name) || newBook.Price <=0 )
            return-1;
       
         int MaxId = listBooks.Max(b=> b.Id);
         newBook.Id = MaxId+1;
         listBooks.Add(newBook);
         return newBook.Id;
       
    }

    public static bool Update(int id ,Book book)
    {
        if(book == null || book.Id!=id|| string.IsNullOrWhiteSpace(book.Name) || book.Price <=0)
            return false;

        var currentBook= listBooks.FirstOrDefault(b=> b.Id==id);
        if(currentBook == null)
            return false;
        
        currentBook.Name = book.Name;
        currentBook.Price = book.Price;
        return true;
    }

    public static bool Delete(int id)
    {
        var currentBook= listBooks.FirstOrDefault(b=> b.Id==id);
        if(currentBook == null)
            return false;
        
        int index = listBooks.IndexOf(currentBook);
        listBooks.RemoveAt(index);
        return true;
    }

}