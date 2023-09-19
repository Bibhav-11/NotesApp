using NotesApp.Models;
using System.Collections.Generic;

namespace NotesApp.Interface
{
    public interface IUserRepository
    {
            Task<bool> Authenticate(string username, string password);
            Task<List<string>> GetUserNames();
    }
}
