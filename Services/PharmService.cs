﻿using Dapper;
using DauaPharm.Data;
using DauaPharm.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DauaPharm.Data
{
    public class PharmService : IPharmService
    {
        // Database connection
        private readonly SqlConnectionConfiguration _configuration;
        public PharmService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Add (create) a sprKdr table row (SQL Insert)
        public async Task<bool> PharmInsert(SprKdr sprKdr)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                //parameters.Add("Title", sprKdr.Title, DbType.String);
                //parameters.Add("DatePublished", sprKdr.DatePublished, DbType.Date);
                //parameters.Add("IsActive", sprKdr.IsActive, DbType.Boolean);
                // Stored procedure method
                await conn.ExecuteAsync("spsprKdr_Insert", parameters, commandType: CommandType.StoredProcedure);

                // Raw SQL method
                // const string query = @"INSERT INTO sprKdr (Title, DatePublished, IsActive) VALUES (@Title, @DatePublished, @IsActive)";
                // await conn.ExecuteAsync(query, new { sprKdr.Title, sprKdr.DatePublished, sprKdr.IsActive }, commandType: CommandType.Text);
            }
            return true;
        }     

        // Get a list of sprKdr rows (SQL Select)
        public async Task<IEnumerable<SprKdr>> PharmList()
        {
            IEnumerable<SprKdr> sprKdrs;
            using (var conn = new SqlConnection(_configuration.Value))
            {
                sprKdrs = await conn.QueryAsync<SprKdr>("spsprKdr_GetAll", commandType: CommandType.StoredProcedure);
            }
            return sprKdrs;

        }

        // Get one sprKdr based on its sprKdrID (SQL Select)
        public async Task<SprKdr> Pharm_GetOne(int id)
        {
            SprKdr sprKdr = new SprKdr();
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            using (var conn = new SqlConnection(_configuration.Value))
            {
                sprKdr = await conn.QueryFirstOrDefaultAsync<SprKdr>("spsprKdr_GetOne",parameters,commandType: CommandType.StoredProcedure);
            }
            return sprKdr;
        }

        // Update one sprKdr row based on its sprKdrID (SQL Update)
        public async Task<bool> PharmUpdate(SprKdr sprKdr)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                //parameters.Add("sprKdrID", sprKdr.sprKdrID, DbType.Int32);
                //parameters.Add("Title", sprKdr.Title, DbType.String);
                //parameters.Add("DatePublished", sprKdr.DatePublished, DbType.Date);
                //parameters.Add("IsActive", sprKdr.IsActive, DbType.Boolean);
                await conn.ExecuteAsync("spsprKdr_Update", parameters, commandType: CommandType.StoredProcedure);
            }
            return true;
        }

        // Physically delete one sprKdr row based on its sprKdrID (SQL Delete)
        public async Task<bool> PharmDelete(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            using (var conn = new SqlConnection(_configuration.Value))
            {
                await conn.ExecuteAsync("spsprKdr_Delete",parameters, commandType: CommandType.StoredProcedure);
            }
            return true;
        }

