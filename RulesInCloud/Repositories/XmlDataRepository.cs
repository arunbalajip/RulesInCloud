using Microsoft.EntityFrameworkCore;
using RulesInCloud.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RulesInCloud.Repositories
{
    public class XmlDataRepository
    {
        private readonly XmlDataContext dbContext;

        public XmlDataRepository(XmlDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<XMLData> GetXmlDataByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("name cannot be null or empty", nameof(name));

            return await dbContext.xmlData.WithPartitionKey(name)?.FirstOrDefaultAsync();
        }

        public async Task<List<XMLData>> GetAllXmlData()
        {
            return await dbContext.xmlData.ToListAsync();
        }

        public async Task SaveXMLData(string name, string value)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("name cannot be null or empty", nameof(name));
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("value cannot be null or empty", nameof(value));

            dbContext.Add(new XMLData
            {
                id = Guid.NewGuid().ToString(),
                name = name,
                value = value
            });
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateXMLData(XMLData existing, string newValue)
        {
            if (existing == null)
                throw new ArgumentNullException(nameof(existing));
            if (string.IsNullOrWhiteSpace(newValue))
                throw new ArgumentException("newValue cannot be null or empty", nameof(newValue));

            existing.value = newValue;
            dbContext.Update(existing);
            await dbContext.SaveChangesAsync();
        }
    }
}
