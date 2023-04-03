namespace Automato
{
    public class Automaton
    {
        private List<Node> _nodes;
        public IReadOnlyList<Node> Nodes => _nodes;

        private List<char> _alphabet;
        public IReadOnlyList<char> Alphabet => _alphabet;

        public Automaton()
		{
			_nodes = new List<Node>();
			_alphabet = new List<char>();
		}

        public bool ValidateWord(string word)
        {
            Node? startNode = GetStartNode();
            if (startNode == null)
                return false;

            Node? actualNode = startNode;
            foreach (char symbol in word)
            {
                if (actualNode == null)
                    return false;

                Connection? connection = actualNode.Connections.Find(c => c.Symbol == symbol);
                if (connection == null)
                    return false;

                actualNode = GetNodeByName(connection.NodeName);
            }

            return actualNode.End;
        }

        public void SetAlphabet(char[] symbols)
        {
            _alphabet.Clear();
            _alphabet.AddRange(symbols);
        }

		public AutomatonErrors? AddNode(string nodeName, bool start = false, bool end = false)
		{
            var newNode = new Node()
			{
				Name = nodeName,
				Start = start,
				End = end
			};

            AutomatonErrors? error = ValidateAddNode(newNode);
            if (error == null)
                _nodes.Add(newNode);

			return error;
        }

        public AutomatonErrors? AddConnection(string originNodeName, string destinyNodeName, int alphabetIndex)
        {
            AutomatonErrors? error = ValidateAddConnection(originNodeName, destinyNodeName, alphabetIndex);
            if (error == null)
            {
                int originNodeIndex = GetNodeIndexByName(originNodeName);
                error = _nodes[originNodeIndex].AddConnection(destinyNodeName, _alphabet[alphabetIndex]);
            }

            return error;
        }

        private AutomatonErrors? ValidateAddNode(Node newNode)
        {
            AutomatonErrors? error = null;

            if (GetStartNode() != null && newNode.Start)
                error = AutomatonErrors.StartNodeAlreadyExist;
            else if (GetNodeByName(newNode.Name) != null)
                error = AutomatonErrors.NodeAlreadyExist;

            return error;
        }

        private AutomatonErrors? ValidateAddConnection(string originNodeName, string destinyNodeName, int alphabetIndex)
        {
            AutomatonErrors? error = null;

            if (GetNodeByName(originNodeName) == null)
                error = AutomatonErrors.OriginNodeNotFound;
            else if (GetNodeByName(destinyNodeName) == null)
                error = AutomatonErrors.DestinyNodeNotFound;
            else if (alphabetIndex >_alphabet.Count - 1 || alphabetIndex < 0)
                error = AutomatonErrors.AlphabetIndexNotFound;

            return error;
        }

        private Node? GetNodeByName(string name) => _nodes.Find(node => node.Name == name);
        private int GetNodeIndexByName(string name) => _nodes.FindIndex(node => node.Name == name);
        private Node? GetStartNode() => _nodes.Find(node => node.Start);
    }

    public enum AutomatonErrors
    {
        StartNodeAlreadyExist,
        OriginNodeNotFound,
        DestinyNodeNotFound,
        NodeAlreadyExist,
        AlphabetIndexNotFound,
        AlphabetNotSet,
        SymbolNotFound,
        ConnectionAlreadyExist
    }
}