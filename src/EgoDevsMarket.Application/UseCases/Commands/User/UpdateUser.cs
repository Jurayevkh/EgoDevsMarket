using EgoDevsMarket.Application.DTO.User;
using MediatR;

namespace EgoDevsMarket.Application.UseCases.Commands.User;

public class UpdateUser:IRequest<UserResultDTO>
{
    public int Id{get;set;}
    public string? FirstName {get;set;}
    public string? LastName{get;set;}
    public DateTimeOffset BirthDate{get;set;}
    public string? Gender{get;set;}
    public string? Email {get;set;}
    public string? PhoneNumber{get;set;}
    public string? Role{get;set;}
   
}