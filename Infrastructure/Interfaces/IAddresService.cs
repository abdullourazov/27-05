using Domain.ApiResponse;
using Domain.DTOs;
using Domain.DTOs.AdressDTO;
using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IAddresService
{
    Task<Response<List<AddresDTO>>> GetAddresAsync();
    Task<Response<AddresDTO>> GetAddresByIdAsync(int id);
    Task<Response<string>> CreateAddresByidAsync(CreateAddrresDTO createAddrresDTO);
    Task<Response<string>> UpdateAddresAsync(UpdateAddresDTO updateAddresDTO);
    Task<Response<string>> DeleteAddresAsync(int id);
}
