using TorgObjects.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using TorgObjects.ApplicationServices.Ports.Gateways.Database;

namespace TorgObjects.InfrastructureServices.Gateways.Database
{
    public class TorgEFSqliteGateway : ITorgDatabaseGateway
    {
        private readonly TorgContext _TorgContext;

        public TorgEFSqliteGateway(TorgContext TorgContext)
            => _TorgContext = TorgContext;

        public async Task<TorgPoint> GetTorgPoint(long id)
           => await _TorgContext.TorgPoints.Include(mp => mp.IsPechatProducts).Where(mp => mp.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<TorgPoint>> GetAllTorgPoints()
            => await _TorgContext.TorgPoints.Include(mp => mp.IsPechatProducts).ToListAsync();
          
        public async Task<IEnumerable<TorgPoint>> QueryTorgPoints(Expression<Func<TorgPoint, bool>> filter)
            => await _TorgContext.TorgPoints.Include(mp => mp.IsPechatProducts).Where(filter).ToListAsync();

        public async Task AddTorgPoint(TorgPoint Torgpoint)
        {
            _TorgContext.TorgPoints.Add(Torgpoint);
            await _TorgContext.SaveChangesAsync();
        }

        public async Task UpdateTorgPoint(TorgPoint Torgpoint)
        {
            _TorgContext.Entry(Torgpoint).State = EntityState.Modified;
            await _TorgContext.SaveChangesAsync();
        }

        public async Task RemoveTorgPoint(TorgPoint Torgpoint)
        {
            _TorgContext.TorgPoints.Remove(Torgpoint);
            await _TorgContext.SaveChangesAsync();
        }

    }
}
