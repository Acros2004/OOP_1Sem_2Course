using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace lab04
{
    class NullCollectionException : Exception
    {
        public NullCollectionException(string message) : base(message) { }
    }
    class MaxCollection : OverflowException
    {
        public MaxCollection(string message) : base(message) { }
    }
    class DeleteNullObject : Exception
    {
        public DeleteNullObject(string message) : base(message) { }
    }
    class TestNullClass : NullReferenceException
    {
        public TestNullClass(string message) : base(message) { }
    }
}
