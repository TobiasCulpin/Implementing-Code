internal class Program//Class, Access Modifier
{
    private static void Main(string[] args)//Access Modifier
    {
        Frog f1 = new Frog("Tom");//Constructor, Object
        JumpingFrog f2 = new JumpingFrog("Dick", 120);//Constructor, Object
        DancingFrog f3 = new DancingFrog("Harry", "Lindy Hop");//Constructor, Object

        Console.WriteLine(f1.Speak());//Member Method
        Console.WriteLine(f1.Hop());//Member Method
        Console.WriteLine();
        Console.WriteLine(f2.Speak());//Member Method
        Console.WriteLine(f2.Hop());//Member Method
        Console.WriteLine(f2.Jump());//Member Method
        Console.WriteLine();
        Console.WriteLine(f3.Speak());//Member Method
        Console.WriteLine(f3.Hop());//Member Method
        Console.WriteLine(f3.Dance());//Member Method
    }

    public class Frog//Class
    {
        private string _name;//Member Variable, Encapsulation
        public string Name { get => _name; set => _name = value; }//Member Variable, Abstraction
        public Frog(string pName) { _name = pName; }//Constructor
        public virtual string Speak() => $"Hello my name is {_name}, and I'm a {this.GetType().Name}.";//Member Variable, Polymorphism
        public string Hop() => "I hopped but not very high...";//Member Variable
    }
    public class JumpingFrog : Frog//Inheritance
    {
        private int _jumpingHeight;//Member Variable, Encapsulation
        public int jumpingHeight { get => _jumpingHeight; set => _jumpingHeight = value; }//Member Variable, Abstraction
        public JumpingFrog(string pName, int pJumpingHeight) : base(pName) { _jumpingHeight = pJumpingHeight; }//Constructor, Inheritance
        public string Jump() => $"I Jumped {_jumpingHeight}cm!";//Member Variable
        public override string Speak() => base.Speak() + $"\nI can jump {_jumpingHeight}cm high!";//Member Variable, Polymorphism
    }
    public class DancingFrog : Frog//Inheritance
    {
        private string _danceMove;//Member Variable, Encapsulation
        public string danceMove { get => _danceMove; set => _danceMove = value; }//Member Variable, Abstraction
        public DancingFrog(string pName, string pDanceMove) : base(pName) { _danceMove = pDanceMove; }//Constructor, Inheritance
        public string Dance() => $"Check out my {_danceMove} dance!";//Member Variable
        public override string Speak() => base.Speak() + $"\nI can show off my {_danceMove} dance";//Member Variable, Polymorphism
    }
}