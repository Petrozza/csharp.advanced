using System;
using System.Collections.Generic;
using System.Text;

namespace Border.Control
{
    public class Robot : IIdentified
    {
        public Robot(string model, string id)
        {
            Id = id;
        }
        public string Id { get; private set;  }
    }
}
