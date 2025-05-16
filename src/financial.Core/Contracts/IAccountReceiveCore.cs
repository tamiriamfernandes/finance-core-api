using financial.Model.Entities;

namespace financial.Core.Contracts;

public interface IAccountReceiveCore
{
    List<AccountReceive> GenerateParcels(decimal total, int numberOfInstallments, int dayOfMonth);
}
