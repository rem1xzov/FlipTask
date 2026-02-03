using To_Do_Flip.Store.Model;

namespace To_Do_Flip.Application.Service;

public interface To_Do_Flip_IService
{
    Task<List<To_Do>> GetAllTask();
    Task<Guid> CreateTask(To_Do to_Do);
    Task<Guid> UpdateTask(Guid id, string name, string description);
    Task<Guid> DeleteTask(Guid id);
}