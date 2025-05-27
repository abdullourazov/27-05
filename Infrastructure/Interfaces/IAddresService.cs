using Domain.ApiResponse;
using Domain.DTOs;
using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IAddresService
{
    Task<Response<List<AddresDTO>>> GetAddresAsync();
    Task<Response<AddresDTO>> GetAddresByIdAsync(int id);
    Task<Response<string>> CreateAddresByidAsync(Addres addres);
    Task<Response<string>> UpdateAddresAsync(Addres addres);
    Task<Response<string>> DeleteAddresAsync(int id);
}
