using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Encounters.Core.Domain;
using Explorer.Encounters.Core.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Encounters.Infrastructure.Database.Repositories
{
    public class QuestionDatabaseRepository : CrudDatabaseRepository<Question, EncountersContext>, IQuestionRepository
    {
        private readonly DbSet<Question> _dbSet;

        public QuestionDatabaseRepository(EncountersContext dbContext) : base(dbContext)
        {
            _dbSet = dbContext.Set<Question>();
        }


        public PagedResult<Question> GetAllByEncounterId(long encounterId, int page, int pageSize)
        {
            var task = _dbSet.Where(q => EF.Property<long>(q, "EncounterId") == encounterId).GetPagedById(page, pageSize);

            task.Wait();
            return task.Result;
        }

    }
}
