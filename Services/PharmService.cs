using Dapper;
using DauaPharm.Data;
using DauaPharm.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BlazorDapperCRUD.Data
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
           // return new Login() { OrgKod = loginTmp.OrgKod, BuxKod = loginTmp.BuxKod };

        }


    }
}
