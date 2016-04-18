using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeChallenge;


namespace CodeChallengeUnitTest
{
    class TestClass : IItemWithId
    {
        public int Id { set; get; }
        public string msg { set; get; }
    }
}
