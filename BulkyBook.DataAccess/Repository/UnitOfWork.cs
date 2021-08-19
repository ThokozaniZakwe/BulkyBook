using BulkyBook.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulkyBook.DataAccess.Data;

namespace BulkyBook.DataAccess.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(db);
            SP_Call = new SP_Call(db);
        }

        public ICategoryRepository Category { get; private set; }
        public ISP_Call SP_Call { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
