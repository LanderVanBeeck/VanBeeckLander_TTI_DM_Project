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
                    .Include(x => x.Wallet)
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

        public static int UpdateUser(User user)
        {
            try
            {
                using (TwitchEntities entities = new TwitchEntities())
                {
                    entities.Entry(user).State = EntityState.Modified;
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }

        public static int DeletePrime(Prime prime)
        {
            try
            {
                using (TwitchEntities entities = new TwitchEntities())
                {
                    entities.Entry(prime.UserPrime).State = EntityState.Deleted;
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }

        public static int DeleteUser(User user)
        {
            try
            {
                using (TwitchEntities entities = new TwitchEntities())
                {
                    entities.Entry(user).State = EntityState.Deleted;
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }

        public static User OphalenUserOpUserID(int userid)
        {
            using (TwitchEntities entities = new TwitchEntities())
            {
                var query = entities.User
                    .Where(x => x.userId == userid)
                    .OrderBy(x => x.userId);
                return query.SingleOrDefault();
            }
        }
    }
}
