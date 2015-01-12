namespace LSystemConsole
{
    public class Program
    {
        static void Main()
        {
            var s = new LSystem.LSystem {Axiom = "A",Iterations = 10,Theta = 60.0};
            s.GeneratePattern();
            s.Render(@"c:\temp\sierpinski.jpg");
        }
    }
}
