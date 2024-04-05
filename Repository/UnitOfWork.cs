using NetCore8ApiDapper.Interfaces;

namespace NetCore8ApiDapper.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        public UnitOfWork(IOgrencilerRepository ogrenciler,INotlarRepository notlar)
        {
            this.Ogrenciler = ogrenciler;
            this.Notlar = notlar;
        }
        public IOgrencilerRepository Ogrenciler { get; }

        public INotlarRepository Notlar { get; }

    }

}
