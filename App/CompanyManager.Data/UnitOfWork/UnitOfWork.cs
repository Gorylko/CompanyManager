namespace CompanyManager.Data.UnitOfWork
{
    using System;

    public class UnitOfWork : IUnitOfWork
    {
        #region Fields

        private readonly IsolationContext context;
        private IDetainedPersonRepository detainedPersonRepository;
        private IDetentionCenterRepository detentionCenterRepository;
        private IDetentionRepository detentionRepository;
        private IMobilePhoneRepository mobilePhoneRepository;
        private IPolicemanRepository policemanRepository;
        private IRankRepository rankRepository;
        private IUserRepository userRepository;

        #endregion

        #region Reps

        public IsolationContext Context => context;

        public IDetainedPersonRepository DetainedPersonRepository
        {
            get => detainedPersonRepository ?? new DetainedPersonRepository(context);
            set => detainedPersonRepository = value;
        }

        public IDetentionCenterRepository DetentionCenterRepository
        {
            get => detentionCenterRepository ?? new DetentionCenterRepository(context);
            set => detentionCenterRepository = value;
        }

        public IDetentionRepository DetentionRepository
        {
            get => detentionRepository ?? new DetentionRepository(context);
            set => detentionRepository = value;
        }

        public IMobilePhoneRepository MobilePhoneRepository
        {
            get => mobilePhoneRepository ?? new MobilePhoneRepository(context);
            set => mobilePhoneRepository = value;
        }

        public IPolicemanRepository PolicemanRepository
        {
            get => policemanRepository ?? new PolicemanRepository(context);
            set => policemanRepository = value;
        }

        public IRankRepository RankRepository
        {
            get => rankRepository ?? new RankRepository(context);
            set => rankRepository = value;
        }

        public IUserRepository UserRepository
        {
            get => userRepository ?? new UserRepository(context);
            set => userRepository = value;
        }

        #endregion

        public UnitOfWork()
        {
            var options = new DbContextOptionsBuilder<IsolationContext>()
                    .EnableSensitiveDataLogging()
                    .UseSqlServer(Settings.ConnectionString).Options;

            context = new IsolationContext(options);
        }

        public void SaveChanges()
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new Exception("Error at applying context changes", ex);
            }
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new Exception("Error at applying context changes", ex);
            }
        }

        public bool Disposed { get; private set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (!Disposed && disposing)
            {
                context.Dispose();
            }

            Disposed = true;
        }
    }
}
