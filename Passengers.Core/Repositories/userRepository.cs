using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{

    //we don't ant to keep users in memory any more that's why  we will use MongoDB data base
  public  class userRepository:IUserRepository,IMongoRepository
    {
        private readonly IMongoDatabase _database;

        public userRepository(IMongodatabase dbase)
        {
            _database = dbase;
        }

        //it allows us gett acces to collection inside database
        public IMongoCollection<User> _users = _database.GetCollection<User>("Users");

        public async Task<User> Get(Guid id)
            => await _database.AsQueryable().FirstOrDefault(x => x.id == id);

        public async Task<User> Get(string emial)
            => await _database.AsQueryable().FirstOrDefault(x => x.Email == email);

        public async Task<IEnumerable<User>> GetAll()
            => await _database.AsQueryable().ToListAsync();

        public async Task Add(User user)
            => await _database.InsertOneAsync(user);

        public async Task Remove(Guid id)
            => await _database.DeleteoneAsync(x => x.id == id);

        public async Task Update(User user)
            =>await _database.ReplaceOneAsync(x=>x.id==user.id);
        

    }
}
