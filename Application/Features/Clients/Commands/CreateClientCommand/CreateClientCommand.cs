using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Clients.Commands.CreateClientCommand;

public class CreateClientCommand : IRequest<Response<int>>
{
    public string Name { get; set; }
    public string FamilyName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
}

public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Response<int>>
{

    private readonly IRepositoryAsync<Client> _clientRepository;
    private readonly IMapper _mapper;
    public CreateClientCommandHandler(IRepositoryAsync<Client> clientRepository, IMapper mapper)
    {
        _clientRepository = clientRepository;
        _mapper = mapper;
    }
    
    public async Task<Response<int>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        var clientRegister = _mapper.Map<Client>(request);
        var data = _clientRepository.AddAsync(clientRegister);
        return new Response<int>(data.Id);
    }
}