using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using To_Do_Flip.DataAccess.DbContext;
using To_Do_Flip.DataAccess.Entity;
using To_Do_Flip.Store.Model;

namespace To_Do_Flip.Application.Repository;

public class To_Do_Flip_Repository : To_Do_Flip_IRepository
{
    private readonly To_Do_Flip_Context _context;
    public To_Do_Flip_Repository(To_Do_Flip_Context context)
    {
        _context = context;
    }

    public async Task<List<To_Do>> GetTo_Do_Flip_Entities()
    {
        var to_Do_Flip_Entities = await _context.To_Do_Flip_Entities
            .AsNoTracking()
            .ToListAsync();
        
        var todo = to_Do_Flip_Entities 
            .Select(t => To_Do.Create(t.Id,t.Description,t.Name).to_Do )
            .ToList();
        return todo;
    }

    public async Task<Guid> CreateTo_Do_Flip_Entity(To_Do to_Do)
    {
        var to_Do_Flip_Entity = new To_Do_Flip_Entity
        {
            Name = to_Do.Name,
            Description = to_Do.Description,
            Id = to_Do.Id
        };
        
        await _context.To_Do_Flip_Entities.AddAsync(to_Do_Flip_Entity);
        await _context.SaveChangesAsync();
        
        return to_Do_Flip_Entity.Id;
    }

    public async Task<Guid> UpdateTo_Do_Flip_Entity(Guid id, string name, string description)
    {
        await _context.To_Do_Flip_Entities
            .Where(t => t.Id == id)
            
            .ExecuteUpdateAsync(s => s
                .SetProperty(t => t.Name, name)
                .SetProperty(t => t.Description, description));
        
        return id;
    }

    public async Task<Guid> DeleteTo_Do_Flip_Entity(Guid id)
    {
        await _context.To_Do_Flip_Entities
            .Where(t => t.Id == id)
            .ExecuteDeleteAsync();
        return id;
    }
}