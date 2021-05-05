using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace Twitch_DAL
{
    public static class DatabaseOperations
    {
        public static List<User> OphalenUsers()
        {
            using (TwitchEntities entities = new TwitchEntities())
            {
                var query = entities.User
                    .Include(x => x.Wallets)
                    .OrderBy(x => x.displayname)
                    .ThenBy(x => x.username);
                return query.ToList();
            }
        }

        public static List<User> OphalenUsersOpDisplayname(string displayname)
        {
            using (TwitchEntities entities = new TwitchEntities())
            {
                var query = entities.User
                    .Where(x => x.displayname == displayname)
                    .OrderBy(x => x.displayname)
                    .ThenBy(x => x.username);
                return query.ToList();
            }
        }

        public static List<User> OphalenUsersOpTaal(string taal)
        {
            using (TwitchEntities entities = new TwitchEntities())
            {
                var query = entities.User
                    .Where(x => x.language == taal)
                    .OrderBy(x => x.language)
                    .ThenBy(x => x.displayname);
                return query.ToList();
            }
        }

        public static int ToevoegenUser(User user)
        {
            try
            {
                using (TwitchEntities entities = new TwitchEntities())
                {
                    entities.User.Add(user);
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }
    }
}