// ==============================================================================================================================
        // Читат Логин
        public Login Pharm_GetLogin(string Log, string Psw)
        {
            Login loginTmp = new Login();
            using (var conn = new SqlConnection(_configuration.Value))
            {
                // Raw SQL method
                const string query = @"SELECT * FROM SPRBUX WHERE BUXLOG=@Log AND BUXPSW=@Psw";
                var parameters = new DynamicParameters();
                parameters.Add("Log", Log, DbType.String);
                parameters.Add("Psw", Psw, DbType.String);
                loginTmp = conn.QueryFirstOrDefault<Login>(query, parameters, commandType: CommandType.Text);
            }
            return loginTmp;
        }

        // читать Меню по параметрам BuxFrm,BuxKod (SQL Select)
        //public async Task<IEnumerable<SprBuxMnu>> Pharm_GetMenu(int BuxFrm, int BuxKod)
        //{
        //    IEnumerable<SprBuxMnu> menus;
        //    var parameters = new DynamicParameters();
        //    parameters.Add("BUXFRM", BuxFrm, DbType.Int32);
        //    parameters.Add("BUXKOD", BuxKod, DbType.Int32);
        //    using (var conn = new SqlConnection(_configuration.Value))
        //    {
        //        menus = await conn.QueryAsync<SprBuxMnu>("ComSprBuxMnu", parameters, commandType: CommandType.StoredProcedure);
        //    }
        //    return menus;
        //}

        // читать справочник SprBux по параметрам BuxFrm (SQL Select)
        public async Task<IEnumerable<SprBux>> Pharm_GetSprBux(int BuxFrm,int BuxUbl)
        {
            IEnumerable<SprBux> buxs;
            var parameters = new DynamicParameters();
            parameters.Add("BUXFRM", BuxFrm, DbType.Int32);
            parameters.Add("BUXUBL", BuxUbl, DbType.Int32);
            using (var conn = new SqlConnection(_configuration.Value))
            {
                buxs = await conn.QueryAsync<SprBux>("ComSprBux", parameters, commandType: CommandType.StoredProcedure);
            }
            return buxs;
        }

        // читать справочник SprBux по параметрам BuxFrm (SQL Select)
        public async Task<List<SprKdr>> Pharm_GetSprKdr(int BuxFrm, int BuxUbl)
        {
            IEnumerable<SprKdr> kdrs;
            const string query = @"SELECT SPRKDR.*,ISNULL(KDRFAM,N'')+N'_'+LEFT(ISNULL(KDRIMA,N''),1)+N'.' + LEFT(ISNULL(KDROTC,N''),1) AS KDRFIO "+
                                  "FROM SPRKDR WHERE KDRFRM=@BuxFrm AND ISNULL(KDRUBL,0)=@BuxUbl";
            var parameters = new DynamicParameters();
            parameters.Add("BUXFRM", BuxFrm, DbType.Int32);
            parameters.Add("BUXUBL", BuxUbl, DbType.Int32);
            using (var conn = new SqlConnection(_configuration.Value))
            {
                kdrs = await conn.QueryAsync<SprKdr>(query, parameters, commandType: CommandType.Text);
            }
            return kdrs.ToList();
        }

        // читать справочник SprBux по параметрам BuxFrm (SQL Select)
        public async Task<IEnumerable<SprSttStr>> Pharm_GetSprSttStr(int BuxFrm)
        {
            IEnumerable<SprSttStr> sttstr;
            const string query = @"SELECT * FROM SprSttStr WHERE SttStrFrm=@BuxFrm AND SttStrLvl=1 ORDER BY SttStrNam ";
            var parameters = new DynamicParameters();
            parameters.Add("BUXFRM", BuxFrm, DbType.Int32);
            using (var conn = new SqlConnection(_configuration.Value))
            {
                sttstr = await conn.QueryAsync<SprSttStr>(query, parameters, commandType: CommandType.Text);
            }
            return sttstr;
        }

        // читать справочник SprBux по параметрам BuxFrm (SQL Select)
        public List<SprDlg> Pharm_GetSprDlg(int BuxFrm, string StrKey)
        {
            List<SprDlg> sprdlg;
            string query;
            if (StrKey =="") query = @"SELECT SPRDLG.DLGKOD,SPRDLG.DLGNAM FROM SprSttRsp INNER JOIN SprDlg ON SprSttRsp.SttRspDlg=SprDlg.DLGKOD " +
                                      "WHERE SprSttRsp.SttRspFrm=@BuxFrm ORDER BY DLGNAM";
            else query = @"SELECT SPRDLG.DLGKOD,SPRDLG.DLGNAM FROM SprSttRsp INNER JOIN SprDlg ON SprSttRsp.SttRspDlg=SprDlg.DLGKOD " +
                          "WHERE SprSttRsp.SttRspFrm=@BuxFrm AND SprSttRsp.SttRspKey=@StrKey ORDER BY DLGNAM";

            var parameters = new DynamicParameters();
            parameters.Add("BUXFRM", BuxFrm, DbType.Int32);
            parameters.Add("STRKEY", StrKey, DbType.String);
            using (var conn = new SqlConnection(_configuration.Value))
            {
                sprdlg = conn.Query<SprDlg>(query, parameters, commandType: CommandType.Text).ToList();
            }
            return sprdlg;
        }

        // Update one Video row based on its VideoID (SQL Update)
       public async Task<bool> Pharm_UpdSprBux(SprBux sprbux)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("ID", sprbux.Id, DbType.Int32);
                parameters.Add("BUXFRM", sprbux.BuxFrm, DbType.Int32);
                parameters.Add("BUXLOG", sprbux.BuxLog, DbType.String);
                parameters.Add("BUXPSW", sprbux.BuxPsw, DbType.String);
                parameters.Add("BUXTAB", sprbux.BuxTab, DbType.String);
                parameters.Add("BUXKEY", sprbux.BuxKey, DbType.String);
                parameters.Add("BUXDLG", sprbux.DlgNam, DbType.String);
                parameters.Add("BUXSTF", sprbux.BuxStf, DbType.Decimal);
                parameters.Add("BUXMOL", sprbux.BuxMol, DbType.Boolean);
                parameters.Add("BUXUBL", sprbux.BuxUbl, DbType.Boolean);
                await conn.ExecuteAsync("ComSprBuxRep", parameters, commandType: CommandType.StoredProcedure);
            }
            return true;
        }

        // читать Меню Бухгалтера по параметрам BuxFrm,BuxKod (SQL Select)
        public async Task<IEnumerable<SprBuxMnu>> Pharm_GetSprBuxMnu(int BuxFrm, int BuxKod)
        {
            IEnumerable<SprBuxMnu> buxmnus;
            var parameters = new DynamicParameters();
            parameters.Add("BUXFRM", BuxFrm, DbType.Int32);
            parameters.Add("BUXKOD", BuxKod, DbType.Int32);
            using (var conn = new SqlConnection(_configuration.Value))
            {
                buxmnus = await conn.QueryAsync<SprBuxMnu>("ComSprBuxMnu", parameters, commandType: CommandType.StoredProcedure);
            }
            return buxmnus;
        }

        // Update one Video row based on its VideoID (SQL Update)
        public async Task<bool> Pharm_UpdSprBuxMnu(SprBuxMnu sprbuxmnu, int BuxFrm, int BuxKod)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("BUXFRM", BuxFrm, DbType.Int32);
                parameters.Add("BUXKOD", BuxKod, DbType.Int32);
                parameters.Add("BUXNUM", sprbuxmnu.MnuBarNum, DbType.Int32);
                parameters.Add("BUXPRN", sprbuxmnu.MnuBarPrn, DbType.Int32);
                parameters.Add("BUXCLD", sprbuxmnu.MnuBarCld, DbType.Boolean);
                parameters.Add("BUXFLG", sprbuxmnu.MnuBarFlg, DbType.Boolean);
                await conn.ExecuteAsync("ComSprBuxMnuRep", parameters, commandType: CommandType.StoredProcedure);
            }
            return true;
        }

    }
}
