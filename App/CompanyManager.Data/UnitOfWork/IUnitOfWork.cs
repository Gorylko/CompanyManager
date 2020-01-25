namespace CompanyManager.Data.UnitOfWork
{
    using System;
    using System.Threading.Tasks;
    using CompanyManager.Data.Context;

    public interface IUnitOfWork : IDisposable
    {
        CompanyManagerContext Context { get; }

        #region Repositories

        //IDetainedPersonRepository DetainedPersonRepository { get; set; }
        //IDetentionCenterRepository DetentionCenterRepository { get; set; }
        //IDetentionRepository DetentionRepository { get; set; }
        //IMobilePhoneRepository MobilePhoneRepository { get; set; }
        //IPolicemanRepository PolicemanRepository { get; set; }
        //IRankRepository RankRepository { get; set; }
        //IUserRepository UserRepository { get; set; }
        #endregion

        void SaveChanges();

        Task SaveChangesAsync();

        bool Disposed { get; }
    }
}
