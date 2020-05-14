using TorgObjects.ApplicationServices.Ports.Gateways.Database;
using TorgObjects.DomainObjects;
using TorgObjects.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TorgObjects.ApplicationServices.Repositories
{
    public class DbTorgPointRepository : IReadOnlyTorgPointRepository,
                                     ITorgPointRepository
    {
        private readonly ITorgDatabaseGateway _databaseGateway;

        public DbTorgPointRepository(ITorgDatabaseGateway databaseGateway)
            => _databaseGateway = databaseGateway;

        public async Task<TorgPoint> GetTorgPoint(long id)
            => await _databaseGateway.GetTorgPoint(id);

        public async Task<IEnumerable<TorgPoint>> GetAllTorgPoints()
            => await _databaseGateway.GetAllTorgPoints();

        public async Task<IEnumerable<TorgPoint>> QueryTorgPoints(ICriteria<TorgPoint> criteria)
            => await _databaseGateway.QueryTorgPoints(criteria.Filter);

        public async Task AddTorgPoint(TorgPoint Torgpoint)
            => await _databaseGateway.AddTorgPoint(Torgpoint);

        public async Task RemoveTorgPoint(TorgPoint Torgpoint)
            => await _databaseGateway.RemoveTorgPoint(Torgpoint);

        public async Task UpdateTorgPoint(TorgPoint Torgpoint)
            => await _databaseGateway.UpdateTorgPoint(Torgpoint);
    }
}
