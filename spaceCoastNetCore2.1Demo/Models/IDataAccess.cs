using System;
using System.Collections.Generic;

namespace spaceCoastNetCore2.Demo.Models
{
    public interface IDataAccess
    {
        void InsertName(string Name);

        Name GetName(int id);

        void DeleteName(int Id);

        void UpdateName(int Id, string Name);

        List<Name> GetNames();
    }
}
