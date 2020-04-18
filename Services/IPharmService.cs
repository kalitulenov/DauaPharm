using System.Collections.Generic;
using System.Threading.Tasks;
using DauaPharm.Data.Entities;

namespace BlazorDapperCRUD.Data
{
    // Each item below provides an interface to a method in VideoServices.cs
    public interface IPharmService
    {
        Task<bool> PharmInsert(SprKdr SprKdr);
        Task<IEnumerable<SprKdr>> PharmList();
        Task<SprKdr> Pharm_GetOne(int Id);
        Task<bool> PharmUpdate(SprKdr SprKdr);
        Task<bool> PharmDelete(int id);
        Task<Login> Pharm_GetLogin();
    }
}