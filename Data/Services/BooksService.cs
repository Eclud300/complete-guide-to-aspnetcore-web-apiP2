﻿using Libreria_RERS.Data.Models;
using Libreria_RERS.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Libreria_RERS.Data.Services
{
    public class BooksService
    {
        private AppDbContext _context;

        public BooksService(AppDbContext context)
        {
            _context = context;

        }

        public void AddBook(BookVM book)
        {
            var _book = new Books()
            {
                Titulo = book.Titulo,
                Descripcion = book.Descripcion,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                Genero = book.Genero,
                Autor = book.Autor,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now

            };

            _context.Books.Add(_book);
            _context.SaveChanges();


        }

        public List<Books> GetAllBks() => _context.Books.ToList();

        public Books GetBookById(int bookid) => _context.Books.FirstOrDefault(n => n.id == bookid);

        //Metodo que nos permite modificar un libro que se encuentra en la BD 

        public Books UpdateBookByID(int bookid, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(n => n.id == bookid);
            if (_book != null )
            {
                _book.Titulo = book.Titulo;
                _book.Descripcion = book.Descripcion;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.DateRead;
                _book.Rate = book.Rate;
                _book.Genero = book.Genero;
                _book.Autor = book.Autor;
                _book.CoverUrl = book.CoverUrl;
               
                _context.SaveChanges();

            }
            return _book;
        }

        public void DeleteBookById(int bookid)
        {
            var _book = _context.Books.FirstOrDefault(n => n.id == bookid);
            if (_book != null )
            {
                _context.Books.Remove( _book ); 
                _context.SaveChanges();

            }

        }

    }
}
