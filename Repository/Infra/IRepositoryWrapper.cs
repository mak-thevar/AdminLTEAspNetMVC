namespace AspMVCAdminLTE.Repository
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }

        void Save();
    }
}