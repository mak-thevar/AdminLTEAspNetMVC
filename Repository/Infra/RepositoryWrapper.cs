namespace AspMVCAdminLTE.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repositoryContext;
        private IUserRepository _user;

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            this._repositoryContext = repositoryContext;
            this._user = new UserRepository(repositoryContext);
        }

        public IUserRepository User => _user;

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}