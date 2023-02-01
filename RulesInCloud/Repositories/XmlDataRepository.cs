using Microsoft.EntityFrameworkCore;
using RulesInCloud.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RulesInCloud.Repositories
{
    public class XmlDataRepository
    {
        private static readonly string ParameterMissingMessage = "parameter cannot be null";
        private readonly XmlDataContext dbContext;
        public XmlDataRepository(XmlDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<XMLData> GetXmlDataByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(ParameterMissingMessage);

            return await dbContext.xmlData.WithPartitionKey(name)?.FirstOrDefaultAsync();
        }

        public async Task<List<XMLData>> GetAllXmlData()
        {
            return await dbContext.xmlData.ToListAsync();
        }

        public async Task SaveXMLData(string name, string value)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(ParameterMissingMessage);

            dbContext.Add(
                new XMLData
                {
                    id = Guid.NewGuid().ToString(),
                        name = name,
                        value = value
                    });
            await dbContext.SaveChangesAsync();
        }
    }
}
