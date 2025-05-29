using Domain.ApiResponse;
using Domain.DTOs;
using Domain.DTOs.AdressDTO;
using Domain.DTOs.GroupDTO;
using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IGroupService
{
    Task<Response<List<GroupDTOok>>> GetGroupAsync();
    Task<Response<GroupDTOok>> GetGroupByIdAsync(int id);
    Task<Response<string>> CreateGroupAsunc(CreateGroupDTO createGroupDTO);
    Task<Response<string>> UpdateGroupServerAsync(UpdateGroupDTO updateGroupDTO);
    Task<Response<string>> DeleteGroupServerAsync(int id);

}
