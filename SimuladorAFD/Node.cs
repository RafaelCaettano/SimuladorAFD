namespace Automato
{
    public class Node
    {
        public string Name;
        public bool End;
        public bool Start;

        private List<Connection> _connections;
        public List<Connection> Connections
        {
            get { return _connections; }
            set { _connections = value; }
        }

		public Node()
        {
            _connections = new List<Connection>();
            Name = "";
            End = false;
            Start = false;
		}

		public AutomatonErrors? AddConnection(string nodeName, char symbol)
		{
			AutomatonErrors? error = null;

			Connection connection = new Connection
			{
				NodeName = nodeName,
                Symbol = symbol
            };

			if (GetConnectionBySymbol(symbol) == null)
				_connections.Add(connection);
			else
				error = AutomatonErrors.ConnectionAlreadyExist;

			return error;
		}

		private Connection? GetConnectionBySymbol(char symbol) => _connections.FirstOrDefault(c => c.Symbol == symbol);
    }
}