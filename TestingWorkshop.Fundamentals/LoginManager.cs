﻿using System.Threading.Tasks;

namespace TestingWorkshop.Fundamentals
{
    public class LoginManager
    {
        private readonly IDatabase _database;

        public LoginManager(IDatabase database)
        {
            _database = database;
        }

        public async Task<bool> HasLoginFailedAsync(int userId, int maxFailedLoginCount)
        {
            var userFailedLoginCount = await _database.GetUserFailedLoginCountAsync(userId);
            return userFailedLoginCount >= maxFailedLoginCount;
        }

        public async Task<bool> HasSessionTimedOutAsync(int userId, int maxSessionDuration)
        {
            var userSessionDuration = await _database.GetUserFailedLoginCountAsync(userId);
            return userSessionDuration >= maxSessionDuration;
        }
    }
}
