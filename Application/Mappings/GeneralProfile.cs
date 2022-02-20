using Application.Features.Clients.Commands.CreateClientCommand;
using Domain.Entities;
using AutoMapper;

namespace Application.Mappings;

public class GeneralProfile : Profile
{
    public GeneralProfile()
    {
        CreateMap<CreateClientCommand, Client>();
    }
}