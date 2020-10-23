using AccountLibrary.API.Entities;
using System;
using System.Collections.Generic;

namespace AccountLibrary.API.Services
{
    public interface IAccountLibraryRepository
    {       
       IEnumerable<AccountTransaction> GetAccountTransactionsByID(string accountNumber);

    }
}
