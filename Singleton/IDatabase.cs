using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton
{
    public interface IDatabase
    {
        int GetPopulation(string name);
    }

}
