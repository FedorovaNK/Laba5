using TorgObjects.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TorgObjects.ApplicationServices.Ports.Gateways.Database
{
    public interface ITorgDatabaseGateway
    {
        Task AddTorgPoint(TorgPoint Torgpoint);

        Task RemoveTorgPoint(TorgPoint Torgpoint);

        Task UpdateTorgPoint(TorgPoint Torgpoint);

        Task<TorgPoint> GetTorgPoint(long id);

        Task<IEnumerable<TorgPoint>> GetAllTorgPoints();

        Task<IEnumerable<TorgPoint>> QueryTorgPoints(Expression<Func<TorgPoint, bool>> filter);

    }
}
