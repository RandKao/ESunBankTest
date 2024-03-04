using AutoMapper;
using ESunBankTest.Connections;
using ESunBankTest.Models;
using ESunBankTest.Models.SystemDB;
using Microsoft.EntityFrameworkCore;

namespace ESunBankTest.Providers
{
    public class DataGovProvider
    {
        private readonly conn_DataGov conn_DataGov;
        private readonly SystemDBEntities SystemDB;
        private readonly IMapper Mapper;
        public DataGovProvider(conn_DataGov conn_DataGov, SystemDBEntities SystemDB, IMapper Mapper)
        {
            this.conn_DataGov = conn_DataGov;
            this.SystemDB = SystemDB;
            this.Mapper = Mapper;
        }



        public async Task<ExecuteResult> GetData13223ToDataBaseAsync()
        {

            var ConnResult = await conn_DataGov.GetData13223Async();

            if (ConnResult == null || ConnResult.Count == 0)
                return new ExecuteResult() { Success = false, Message = "取得資料失敗" };

            var EntityList = Mapper.Map<List<GovData13223>>(ConnResult);

            using (var Trans = SystemDB.Database.BeginTransaction())
            {
                try
                {

                    SystemDB.GovData13223.RemoveRange(SystemDB.GovData13223);
                    SystemDB.GovData13223.AddRange(EntityList);

                    await SystemDB.SaveChangesAsync();
                    await Trans.CommitAsync();
                }
                catch (Exception ex)
                {
                    await Trans.RollbackAsync();
                    return new ExecuteResult() { Success = false, Message = $"儲存失敗，{ex.Message}" };
                }
            }

            return new ExecuteResult() { Success = true, Message = $"取得並儲存成功! 共有 {EntityList.Count} 筆資料" };
        }

        public async Task<ExecuteResult> GetData13223FromDataBaseAsync()
        {
            var EntityList = await (from x in SystemDB.GovData13223 select x).ToListAsync();
            return new ExecuteResult() { Success = true, Data = new() { EntityList } };

        }
    }
}
