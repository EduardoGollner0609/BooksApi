﻿using BooksApi.Dto;
using BooksApi.Models;

namespace BooksApi.Repository
{
    public interface IAuthorRepository : ICrudRepository<AuthorDto>
    {
        Task<ResponseModel<AuthorDto>> FindByIdBook(int bookId);
    }
}
