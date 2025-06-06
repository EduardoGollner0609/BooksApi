﻿namespace BooksApi.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public AuthorModel Author { get; set; }
        public BookModel() { }
        public BookModel(string title, AuthorModel author)
        {
            Title = title;
            Author = author;
        }
    }
}
