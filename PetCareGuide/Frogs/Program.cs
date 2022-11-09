internal class Program
{
    private static void Main(string[] args)
    {
        Frog f1 = new Frog("Tom");
        JumpingFrog f2 = new JumpingFrog("Dick", 120);
        DancingFrog f3 = new DancingFrog("Harry", "Lindy Hop");

        Console.WriteLine(f1.Speak());
        Console.WriteLine(f1.Hop());
        Console.WriteLine();
        Console.WriteLine(f2.Speak());
        Console.WriteLine(f2.Hop());
        Console.WriteLine(f2.Jump());
        Console.WriteLine();
        Console.WriteLine(f3.Speak());
        Console.WriteLine(f3.Hop());
        Console.WriteLine(f3.Dance());
    }

    public class Frog
    {
        private string _name;
        public string Name { get => _name; set => _name = value; }
        public Frog(string pName) { _name = pName; }
        public virtual string Speak() => $"Hello my name is {_name}, and I'm a {this.GetType().Name}.";
        public string Hop() => "I hopped but not very high...";
    }
    public class JumpingFrog : Frog
    {
        private int _jumpingHeight;
        public int jumpingHeight { get => _jumpingHeight; set => _jumpingHeight = value; }
        public JumpingFrog(string pName, int pJumpingHeight) : base(pName) { _jumpingHeight = pJumpingHeight; }
        public string Jump() => $"I Jumped {_jumpingHeight}cm!";
        public override string Speak() => base.Speak() + $"\nI can jump {_jumpingHeight}cm high!";
    }
    public class DancingFrog : Frog
    {
        private string _danceMove;
        public string danceMove { get => _danceMove; set => _danceMove = value; }
        public DancingFrog(string pName, string pDanceMove) : base(pName) { _danceMove = pDanceMove; }
        public string Dance() => $"Check out my {_danceMove} dance!";
        public override string Speak() => base.Speak() + $"\nI can show off my {_danceMove} dance";
    }
}