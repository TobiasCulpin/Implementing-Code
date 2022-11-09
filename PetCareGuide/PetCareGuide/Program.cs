using System.Reflection;
internal class Program
{
    internal enum STATUS { Happy, Sad, Bored, Excited, Sleeping }
    private static void Main(string[] args)
    {
        Fish fish = new Fish("Nemo", true, STATUS.Bored, 2);
        Dog dog1 = new Dog("Fido", true, STATUS.Happy, true, 8, "Husky");
        Dog dog2 = new Dog("Beethoven", true, STATUS.Happy, true, 4, "St. Bernard");
        Lizard lizard = new Lizard("Lizzie", false, STATUS.Bored, 22.0f, 5);
        Cat cat = new Cat("Tibbles", true, STATUS.Sleeping, 6, "Tabby");
        Bird bird = new Bird("Kevin", false, STATUS.Excited, 40, "Green");
        
        Pet.showAll();
    }
    public abstract class Pet
    {
        //Private Variables
        protected string _name;
        private string _favouriteFood;
        private string _noise;
        protected bool _hungry;
        protected STATUS _status;
        protected uint _age;
        private static List<Pet> _pets = new List<Pet>();
        //Get Set
        public string name { get => _name; set => _name = value; }
        public string favouriteFood { get => _favouriteFood; set => _favouriteFood = value; }
        public string noise { get => _noise; set => _noise = value; }
        public bool hungry { get => _hungry; set => _hungry = value; }
        public STATUS status { get => _status; set => _status = value; }
        public virtual uint age { get => _age; set => _age = value; }
        public static List<Pet> pets { get => _pets; set => _pets = value; }
        //Constructors
        public Pet(string pName, bool pHungry, string pFavouriteFood, STATUS pStatus, uint pAge, string pNoise)
        {
            _name = pName;
            _hungry = pHungry;
            _favouriteFood = pFavouriteFood;
            _status = pStatus;
            _age = pAge;
            _noise = pNoise;

            _pets.Add(this);
        }
        //Methods
        public void Feed(string pFood)
        {
            if (!_hungry) { Console.WriteLine($"{name} is not hungry"); return; }
            Console.WriteLine($"Feeding {name} with {pFood}");
            if (pFood == favouriteFood) { Speak(); _status = STATUS.Happy; }
            _hungry = false;
        }
        public void Speak()
        {
            if (_status == STATUS.Sleeping) Console.WriteLine("Zzzz");
            else Console.WriteLine(_noise);
        }
        public static void showAll()
        {
            Type petType = typeof(Pet);
            List<TypeInfo> subPetTypes = petType//List of all Types assignable from Pet excluding Mammal
                .Assembly
                .DefinedTypes
                .Where(x => petType.IsAssignableFrom(x) && x != petType && x != typeof(Mammal))
                .ToList();
            foreach (var subPetType in subPetTypes)
            {
                Console.Write($"{subPetType.Name}: ");
                foreach (Pet pet in _pets)
                {
                    if (pet.GetType() == subPetType.AsType()) Console.Write($"{pet._name} ");
                }
                Console.WriteLine();
            }
        }
    }

    public abstract class Mammal : Pet
    {
        //Private Variables
        private string _breed;
        //Get Set
        public string breed { get => _breed; set => _breed = value; }
        //Constructors
        public Mammal(string pName, bool pHungry, string pFavouriteFood, STATUS pStatus, uint pAge, string pNoise, string pBreed)
            : base(pName, pHungry, pFavouriteFood, pStatus, pAge, pNoise)
        {
            _breed = pBreed;
        }
        //Methods
        public void ScratchBehindEar()
        {
            Console.WriteLine($"Scratching {_name} behind the ear...");
            Speak();
            _status = STATUS.Happy;
        }
    }

    public class Fish : Pet
    {
        //Constructors
        public Fish(string pName, bool pHungry, STATUS pStatus, uint pAge)
            : base(pName, pHungry, "Flakes", pStatus, pAge, "Blub")
        {
            
        }
        //Methods
        public void TapOnGlass()
        {
            Speak();
            _status = STATUS.Sad;
        }
    }

    public class Dog : Mammal
    {
        //Private Variables
        private bool _needsWalk;
        //Get Set
        public bool needsWalk { get => _needsWalk; set => _needsWalk = value; }
        //Constructors
        public Dog(string pName, bool pHungry, STATUS pStatus, bool pNeedsWalk, uint pAge, string pBreed)
            : base(pName, pHungry, "Bones", pStatus, pAge, "Bork", pBreed)
        {
            _needsWalk = pNeedsWalk;
        }
        //Methods
        public void Walk()
        {
            Console.WriteLine($"Walking {_name}...");
            _needsWalk = false;
            _hungry = true;
        }
    }

    public class Lizard : Pet
    {
        //Private Variables
        private float _temperature;
        //Get Set
        public float temperature { get => _temperature; set => _temperature = value; }
        //Constructors
        public Lizard(string pName, bool pHungry, STATUS pStatus, float pTemperature, uint pAge)
            : base(pName, pHungry, "Flies", pStatus, pAge, "Roar")
        {
            _temperature = pTemperature;
            if (_temperature < 25f) _status = STATUS.Sad;
        }
    }

    public class Cat : Mammal
    {
        //Private Variables
        private double _jumpingHeight;
        //Get Set
        public double jumpingHeight { get => _jumpingHeight; set => _jumpingHeight = value; }
        public override uint age { set { _age = value; _jumpingHeight = value > 15 ? 1 : Math.Sin((value * Math.PI) / 10) + 2; } }
        //Constructors
        public Cat(string pName, bool pHungry, STATUS pStatus, uint pAge, string pBreed)
            : base(pName, pHungry, "Mice", pStatus, pAge, "Meow", pBreed)
        {
            age = pAge;// reassigning age instead of _age to use the override set definition to update _jumpingHeight
        }
    }

    public class Bird : Pet
    {
        //Private Variables
        private string _featherColour;
        //Get Set
        public string featherColour { get => _featherColour; set => _featherColour = value; }
        //Constructors
        public Bird(string pName, bool pHungry, STATUS pStatus, uint pAge, string pFeatherColour)
            : base(pName, pHungry, "Seeds", pStatus, pAge, "Tweet")
        {
            _featherColour = pFeatherColour;
        }
        //Methods
        public void RattleCage()
        {
            Console.WriteLine("Rattle! Rattle! Rattle!");
            Speak();
            _status = STATUS.Sad;
        }
    }
}