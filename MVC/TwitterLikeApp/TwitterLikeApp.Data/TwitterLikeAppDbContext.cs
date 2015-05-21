namespace TwitterLikeApp.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;

    using TwitterLikeApp.Data.Models;

    public class TwitterLikeAppDbContext : IdentityDbContext<User>
    {
        public TwitterLikeAppDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static TwitterLikeAppDbContext Create()
        {
            return new TwitterLikeAppDbContext();
        }
    }
}
