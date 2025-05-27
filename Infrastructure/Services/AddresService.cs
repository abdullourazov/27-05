using System.Net;
using Domain.ApiResponse;
using Domain.DTOs;
using Infrastructure.Data;
using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class AddresService(DataContext context) : IAddresService
{

    public async Task<Response<List<AddresDTO>>> GetAddresAsync()
    {

        var result = await context.Addres.ToListAsync();
        var result2 = result.Select(a => new AddresDTO
        {
            City = a.City,
            Id = a.Id,
            street = a.street,
            StudentId = a.StudentId,
        }).ToList();

        return result2 == null
        ? new Response<List<AddresDTO>>("Addres not found", HttpStatusCode.NotFound)
        : new Response<List<AddresDTO>>(result2, "Address get succsesfully");
    }

    public async Task<Response<AddresDTO>> GetAddresByIdAsync(int id)
    {
        var result = await context.Addres.FindAsync(id);
        if (result == null)
            return new Response<AddresDTO>("Addres not found", HttpStatusCode.NotFound);

        var result2 = new AddresDTO
        {
            Id = result.Id,
            City = result.City,
            street = result.street,
            StudentId = result.StudentId
        };
        return new Response<AddresDTO>(result2, "Addres found succesfully");
    }

    public async Task<Response<string>> CreateAddresByidAsync(Addres addres)
    {
        await context.AddAsync(addres);
        var result = await context.SaveChangesAsync();
        return result == 0
        ? new Response<string>("Addres not found", HttpStatusCode.NotFound)
        : new Response<string>(result.ToString(), "Addres found succesfully");
    }

    public async Task<Response<string>> UpdateAddresAsync(Addres addres)
    {
        await context.Addres.FindAsync(addres.Id);
        var result = await context.SaveChangesAsync();
        return result == 0
        ? new Response<string>("Addres not found", HttpStatusCode.NotFound)
        : new Response<string>(result.ToString(), "Addres found succesfully");
    }

    public async Task<Response<string>> DeleteAddresAsync(int id)
    {
        var result = await context.Addres.FindAsync(id);
        if (result == null)
        {
            return new Response<string>("Addres not found", HttpStatusCode.NotFound);
        }
        context.Addres.Remove(result);
        await context.SaveChangesAsync();
        return new Response<string>(result.ToString(), "Addres found succesfully");
    }
}
