using Application.Interfaces;
using Application.Wrappers;
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

    public async Task<Response<int>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}