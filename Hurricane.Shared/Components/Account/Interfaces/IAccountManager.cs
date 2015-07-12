using Hurricane.Shared.Objects.Interfaces;

namespace Hurricane.Shared.Components.Account.Interfaces
{
    public interface IAccountManager : IHurricaneComponent
    {
        IAccountResult GetAccount(IAccountRequest account);
    }
}