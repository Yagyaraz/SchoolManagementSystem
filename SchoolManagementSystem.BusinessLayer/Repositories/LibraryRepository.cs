using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Identity.Client;
using SchoolManagementSystem.BusinessLayer.Interface;
using SchoolManagementSystem.Data.Data;
using SchoolManagementSystem.Data.Data.Entities;
using SchoolManagementSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.BusinessLayer.Repositories
{
    public class LibraryRepository:IRoom, IRack, IBookType, IBook
    {
        private readonly ApplicationDbContext _context;
        public LibraryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        #region Room
        public async Task<Result<List<RoomViewModel>>> GetAllRoom()
        {
           var list= await _context.Room.Where(x=>x.Status == true)
                .Select(x => new RoomViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync()??new List<RoomViewModel>();
            return Result<List<RoomViewModel>>.Success(list);

        }
        public async Task<Result<RoomViewModel>> GetRoomById(int? id)
        {
          var data= await _context.Room.Where(x=>x.Id==id).Select(x => new RoomViewModel
          {
              Id = x.Id,
              Name = x.Name
          }).FirstOrDefaultAsync()?? new RoomViewModel();
            return Result<RoomViewModel>.Success(data);
        }
        public async Task<Result<bool>> InsertUpdateRoom(RoomViewModel model) 
        {
            using(var transaction= await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    if (model.Id > 0)
                    {
                        var room = await _context.Room.FindAsync(model.Id);
                        if (room == null)
                        {
                            return Result<bool>.Failure($"Room not found with id :{model.Id}");
                        }
                        room.Name = model.Name;
                        _context.Room.Update(room);
                    }
                    else
                    {
                        var newRoom = new Room
                        {
                            Name = model.Name,
                            Status = true
                        };
                        await _context.Room.AddAsync(newRoom);
                    }
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return Result<bool>.Success(true);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return Result<bool>.Failure($"Error: {ex.Message}");
                }
            }
        }
        public async Task<Result<bool>> DeleteRoom(int? id)
        {
            var room = await _context.Room.FindAsync(id);
            try
            {
                if (room != null)
                {
                    room.Status = false;
                    _context.Entry(room).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Result<bool>.Success(true);
                }
                else
                {
                    return Result<bool>.Failure($"Room can,t found!!");
                }
            }
            catch
            {
                return Result<bool>.Failure($"Failed to delete Room with id:{room.Id}");
            }
        }
        #endregion
        #region Rack 
        public Task<Result<List<RackViewModel>>> GetAllRack()
        {
            throw new NotImplementedException();
        }

        public Task<Result<RackViewModel>> GetRackById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> InsertUpdateRack(RackViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> DeleteRack(int? id)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region BookType
        public async Task<Result<List<BookTypeViewModel>>> GetAllBookType()
        {
            var rack =await _context.BookType.Where(x => x.Status == true)
                .Select(x => new BookTypeViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync() ?? new List<BookTypeViewModel>();
            return Result<List<BookTypeViewModel>>.Success(rack);
        }

        public async Task<Result<BookTypeViewModel>> GetBookTypeById(int? id)
        {
            var rack = await _context.BookType.Where(x => x.Id == id).Select(x => new BookTypeViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).FirstOrDefaultAsync() ?? new BookTypeViewModel();
            return Result<BookTypeViewModel>.Success(rack);

        }

        public async Task<Result<bool>> InsertUpdateBookType(BookTypeViewModel model)
        {
           using(var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    if (model.Id > 0)
                    {
                        var bookType = await _context.BookType.FindAsync(model.Id);
                        if (bookType == null)
                        {
                            return Result<bool>.Failure($"Book Type not found with id :{model.Id}");
                        }
                        bookType.Name = model.Name;
                        _context.BookType.Update(bookType);
                    }
                    else
                    {
                        var newBookType = new BookType
                        {
                            Name = model.Name,
                            Status = true
                        };
                        await _context.BookType.AddAsync(newBookType);
                    }
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return Result<bool>.Success(true);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return Result<bool>.Failure($"Error: {ex.Message}");
                }
            }
        }

        public async Task<Result<bool>> DeleteBookType(int? id)
        {
           var bookType = await _context.BookType.FindAsync(id);
            try
            {
                if (bookType != null)   
                {
                    bookType.Status = false;
                    _context.Entry(bookType).State = EntityState.Modified;
                    _context.SaveChanges();
                    return Result<bool>.Success(true);
                }
                else
                {
                    return Result<bool>.Failure($"Book Type can't found!!");
                }
            }
            catch
            {
                return Result<bool>.Failure($"Failed to delete Book Type with id:{bookType.Id}");
            }
        }
        #endregion
        #region Book
        public async Task<Result<List<BookViewModel>>> GetAllBook()
        {
            var book = await _context.Book.Where(x => x.Status == true)
                .Select(x => new BookViewModel
                {
                    Id = x.Id,
                    BookName = x.BookName,
                    ISBN = x.ISBN,

                }).ToListAsync() ?? new List<BookViewModel>();
            return Result<List<BookViewModel>>.Success(book);
        }

        public async Task<Result<BookViewModel>> GetBookById(int? id)
        {
            var book = await _context.Book.Where(x => x.Id == id).Select(x => new BookViewModel
            {
                Id = x.Id,
                BookName = x.BookName,
                ISBN = x.ISBN,
                BookNumber = x.BookNumber,
                ClassNumber = x.ClassNumber,
                Year = x.Year,
                PublishedDate = x.PublishedDate,
                PublishedLocation = x.PublishedLocation,
                Pages = x.Pages,
                Edition = x.Edition,
                Language = x.Language,
                MaterialType = x.MaterialType
            }).FirstOrDefaultAsync() ?? new BookViewModel();
            return Result<BookViewModel>.Success(book);
        }

        public async Task<Result<bool>> InsertUpdateBook(BookViewModel model)
        {
            using (var transaction =await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    if (model.Id > 0)
                    {
                        var book = _context.Book.Find(model.Id);
                        if (book == null)
                        {
                            return Result<bool>.Failure($"Book not found with id :{model.Id}");
                        }
                        book.BookName = model.BookName;
                        book.ISBN = model.ISBN;
                        book.BookNumber = model.BookNumber;
                        book.ClassNumber = model.ClassNumber;
                        book.Year = model.Year;
                        book.PublishedDate = model.PublishedDate;
                        book.PublishedLocation = model.PublishedLocation;
                        book.Pages = model.Pages;
                        book.Edition = model.Edition;
                        book.Language = model.Language;
                        book.MaterialType = model.MaterialType;
                        _context.Book.Update(book);
                    }
                    else
                    {
                        var newBook = new Book
                        {
                            BookName = model.BookName,
                            ISBN = model.ISBN,
                            BookNumber = model.BookNumber,
                            ClassNumber = model.ClassNumber,
                            Year = model.Year,
                            PublishedDate = model.PublishedDate,
                            PublishedLocation = model.PublishedLocation,
                            Pages = model.Pages,
                            Edition = model.Edition,
                            Language = model.Language,
                            MaterialType = model.MaterialType,
                            Status = true
                        };
                        _context.Book.Add(newBook);
                    }
                    _context.SaveChanges();
                    transaction.Commit();
                    return Result<bool>.Success(true);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return Result<bool>.Failure($"Error: {ex.Message}");
                }
            }
        }

        public async Task<Result<bool>> DeleteBook(int? id)
        {
            var book =await _context.Book.FindAsync(id);
            try
            {
                if (book != null)
                {
                    book.Status = false;
                    _context.Entry(book).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Result<bool>.Success(true);
                }
                else
                {
                    return Result<bool>.Failure($"Failed to delete Book with id:{book.Id}");
                }
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure($"Failed to delete Book with id:{book.Id}, Error: {ex.Message}");
            }

        }
        #endregion
    }
}
