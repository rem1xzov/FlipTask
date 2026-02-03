using To_Do_Flip.Store.Model;

namespace To_Do_Flip.Application.Repository;

public interface To_Do_Flip_IRepository
{
    Task<List<To_Do>> GetTo_Do_Flip_Entities();
    Task<Guid> CreateTo_Do_Flip_Entity(To_Do to_Do);
    Task<Guid> UpdateTo_Do_Flip_Entity(Guid id, string name, string description);
    Task<Guid> DeleteTo_Do_Flip_Entity(Guid id);
}