namespace AspMVCAdminLTE.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repositoryContext;
        private IUserRepository _user;
        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            this._repositoryContext = repositoryContext;
        }
        public IUserRepository User => _user??new UserRepository(_repositoryContext);

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}