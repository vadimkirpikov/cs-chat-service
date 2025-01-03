using AutoMapper;
using ChatService.Repositories;

namespace ChatService.Services;


public interface IService<T, in TDto> where T : class where TDto : class
{
    Task<T> CreateAsync(TDto entityDto);
    Task UpdateAsync(int id, TDto entityDto);
    Task DeleteAsync(int id);
    Task<T> GetAsync(int id);
}
public class Service<T, TDto>(IRepository<T> repository, IMapper mapper): IService<T, TDto> where T : class where TDto : class
{
    private async Task<T> TryGetByIdAsync(int id)
    {
        var entity = await repository.GetAsync(id);
        if (entity == null)
        {
            throw new KeyNotFoundException();
        }
        return entity;
    }
    public async Task<T> CreateAsync(TDto entityDto)
    {
        var entity = mapper.Map<T>(entityDto);
        await repository.CreateAsync(entity);
        return entity;
    }

    public async Task UpdateAsync(int id, TDto entityDto)
    {
        var entity = await TryGetByIdAsync(id);
        entity = mapper.Map(entityDto, entity);
        await repository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await TryGetByIdAsync(id);
        await repository.DeleteAsync(entity);
    }

    public async Task<T> GetAsync(int id)
    {
        return await TryGetByIdAsync(id);
    }
}