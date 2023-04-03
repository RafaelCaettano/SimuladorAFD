using Automato;

var automato = new Automaton();

char[] symbols = { '0', '1' };
automato.SetAlphabet(symbols);

automato.AddNode("q0", true);
automato.AddNode("q1");
automato.AddNode("q2");
automato.AddNode("q3");
automato.AddNode("q4", end:true);
automato.AddNode("q5", end:true);
automato.AddNode("q6", end:true);
automato.AddNode("q7", end:true);

automato.AddConnection("q0", "q1", 1);
automato.AddConnection("q0", "q2", 0);

automato.AddConnection("q1", "q1", 1);
automato.AddConnection("q1", "q3", 0);

automato.AddConnection("q2", "q4", 1);
automato.AddConnection("q2", "q3", 0);

automato.AddConnection("q3", "q5", 1);
automato.AddConnection("q3", "q3", 0);

automato.AddConnection("q4", "q4", 1);
automato.AddConnection("q4", "q6", 0);

automato.AddConnection("q5", "q3", 0);
automato.AddConnection("q5", "q1", 1);

automato.AddConnection("q6", "q6", 0);
automato.AddConnection("q6", "q7", 1);

automato.AddConnection("q7", "q4", 0);
automato.AddConnection("q7", "q6", 1);

Console.WriteLine(automato.ValidateWord("11111100000101101"));

//var automato = new Automaton();

//char[] symbols = { '0', '1' };
//automato.SetAlphabet(symbols);

//automato.AddNode("q2", end:true);
//automato.AddNode("q1", true);

//automato.AddConnection("q1", "q2", 1);
//automato.AddConnection("q2", "q1", 0);
//automato.AddConnection("q1", "q1", 0);
//automato.AddConnection("q2", "q2", 1);

//Console.WriteLine(automato.ValidateWord("0101111111"));

//var newAutomato = new Automaton();

//char[] newSymbols = { 'a', 'b' };
//newAutomato.SetAlphabet(newSymbols);

//newAutomato.AddNode("s0", true);
//newAutomato.AddNode("s1");
//newAutomato.AddNode("s2");
//newAutomato.AddNode("s3");
//newAutomato.AddNode("s4", end:true);

//newAutomato.AddConnection("s0", "s1", 0);
//newAutomato.AddConnection("s0", "s2", 1);

//newAutomato.AddConnection("s1", "s1", 0);
//newAutomato.AddConnection("s1", "s3", 1);

//newAutomato.AddConnection("s2", "s1", 0);
//newAutomato.AddConnection("s2", "s2", 1);

//newAutomato.AddConnection("s3", "s4", 1);
//newAutomato.AddConnection("s3", "s1", 0);

//newAutomato.AddConnection("s4", "s1", 0);
//newAutomato.AddConnection("s4", "s2", 1);

//Console.WriteLine(newAutomato.ValidateWord("abbaabbbaabb"));