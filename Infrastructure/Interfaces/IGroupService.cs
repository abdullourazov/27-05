using Domain.ApiResponse;
using Domain.DTOs;
using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IGroupService
{
    Task<Response<List<GroupDTO>>> GetGroupAsync();
    Task<Response<GroupDTO>> GetGroupByIdAsync(int id);
    Task<Response<string>> CreateGroupAsunc(Group group);
    Task<Response<string>> UpdateGroupServerAsync(Group group);
    Task<Response<string>> DeleteGroupServerAsync(int id);

}
