﻿using ObjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BookDAO
    {
        private static BookDAO instance = null;
        private static readonly object Lock = new object();
        private readonly BookContext db;
        public BookDAO()
        {
            db = new BookContext();
        }
        public static BookDAO Instance
        {
            get
            {
                lock (Lock)
                {
                    if (instance == null)
                    {
                        instance = new BookDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Book> GetBooks()
        {
            var list = from a in db.Books
                       join b in db.CategoryBooks
                       on a.CategoryId equals b.CategoryId
                       select new Book
                       {
                           CategoryId = a.CategoryId,
                           Author = a.Author,
                           BookName = a.BookName,
                           BookId = a.BookId,
                           Charges = a.Charges,
                           Content = a.Content,
                           DateTime = a.DateTime,
                           Description = a.Description,
                           Picture = a.Picture,
                           Price = a.Price,
                           Star = a.Star,
                           Title = a.Title,
                           Set = b.Set
                       };
            return list;
        }
        public Book GetBookById(int id)
        {
            using var context = new BookContext();
            var book = context.Books.FirstOrDefault(b => b.BookId == id);
            return book;
        }
        public bool InsertBook(Book book)
        {
            bool status = false;
            using var context = new BookContext();
            try
            {
                context.Books.Add(book);
                int isSuccessfully = context.SaveChanges();
                if (isSuccessfully > 0)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return status;
        }
        public bool UpdateBook(Book book)
        {
            bool status = false;
            using var context = new BookContext();
            try
            {
                var checkContains = GetBookById(book.BookId);
                if (checkContains != null)
                {
                    context.Entry<Book>(book).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    int isSuccessfully = context.SaveChanges();
                    if (isSuccessfully > 0)
                    {
                        status = true;
                    }
                    else
                    {
                        status = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return status;
        }
        public bool DeleteBook(int id)
        {
            bool status = false;
            using var context = new BookContext();
            try
            {
                var checkContains = GetBookById(id);
                if (checkContains != null)
                {
                    context.Books.Remove(checkContains);
                    int isSuccessfully = context.SaveChanges();
                    if (isSuccessfully > 0)
                    {
                        status = true;
                    }
                    else
                    {
                        status = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return status;
        }
    }
}
