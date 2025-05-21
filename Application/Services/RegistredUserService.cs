using Application.ViewModels;
using Core.Entities;
using Core.Interfaces;

namespace Application.Services;

public class RegistredUserService
{
    private readonly IGenericRepoitory<RegistredUser> _repo;
    public RegistredUserService(IGenericRepoitory<RegistredUser> repoitory)
    {
        _repo = repoitory;
    }

    public async Task<IEnumerable<RegistredUser>> GeAllAsync()
    {
      return await _repo.GetAllAsync();
    }

    public async Task<RegistredUser?> GetRegisterById(int id)
    {
        return await _repo.GetByIdAsync(id);
    }

    public async Task<bool> CreateRegisterUser(RegistredUserModelView model)
    {
        var record = new RegistredUser {
            Email = model.Email,
            IsActive= true,
            Name = model.Name,
            Profile = new UserProfile {
             AvatarUrl ="sampleTestUrl",
             NickName = "Testnickname"            
            }
        
        };

       var value =   await _repo.AddAsync(record);
       return true;
    }

    public async Task<bool> DeleteRegisterUser(int id)
    {       
        await _repo.DeleteAsync(id);       
        return true;
    }


}
