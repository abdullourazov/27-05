using System.Net;
using Domain.ApiResponse;
using Domain.DTOs;
using Domain.DTOs.GroupDTO;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class GroupService(DataContext context) : IGroupService
{
    public async Task<Response<string>> CreateGroupAsunc(CreateGroupDTO createGroupDTO)
    {
        await context.AddAsync(createGroupDTO);
        var result = await context.SaveChangesAsync();
        return result == 0
        ? new Response<string>("Group not found", HttpStatusCode.NotFound)
        : new Response<string>(result.ToString(), "Group found succesfully");
    }

    public async Task<Response<string>> DeleteGroupServerAsync(int id)
    {
        var result = await context.Groups.FindAsync(id);
        if (result == null)
        {
            return new Response<string>("Group not found", HttpStatusCode.NotFound);
        }
        context.Groups.Remove(result);
        await context.SaveChangesAsync();
        return new Response<string>(result.ToString(), "Group found succesfully");
    }

    public async Task<Response<List<GroupDTOok>>> GetGroupAsync()
    {
        var result = await context.Groups.ToListAsync();
        var result2 = result.Select(g => new GroupDTOok
        {
            Id = g.Id,
            Name = g.Name,
            RequiredStudents = g.RequiredStudents,
            StarteAt = g.StarteAt,
            EndedAt = g.EndedAt,
            CourseId = g.CourseId

        }).ToList();

        return result2 == null
        ? new Response<List<GroupDTOok>>("Group not found", HttpStatusCode.NotFound)
        : new Response<List<GroupDTOok>>(result2, "Group get succesfully");

    }

    public Task<Response<GroupDTOok>> GetGroupByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<string>> UpdateGroupServerAsync(UpdateGroupDTO updateGroupDTO)
    {
        await context.Groups.FindAsync(updateGroupDTO.Id);
        var result = await context.SaveChangesAsync();
        return result == 0
        ? new Response<string>("Group not found", HttpStatusCode.NotFound)
        : new Response<string>(result.ToString(), "Group found succesfully");
    }
}
