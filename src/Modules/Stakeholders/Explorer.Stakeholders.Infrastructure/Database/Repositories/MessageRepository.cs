using Explorer.BuildingBlocks.Core.Domain;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Infrastructure.Database.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly StakeholdersContext _dbContext;
        private readonly DbSet<Message> _dbSet;

        public MessageRepository(StakeholdersContext dbContext) 
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Message>();
        }

        public Message Create(Message message)
        {
            var messageSender = _dbContext.Users.FirstOrDefault(u => u.Id == message.SenderId);
            if(messageSender == null) throw new ArgumentException("Sender with id " + message.SenderId + " does not exist");
            var messageRecipient = _dbContext.Users.FirstOrDefault(u => u.Id == message.RecipientId);
            if (messageRecipient == null) throw new ArgumentException("Recipient with id " + message.RecipientId + " does not exist");

            _dbContext.Messages.Add(message);
            _dbContext.SaveChanges();
            return message;
        }

        public PagedResult<Message> GetPaged(int page, int pageSize)
        {
            var task = _dbSet.GetPagedById(page, pageSize);
            task.Wait();
            return task.Result;
        }

        public void Delete(int messageId)
        {
            var message = _dbContext.Messages.FirstOrDefault(m => m.Id == messageId);
            if (message == null) throw new KeyNotFoundException("Not found: " + messageId);
            _dbContext.Messages.Remove(message);
            _dbContext.SaveChanges();
        }
    }
}
