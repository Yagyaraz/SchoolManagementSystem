using SchoolManagementSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.BusinessLayer.Interface
{
    #region Room
    public interface IRoom
    {
        Task<Result<List<RoomViewModel>>> GetAllRoom();
        Task<Result<RoomViewModel>> GetRoomById(int?id);
        Task<Result<bool>>InsertUpdateRoom(RoomViewModel model);
        Task<Result<bool>> DeleteRoom(int? id);
    }
    #endregion
    #region Rack
    public interface IRack
    {
        Task<Result<List<RackViewModel>>> GetAllRack();
        Task<Result<RackViewModel>> GetRackById(int? id);
        Task<Result<bool>> InsertUpdateRack(RackViewModel model);
        Task<Result<bool>> DeleteRack(int? id);
    }
    #endregion
    #region BookType
    public interface IBookType
    {
        Task<Result<List<BookTypeViewModel>>> GetAllBookType();
        Task<Result<BookTypeViewModel>> GetBookTypeById(int? id);
        Task<Result<bool>> InsertUpdateBookType(BookTypeViewModel model);
        Task<Result<bool>> DeleteBookType(int? id);
    }
    #endregion
    #region Book
    public interface IBook
    {
        Task<Result<List<BookViewModel>>> GetAllBook();
        Task<Result<BookViewModel>> GetBookById(int? id);
        Task<Result<bool>> InsertUpdateBook(BookViewModel model);
        Task<Result<bool>> DeleteBook(int? id);
    }
    #endregion
}
