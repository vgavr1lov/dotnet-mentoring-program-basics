using System;
using System.Linq;
using Task3.DoNotChange;
using Task3.Exceptions;

namespace Task3
{
   public class UserTaskService
   {
      private readonly IUserDao _userDao;

      public UserTaskService(IUserDao userDao)
      {
         _userDao = userDao;
      }

      //public int AddTaskForUser(int userId, UserTask task)
      //{
      //   if (userId < 0)
      //      return -1;

      //   var user = _userDao.GetUser(userId);
      //   if (user == null)
      //      return -2;

      //   var tasks = user.Tasks;
      //   foreach (var t in tasks)
      //   {
      //      if (string.Equals(task.Description, t.Description, StringComparison.OrdinalIgnoreCase))
      //         return -3;
      //   }

      //   tasks.Add(task);

      //   return 0;
      //}

      public void AddTaskForUser(int userId, UserTask task)
      {
         if (userId < 0)
            throw new InvalidUserIdException();

         var user = _userDao.GetUser(userId) ?? throw new UserNotFoundException();

         if (user.Tasks.Any(t => string.Equals(task.Description, t.Description, StringComparison.OrdinalIgnoreCase)))
            throw new TheTaskAlreadyExistsException();


         user.Tasks.Add(task);
      }
   }
}