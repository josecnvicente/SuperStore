using Account.Entities;
using AutoMapper;

namespace Account.UseCases.ChangeEmail;

public class ChangeEmailMapper : Profile
{
    public ChangeEmailMapper()
    {
        CreateMap<ChangeEmailRequest, UserAccount>()
            .ForMember(x => x.Id,
            y => y.MapFrom(z => z.accountId))
            .ForMember(x => x.Email,
            y => y.MapFrom(z => z.newEmail))
            .ForMember(x => x.Password,
            y => y.MapFrom(z => z.password));
    }
}