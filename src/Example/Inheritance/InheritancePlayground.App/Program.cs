using InheritancePlayground.Domain; 
public partial class Program
{
    private static void Main(string[] args)
    {
        var Mom = new Adult("Alison", 28);
        var Dad = new Adult("Tucker", 29);
        Mom.AddSpouse(Dad);
        var Son = new Child("Tom", 3, new List<Adult>{Mom, Dad});


    }
}
