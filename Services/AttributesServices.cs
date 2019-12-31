using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TuringEcommerce.Models;
using TuringEcommerce.Services.Interfaces;

namespace TuringEcommerce.Services
{
    public class AttributesServices:IAttributesServices
    {
        private readonly TuringContext Context;

        public AttributesServices(TuringContext context)
        {
            Context = context;
        }

        public async Task<IEnumerable<Attribute>> GetAllAttributes()
        {
            return await Context.Attribute.AsNoTracking().ToListAsync();
        }

        public async Task<Attribute> GetAttributeById(int id)
        {
            return await Context.Attribute.FirstOrDefaultAsync(x => x.AttributeId == id);
        }

        public async Task<IEnumerable> GetAllAtributesValuesByAttributeId(int id)
        {
            var attribute = await Context
                .AttributeValue
                .Where(d => d.AttributeId == id)
                .Select(a => new 
                {
                    AttributeValueId = a.AttributeValueId,
                    Value = a.Value
                })
                .ToListAsync();
            return attribute;
        }

        public async Task<IEnumerable> GetAllAttributesOfAProductByProductId(int id)
        {
            var productAttributeValues = from productAttribute in Context.ProductAttribute
                join attributeValue in Context.AttributeValue on productAttribute.AttributeValueId equals attributeValue.AttributeValueId
                join attribute in Context.Attribute on attributeValue.AttributeId equals attribute.AttributeId
                where productAttribute.ProductId == id
                select new 
                {
                    AttributeValueId = attributeValue.AttributeValueId,
                    AttributeValue = attributeValue.Value,
                    AttributeName = attribute.Name
                };

            return await productAttributeValues.ToListAsync();
        }
    }
}