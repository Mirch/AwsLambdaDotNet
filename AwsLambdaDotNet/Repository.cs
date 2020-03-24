using System.Collections.Generic;

namespace AwsDotNet
{
    public class Repository
    {
        private List<string> _messages;

        public Repository()
        {
            _messages = new List<string>
            {
                "Message1",
                "Message2",
                "Message3",
                "Message4"
            };
        }

        public string GetValue(int index)
        {
            return _messages[index % _messages.Count];
        }
    }
}
