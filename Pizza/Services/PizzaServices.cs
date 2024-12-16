using Pizza.Models;

namespace Pizza.Services;
public  static class PizzaServices{
    static List<Pizzas> Pizzas { get; }
    static int nextId = 3;
    static PizzaServices(){
        Pizzas=new List<Pizzas>{
            new Pizzas{Id=1, Name="Classic Malabo", IsGlutenFree=false},
            new Pizzas{Id=2, Name="Modern Bata", IsGlutenFree=true},
            new Pizzas{Id=3, Name="Modern Annobon", IsGlutenFree=false},
            new Pizzas{Id=4, Name="Classic Luba", IsGlutenFree=true},
            new Pizzas{Id=5, Name="Classic Riaba", IsGlutenFree=true}
        };
    }

    public static List<Pizzas>GetAll()=>Pizzas;
    public static Pizzas? Get(int Id)=>Pizzas.FirstOrDefault(p=>p.Id==Id);
    public static void Add(Pizzas pizza){
        pizza.Id=nextId++;
        Pizzas.Add(pizza);
    }
    public static void Delete(int Id){
        var piz=Get(Id);
        if (piz is null)
            return;
        Pizzas.Remove(piz);
    }
    public static void Update(Pizzas pizza){
        var index=Pizzas.FindIndex(p=>p.Id== pizza.Id);
        if(index==-1)
            return;
        Pizzas[index]=pizza;
    }
}