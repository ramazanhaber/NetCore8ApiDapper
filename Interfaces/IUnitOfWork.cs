using NetCore8ApiDapper.Repository;

namespace NetCore8ApiDapper.Interfaces
{
    public interface IUnitOfWork
    {
        IOgrencilerRepository Ogrenciler { get; }
        INotlarRepository Notlar { get; }
    }

}
