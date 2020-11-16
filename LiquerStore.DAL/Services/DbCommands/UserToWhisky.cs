namespace LiquerStore.DAL.Services.DbCommands
{
    public interface IUserToWhisky
    {
    }

    public class UserToWhiskyService : IUserToWhisky
    {
        private ApplicationDbContext db;

        public UserToWhiskyService(ApplicationDbContext db)
        {
            this.db = db;
        }
    }
}