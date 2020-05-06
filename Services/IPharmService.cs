using System.Collections.Generic;
using System.Threading.Tasks;
using DauaPharm.Data.Entities;

namespace DauaPharm.Data
{
    // Each item below provides an interface to a method in VideoServices.cs
    public interface IPharmService
    {
        Task<bool> PharmInsert(SprKdr SprKdr);
        Task<IEnumerable<SprKdr>> PharmList();
        Task<SprKdr> Pharm_GetOne(int Id);
        Task<bool> PharmUpdate(SprKdr SprKdr);
        Task<bool> PharmDelete(int id);
        Login Pharm_GetLogin(string Log, string Psw);
        //Task<IEnumerable<SprBuxMnu>> Pharm_GetMenu(int BuxFrm, int BuxKod);
        Task<IEnumerable<SprBux>> Pharm_GetSprBux(int BuxFrm, int BuxUbl);
        Task<IEnumerable<SprKdr>> Pharm_GetSprKdr(int BuxFrm);
        Task<IEnumerable<SprSttStr>> Pharm_GetSprSttStr(int BuxFrm);
        List<SprDlg> Pharm_GetSprDlg(int BuxFrm,string StrKey);
        Task<bool> Pharm_UpdSprBux(SprBux SprBux);
        Task<IEnumerable<SprBuxMnu>> Pharm_GetSprBuxMnu(int BuxFrm, int BuxKod);
        Task<bool> Pharm_UpdSprBuxMnu(SprBuxMnu SprBuxMnu, int BuxFrm, int BuxKod);

    }
}