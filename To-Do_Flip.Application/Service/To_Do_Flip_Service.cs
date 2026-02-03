using To_Do_Flip.Application.Repository;
using To_Do_Flip.Store.Model;

namespace To_Do_Flip.Application.Service;

public class To_Do_Flip_Service : To_Do_Flip_IService
{
    private readonly To_Do_Flip_IRepository _to_Do_Flip_IRepository;
    public To_Do_Flip_Service(To_Do_Flip_IRepository to_Do_Flip_IRepository)
    {
        _to_Do_Flip_IRepository = to_Do_Flip_IRepository;
    }

    public async Task<List<To_Do>> GetAllTask()
    {
        return await _to_Do_Flip_IRepository.GetTo_Do_Flip_Entities();
    }

    public async Task<Guid> CreateTask(To_Do to_Do)
    {
        return await _to_Do_Flip_IRepository.CreateTo_Do_Flip_Entity(to_Do);
    }

    public async Task<Guid> UpdateTask(Guid id, string name, string description)
    {
        return await _to_Do_Flip_IRepository.UpdateTo_Do_Flip_Entity(id, name, description);
    }

    public async Task<Guid> DeleteTask(Guid id)
    {
        return await _to_Do_Flip_IRepository.DeleteTo_Do_Flip_Entity(id);
    }
}